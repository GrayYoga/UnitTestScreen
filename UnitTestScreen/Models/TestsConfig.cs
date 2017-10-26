using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace UnitTestScreen.Models
{
    class TestsConfig
    {
        public ConfigModel GetConfig()
        {
            return new ConfigurationBuilder()
                .SetBasePath(TestContext.CurrentContext.TestDirectory)
                .AddJsonFile("Config.json", false, false)
                .Build()
                .Get<ConfigModel>();
        }
    }
}