using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;

namespace SEconomy2Plugin.Subsystems.WorldWatchdog {
	/// <summary>
	/// WorldWatchdog watches the world for specific events (namely NPC death and
	/// player death) and creates high-level events tracking useful information about
	/// them that TerrariaServer or TShock don't track themselves.
	/// </summary>
	public class WorldWatchdog {
		protected TerrariaPlugin instance;

		/// <summary>
		/// Format for this dictionary:
		/// Key: NPC
		/// Value: A list of players who have done damage to the NPC
		/// </summary>
		private Dictionary<Terraria.NPC, List<PlayerDamage>> DamageDictionary = new Dictionary<Terraria.NPC, List<PlayerDamage>>();

		/// <summary>
		/// Format for this dictionary:
		/// * key: Player ID
		/// * value: Last player hit ID
		/// </summary>
		protected Dictionary<int, int> PVPDamage = new Dictionary<int, int>();

		/// <summary>
		/// synch object for access to the dictionary.  You MUST obtain 
		/// a mutex through this object to access the dictionary member.
		/// </summary>
		protected readonly object __dictionaryMutex = new object();

		/// <summary>
		/// synch object for access to the pvp dictionary.  You MUST obtain
		/// a mutex through this object to access the dictionary member.
		/// </summary>
		protected readonly object __pvpDictMutex = new object();

		/// <summary>
		/// Synch object for NPC damage, forcing NPC damages to be serialized
		/// </summary>
		protected static readonly object __NPCDamageMutex = new object();

		public event EventHandler<NPCDeathEventArgs> NPCDeath;

		public event EventHandler<PlayerDeathEventArgs> PlayerDeath;

