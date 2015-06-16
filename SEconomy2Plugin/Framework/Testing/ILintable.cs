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

namespace SEconomy2Plugin.Framework.Testing
{
	/// <summary>
	/// Indicates that the class provides implementations for the
	/// configuration testing system to make sure it has all the
	/// information it needs to operate properly.
	/// </summary>
	public interface ILintable
	{

		/// <summary>
		/// Forces an instance to lint its configuration, throwing an
		/// exception when configuration parsing fails.  The function
		/// must throw ConfuigurationException objects when linting
		/// a provided configuration failed.
		/// </summary>
		void Lint();

	}
}
