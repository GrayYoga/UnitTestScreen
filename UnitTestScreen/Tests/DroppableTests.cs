using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Drawing;
using UnitTestScreen.Models;

namespace UnitTestScreen
{
    [TestFixture]
    class DroppableTests
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
            AuthenticateHelper.Authenticate<W2aDroppablePage>(Driver, config);
            // после авторизации переход происходит не на ту страницу, с которой начиналась авторизация
            Driver.Navigate().Refresh();
            Driver.Navigate().GoToUrl(config.ResourceUri);
        }

        [Test]
        public void DragAndDropTest()
        {
            var w2aDroppablePage = new W2aDroppablePage(Driver);

            w2aDroppablePage.SwitchToDroppableFrame();
            
           var DroppableTextBefore = w2aDroppablePage.GetDroppableText();

            w2aDroppablePage.DragAndDrop();

            var DroppableTextAfter = w2aDroppablePage.GetDroppableText();

            Assert.That(!DroppableTextAfter.Equals(DroppableTextBefore));
        }

        [TearDown]
        public void AfterTest()
        {
            Driver.Quit();
        }
    }
}
