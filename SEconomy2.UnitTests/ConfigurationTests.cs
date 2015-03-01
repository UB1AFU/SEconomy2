using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace SEconomy2.UnitTests {
	[TestClass]
	public class ConfigurationTests {
		protected SEconomy2Plugin.SEconomyPlugin plugin;

		protected string jsonBlob = @"{
    ""currency configuration"": [
        {
            ""currency id"": 0,
            ""use quadrant mode"": false,
            ""money properties"": {
                ""tradeable"": true,
                ""pve earnable"": true,
                ""pvp earnable"": true,
                ""pvp loseable"": true
            },
            ""singular mode properties"": {
                ""currency name"": ""soul shard"",
                ""plural currency name"": ""soul shards"",
                ""abbreviation"": ""ss"",
                ""display format"": ""N0""
            },
            ""quadrant mode properties"": {
                ""1"": {
                    ""full name"": ""Copper"",
                    ""short name"": ""copper"",
                    ""abbreviation"": ""c""
                },
                ""2"": {
                    ""full name"": ""Silver"",
                    ""short name"": ""silver"",
                    ""abbreviation"": ""s""
                },
                ""3"": {
                    ""full name"": ""Gold"",
                    ""short name"": ""gold"",
                    ""abbreviation"": ""g""
                },
                ""4"": {
                    ""full name"": ""Platinum"",
                    ""short name"": ""platinum"",
                    ""abbreviation"": ""p""
                }
            }
        },
        {
            ""currency id"": 1,
            ""use quadrant mode"": false,
            ""money properties"": {
                ""tradeable"": false,
                ""pve earnable"": true,
                ""pvp earnable"": true,
                ""pvp loseable"": false
            },
            ""singular mode properties"": {
                ""currency name"": ""exp"",
                ""plural currency name"": ""exp"",
                ""abbreviation"": ""exp"",
                ""display format"": ""N0""
            },
            ""quadrant mode properties"": {
                ""1"": {
                    ""full name"": ""Copper"",
                    ""short name"": ""copper"",
                    ""abbreviation"": ""c""
                },
                ""2"": {
                    ""full name"": ""Silver"",
                    ""short name"": ""silver"",
                    ""abbreviation"": ""s""
                },
                ""3"": {
                    ""full name"": ""Gold"",
                    ""short name"": ""gold"",
                    ""abbreviation"": ""g""
                },
                ""4"": {
                    ""full name"": ""Platinum"",
                    ""short name"": ""platinum"",
                    ""abbreviation"": ""p""
                }
            }
        }
    ],
    ""redis configuration"": {
        ""database host"": ""127.0.0.1"",
        ""port"": 6379,
        ""database index"": 0
    },
    ""world economy configuration"": {
        ""globally enabled"": true,
        ""currency specific configuration"": {
            ""currency id 0"": {
                ""disable npc gains for"": [ 1, 49, 74, 85, 67, 55, 63, 58, 57, 47, 65, 21 ],
                ""announce gains to player"": true,
                ""npc gain factor"": 1.0,
                ""boss gain factor"": 1.0,
                ""pvp loss factor"": 0.01,
                ""npc gain factor overrides"": { 
                    ""50"": 2.0
                }
            },
            ""currency id 1"": {
                ""disable npc gains for"": [ ],
                ""announce gains to player"": true,
                ""npc gain factor"": 0.01,
                ""boss gain factor"": 1.0,
                ""pvp loss factor"": 0.0,
                ""npc gain factor overrides"": { 
                }
            }
        }
    },
    ""level up ranking system configuration"": {
        ""globally enabled"": false,
        ""currency id"": 1,
        ""tshock group prefix"": ""seconomy.level."",
        ""max level"": 100,
        ""level base exp"": 150000,
        ""level curve factor"": 12.24026
    },
    ""tree ranking system configuration"": {
        ""globally enabled"": false,
        ""currency id"": 0,
        ""ranking list file"": ""rankingList.json""
    }
}
";
		[TestInitialize]
		public void SetupFormTests()
		{
			plugin = new SEconomy2Plugin.SEconomyPlugin();
		}

		[TestMethod]
		public void TestJsonParse()
		{
			JObject o = JObject.Parse(jsonBlob);
		}

		[TestMethod]
		public void TestJsonPath()
		{
			JObject o = JObject.Parse(jsonBlob);

			Assert.IsInstanceOfType(o.SelectToken("$"), typeof(JObject));
			Assert.AreEqual(o["currency configuration"].Children().Count(), 2);

		}

		[TestMethod]
		public void TestInvalidPath()
		{
			JObject o = JObject.Parse(jsonBlob);

			Assert.IsNull(o.SelectToken("$.aslkhdlkasjdgh"));
		}

		[TestCleanup]
		public void DestroyTests()
		{
			plugin.Dispose();
			plugin = null;
		}
	}
}
