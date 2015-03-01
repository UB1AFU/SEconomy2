/*
 * SEconomy 2.0 - Server-sided currency, ranking and economy for TShock
 * Copyright (C) 2015  Tyler Watson <tyler@tw.id.au>
 * 
 * This file is part of SEconomy2.
 * 
 * SEconomy2 is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 2 of the License, or
 * (at your option) any later version.
 * 
 * SEconomy2 is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with SEconomy2.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariaApi.Server;

namespace SEconomy2Plugin {
	public class SEconomyPlugin : TerrariaPlugin {

		public SEconomyPlugin(Terraria.Main game)
			: base(game)
		{

		}

		public SEconomyPlugin()
			: base(null)
		{

		}

		public override void Initialize()
		{
			throw new NotImplementedException();
		}
	}
}