		public WorldWatchdog(TerrariaPlugin pluginInstance)
		{
			this.instance = pluginInstance;
			ServerApi.Hooks.NetGetData.Register(pluginInstance, NetHooks_GetData);
			ServerApi.Hooks.NetSendData.Register(pluginInstance, NetHooks_SendData);
			ServerApi.Hooks.GameUpdate.Register(pluginInstance, Game_Update);
		}

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing) {
				ServerApi.Hooks.NetGetData.Deregister(instance, NetHooks_GetData);
				ServerApi.Hooks.NetSendData.Deregister(instance, NetHooks_SendData);
				ServerApi.Hooks.GameUpdate.Deregister(instance, Game_Update);
			}
		}

		protected void Game_Update(EventArgs args)
		{
			foreach (Terraria.NPC npc in Terraria.Main.npc) {
				if (npc == null || npc.townNPC == true || npc.lifeMax == 0) {
					continue;
				}

				if (npc.active == false) {
					ProcessNPCDeath(npc);
				}
			}
		}

		#region "NPC Reward handling"

		/// <summary>
		/// Adds damage done by a player to an NPC slot.  When the NPC dies the rewards for it will fill out.
		/// </summary>
		protected void AddNPCDamage(Terraria.NPC NPC, Terraria.Player Player, int Damage, bool crit = false)
		{
			List<PlayerDamage> damageList = null;
			PlayerDamage playerDamage = null;
			double dmg;


			if (Player == null || NPC.active == false || NPC.life <= 0) {
				return;
			}

			lock (__dictionaryMutex) {
				if (DamageDictionary.ContainsKey(NPC)) {
					damageList = DamageDictionary[NPC];
				} else {
					damageList = new List<PlayerDamage>(1);
					DamageDictionary.Add(NPC, damageList);
				}
			}

			lock (__NPCDamageMutex) {
				if ((playerDamage = damageList.FirstOrDefault(i => i.Player == Player)) == null) {
					playerDamage = new PlayerDamage() { Player = Player };
					damageList.Add(playerDamage);
				}

				if ((dmg = (crit ? 2 : 1) * Main.CalculateDamage(Damage, NPC.ichor ? NPC.defense - 20 : NPC.defense)) > NPC.life) {
					dmg = NPC.life;
				}
			}

			playerDamage.Damage += dmg;
		}

		/// <summary>
		/// Should occur when an NPC dies; gives rewards out to all the players that hit it.
		/// </summary>
		protected void ProcessNPCDeath(Terraria.NPC NPC)
		{
			List<PlayerDamage> playerDamageList = null;
			Dictionary<Player, double> argsDict;
			NPCDeathEventArgs args;

			lock (__dictionaryMutex) {
				if (DamageDictionary.ContainsKey(NPC)) {
					playerDamageList = DamageDictionary[NPC];

					if (DamageDictionary.Remove(NPC) == false) {
						TShock.Log.ConsoleError("seconomy: world economy: Remove of NPC after reward failed.  This is an internal error.");
					}
				}
			}

			if (playerDamageList == null
				|| NPCDeath == null) {
				return;
			}

			argsDict = new Dictionary<Player,double>();
			args = new NPCDeathEventArgs(NPC, argsDict);
			
			foreach (PlayerDamage dmg in playerDamageList) {
				argsDict.Add(dmg.Player, dmg.Damage);
			}

			NPCDeath(this, args);
		}

		#endregion

		/// <summary>
		/// Assigns the last player slot to a victim in PVP
		/// </summary>
		protected void PlayerHitPlayer(int HitterSlot, int VictimSlot)
		{
			lock (__pvpDictMutex) {
				if (PVPDamage.ContainsKey(VictimSlot)) {
					PVPDamage[VictimSlot] = HitterSlot;
				} else {
					PVPDamage.Add(VictimSlot, HitterSlot);
				}
			}
		}

		/// <summary>
		/// Runs when a player dies and runs the PlayerDeath event
		/// </summary>
		protected void ProcessDeath(int DeadPlayerSlot, bool PVPDeath)
		{
			TSPlayer murderer = null, murdered = null;
			PlayerDeathEventArgs args;
			int lastHitterSlot = default(int);

			//get the last hitter ID out of the dictionary
			lock (__pvpDictMutex) {
				if (PVPDamage.ContainsKey(DeadPlayerSlot)) {
					lastHitterSlot = PVPDamage[DeadPlayerSlot];
					PVPDamage.Remove(DeadPlayerSlot);
				}
			}

			murderer = TShockAPI.TShock.Players.ElementAtOrDefault(lastHitterSlot);
			murdered = TShockAPI.TShock.Players.ElementAtOrDefault(DeadPlayerSlot);
			args = new PlayerDeathEventArgs(murderer, murdered);

			if (PlayerDeath != null) {
				PlayerDeath(this, args);
			}
		}

		/// <summary>
		/// Occurs when the server has received a message from the client.
		/// </summary>
		protected void NetHooks_GetData(GetDataEventArgs args)
		{
			byte[] bufferSegment = null;
			Terraria.Player player = null;

			if ((player = Terraria.Main.player.ElementAtOrDefault(args.Msg.whoAmI)) == null) {
				return;
			}

			bufferSegment = new byte[args.Length];
			System.Array.Copy(args.Msg.readBuffer, args.Index, bufferSegment, 0, args.Length);

			if (args.MsgID == PacketTypes.NpcStrike) {
				Terraria.NPC npc = null;
				Packets.DamageNPC dmgPacket = Packets.PacketMarshal.MarshalFromBuffer<Packets.DamageNPC>(bufferSegment);

				if (dmgPacket.NPCID < 0 || dmgPacket.NPCID > Terraria.Main.npc.Length
					|| args.Msg.whoAmI < 0 || dmgPacket.NPCID > Terraria.Main.player.Length) {
					return;
				}

				if ((npc = Terraria.Main.npc.ElementAtOrDefault(dmgPacket.NPCID)) == null) {
					return;
				}

				AddNPCDamage(npc, player, dmgPacket.Damage, Convert.ToBoolean(dmgPacket.CrititcalHit));
			}
		}

		/// <summary>
		/// Occurs when the server has a chunk of data to send
		/// </summary>
		protected void NetHooks_SendData(SendDataEventArgs e)
		{
			try {
				if (e.MsgId == PacketTypes.PlayerDamage) {
					//occurs when a player hits another player.  ignoreClient is the player that hit, e.number is the 
					//player that got hit, and e.number4 is a flag indicating PvP damage

					if (Convert.ToBoolean(e.number4) && Terraria.Main.player[e.number] != null) {
						PlayerHitPlayer(e.ignoreClient, e.number);
					}
				} else if (e.MsgId == PacketTypes.PlayerKillMe) {
					//Occrs when the player dies.
					ProcessDeath(e.number, Convert.ToBoolean(e.number4));
				}
			} catch {

			}
		}
	}

	/// <summary>
	/// Damage structure, wraps a player slot and the amount of damage they have done.
	/// </summary>
	class PlayerDamage {
		public Terraria.Player Player;
		public double Damage;
	}

}
