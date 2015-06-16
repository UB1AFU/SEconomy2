using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEconomy2Plugin.Framework.Attributes {
	/// <summary>
	/// Indicates this class is a SEconomy2 currency implementation
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class CurrencyAttribute : Attribute {

		public string Name { get; protected set; }

		public CurrencyAttribute(string name)
		{
			this.Name = name;
		}

	}
}
