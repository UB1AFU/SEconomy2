using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SEconomy2.UnitTests {
	[TestClass]
	public class FormTests {
		protected SEconomy2Plugin.SEconomyPlugin plugin;

		[TestInitialize]
		public void SetupFormTests()
		{
			plugin = new SEconomy2Plugin.SEconomyPlugin();
		}

		[TestMethod]
		public void TestSetupForm()
		{
			SEconomy2Plugin.Forms.CSEconomySetupWnd setupWnd = new SEconomy2Plugin.Forms.CSEconomySetupWnd();
			setupWnd.ShowDialog();
		}

		[TestCleanup]
		public void DestroyTests()
		{
			plugin.Dispose();
			plugin = null;
		}
	}
}
