using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Drawing;
using UnitTestScreen.Models;

namespace UnitTestScreen
{
    [TestFixture]
    public class AuthenticationTests
    {
        private RemoteWebDriver Driver;

        [SetUp]
        public void BeforeTest()
        {
            Driver = new RemoteWebDriver(new ChromeOptions().ToCapabilities());
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Manage().Window.Size = new Size(1360, 1020);
        }

        [Test]
        [Repeat(2)]
        public void AuthenticateTest()
        {
            var config = TestsConfig.GetConfig();

            Driver.Navigate().GoToUrl(config.ResourceUri);

            AuthenticateHelper.Authenticate<MainPage>(Driver, config);

            Assert.True(new MainPage(Driver).IsAutorized());
        }

        [TearDown]
        public void AfterTest()
        {
            Driver.Quit();
        }
    }
}
