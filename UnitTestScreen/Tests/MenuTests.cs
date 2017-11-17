using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestScreen.Models;

namespace UnitTestScreen.Tests
{
    
    [TestFixture]
    public class MenuTests
    {
        private RemoteWebDriver Driver;

        [SetUp]
        public void BeforeTest()
        {
            Driver = new RemoteWebDriver(new ChromeOptions().ToCapabilities());
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Manage().Window.Size = new Size(1360, 1020);

            var config = TestsConfig.GetConfig();

            Driver.Navigate().GoToUrl(config.ResourceUri);
            AuthenticateHelper.Authenticate<W2aMenuPage>(Driver, config);
            // после авторизации переход происходит не на ту страницу, с которой начиналась авторизация
            Driver.Navigate().Refresh();
            Driver.Navigate().GoToUrl(config.ResourceUri); 
        }

        [Test]
        public void VisibleSubmenuTest()
        {
            var w2aMenuPage = new W2aMenuPage(Driver);
            w2aMenuPage
                .OpenMenuWithSubmenu()
                .MoveCursorToMenuItemWithSubmenu();

            Assert.True(w2aMenuPage.SubmenuIsVisible());
        }

        [TearDown]
        public void AfterTest()
        {
            Driver.Quit();
        }
    }
}
