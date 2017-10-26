using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Drawing;
using UnitTestScreen.Models;

namespace UnitTestScreen
{
    [TestFixture]
    public class UnitTestWithScreenshot
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
        public void AuthenticateTest()
        {
            var config = new TestsConfig().GetConfig();

            Driver.Navigate().GoToUrl(config.ResourceUri);

            new AuthenticateHelper(Driver).Authenticate(config);

            Assert.NotNull(new MainPage(Driver).GetAvatar());
        }

        [TearDown]
        public void AfterTest()
        {
            Driver.Quit();
        }
    }
}
