using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using TShockAPI;

namespace SEconomy2Plugin.Subsystems.WorldWatchdog {

	/// <summary>
	/// Occurs when WorldWatchdog determines an NPC died, and contains
	/// a dictionary of players who hit the NPC, and how much damage
	/// they have done.
	/// </summary>
	public class NPCDeathEventArgs : EventArgs {
		protected readonly NPC npc;
		protected readonly Dictionary<Player, double> damageList;

		public NPC NPC { get { return npc; } }

		public Dictionary<Player, double> PlayerDamage { get { return damageList; } }

		public NPCDeathEventArgs(NPC NPC, Dictionary<Player, double> DamageList)
		{
			this.npc = NPC;
			this.damageList = DamageList;
		}
	}

	public class PlayerDeathEventArgs : EventArgs {

		public TSPlayer Player { get; protected set; }

		public TSPlayer PvPKiller { get; protected set; }

		public PlayerDeathEventArgs(TSPlayer Player, TSPlayer Killer)
		{
			this.Player = Player;
			this.PvPKiller = Killer;
		}

	}

}
