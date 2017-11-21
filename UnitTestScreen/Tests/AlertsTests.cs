using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Drawing;
using UnitTestScreen.Models;

namespace UnitTestScreen
{
    [TestFixture]
    class AlertsTests
    {
        private RemoteWebDriver Driver;

        [SetUp]
        public void BeforeTest()
        {
            Driver = new RemoteWebDriver(new ChromeOptions().ToCapabilities());
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Manage().Window.Size = new Size(1360, 1020);

            var config = TestsConfig.GetConfig(GetType().ToString());

            Driver.Navigate().GoToUrl(config.ResourceUri);
            AuthenticateHelper.Authenticate<W2aAlertsPage>(Driver, config);
            // после авторизации переход происходит не на ту страницу, с которой начиналась авторизация
            Driver.Navigate().Refresh();
            Driver.Navigate().GoToUrl(config.ResourceUri);
        }

        [Test]
        public void AlertWithInputTest()
        {
            var w2aAlertsPage = new W2aAlertsPage(Driver);
            var customText = "Walter Kovacs";

            w2aAlertsPage
                .GoToInputAlertTab()
                .SwitchToInputAlertFrame()
                .ClickButton()
                .OpenAlertAndInputCustomText(customText);
            
            Assert.That(w2aAlertsPage.GetDemoText().Contains(customText));
        }

        [TearDown]
        public void AfterTest()
        {
            Driver.Quit();
        }
    }
}
