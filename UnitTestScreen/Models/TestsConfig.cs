using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Collections.Generic;

namespace UnitTestScreen.Models
{
    class TestsConfig
    {
        public static ConfigModel GetConfig(string name)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(TestContext.CurrentContext.TestDirectory)
                .AddJsonFile("Config.json", false, false)
                .Build()
                .GetSection(name)
                .Get<ConfigModel>();

            if (config == null)
                throw new KeyNotFoundException($"Config for fixture {name} not found.");

            return config;
        }
    }
}
