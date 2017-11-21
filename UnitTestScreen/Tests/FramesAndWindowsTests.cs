using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Drawing;
using UnitTestScreen.Models;

namespace UnitTestScreen
{
    [TestFixture]
    class FramesAndWindowsTests
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
            AuthenticateHelper.Authenticate<W2aFramesAndWindowsPage>(Driver, config);
            // после авторизации переход происходит не на ту страницу, с которой начиналась авторизация
            Driver.Navigate().Refresh();
            Driver.Navigate().GoToUrl(config.ResourceUri);
        }

        [Test]
        public void NewMultiplewindowsTest()
        {
            var w2aFrameAndWindowsPage = new W2aFramesAndWindowsPage(Driver);

            w2aFrameAndWindowsPage.GoToMultipleWindowsTab();

            w2aFrameAndWindowsPage.SwitchToFramesAndWindowsFrame();

            w2aFrameAndWindowsPage.ClickToLinkToNewMultipleWindows();

            Driver.SwitchTo().Window(Driver.WindowHandles[1]);

            // По правильному нужно завести новую страницу,
            // но ради одного клика можно задействовать существующий код.
            w2aFrameAndWindowsPage.ClickToLinkToNewMultipleWindows();

            Assert.That(Driver.WindowHandles.Count == 3);
        }

        [TearDown]
        public void AfterTest()
        {
            Driver.Quit();
        }
    }
}
