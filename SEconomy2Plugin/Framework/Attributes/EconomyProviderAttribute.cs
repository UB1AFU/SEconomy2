using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEconomy2Plugin.Framework.Attributes {
	public class EconomyProviderAttribute : Attribute {

		public string Name { get; protected set; }

		public EconomyProviderAttribute(string name)
		{
			this.Name = name;
		}
	}
}
