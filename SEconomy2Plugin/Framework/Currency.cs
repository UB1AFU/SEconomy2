using SEconomy2Plugin.Configuration;
using SEconomy2Plugin.Framework.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

using System.Threading.Tasks;
using System.Xml.Linq;

namespace SEconomy2Plugin.Framework
{
	public abstract class Currency : Provider, ILintable
	{
		protected List<EconomyProvider> _economyProviders;
		protected AccountProvider _accountProvider;

		public bool KeepHistory { get; protected set; }

		public bool Enabled { get; set; }

		public string Name { get; protected set; }

		public string Abbreviation { get; protected set; }

		protected Currency(SEconomy instance, XElement configElement)
			: base(instance, configElement)
		{
			LoadConfiguration(configElement);
		}

		protected void LoadConfiguration(XElement elem)
		{
			Name = Configuration.Element("Display").Attribute("CurrencyName").Value;
			Abbreviation = Configuration.Element("Display").Attribute("Abbreviation").Value;
			KeepHistory = Configuration.Element("History").Attribute("KeepHistory").Value.Equals("true", StringComparison.InvariantCultureIgnoreCase);
		}

		public void Lint()
		{
			if (Configuration.Element("History") == null) {
				throw new ConfigurationException(Configuration, "History element is missing");
			}

			if (Configuration.Element("History").Attribute("KeepHistory") == null) {
				throw new ConfigurationException(Configuration, "KeepHistory element is missing");
			}

			if (Configuration.Element("Display") == null) {
				throw new ConfigurationException(Configuration, "Display element is missing");
			}

			if (Configuration.Element("Display").Attribute("CurrencyName") == null) {
				throw new ConfigurationException(Configuration, "Display element must have a CurrencyName attribute");
			}

			if (Configuration.Element("Display").Attribute("Abbreviation") == null) {
				throw new ConfigurationException(Configuration, "Display element must have a Abbreviation attribute");
			}
		}




		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);

			if (disposing)
			{
				lock (_economyProviders)
				{
					foreach (IDisposable d in _economyProviders)
					{
						d.Dispose();
					}

					_economyProviders = null;
				}

				_accountProvider.Dispose();
				_accountProvider = null;
			}
		}

		public override string ToString()
		{
			return string.Format("[Currency Enabled: {0}, Name: {1}, Abbreviation: {2}, KeepHistory: {3}]", Enabled, Name, Abbreviation, KeepHistory);
		}
	}
}
