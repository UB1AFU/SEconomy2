using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEconomy2Plugin.Framework.Attributes {
	/// <summary>
	/// Indicates that this class is a SEconomy2 account provider.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class AccountProviderAttribute : Attribute {

		public string Name { get; protected set; }

		public AccountProviderAttribute(string Name)
		{
			this.Name = Name;
		}

	}
}
