using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SEconomy2.UnitTests {
	[TestClass]
	public class TestBase {
		protected SEconomy2Plugin.SEconomyPlugin plugin;

		[TestInitialize]
		public void SetupFormTests()
		{
			plugin = new SEconomy2Plugin.SEconomyPlugin();
		}

		[TestMethod]
		public void Test()
		{

		}

		[TestCleanup]
		public void DestroyTests()
		{
			plugin.Dispose();
			plugin = null;
		}
	}
}
