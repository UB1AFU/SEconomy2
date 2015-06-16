using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SEconomy2Plugin.Framework {
	/// <summary>
	/// Base class that all SEconomy2 account providers must inherit from
	/// if they are to validly implement an account provider.
	/// </summary>
	public abstract class AccountProvider : IDisposable {

		/// <summary>
		/// Gets the XML configuration element for this account provider
		/// </summary>
		protected XElement Configuration { get; set; }

		protected SEconomy SEconomy { get; set; }

		protected AccountProvider(SEconomy instance, XElement config)
		{
			this.Configuration = config;
			this.SEconomy = instance;
		}

		~AccountProvider()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing) {

				SEconomy = null;
				Configuration = null;
			}
		}
	}
}
