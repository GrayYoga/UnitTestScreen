using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing;
using System.IO;
using UnitTestScreen.Models;
using UnitTestScreen.TestData;

namespace UnitTestScreen
{
    [TestFixture]
    public class UnitTestWithScreenshot
    {
        private RemoteWebDriver Driver;
        private string [] Delimiter = new string [] { "://" };

        [SetUp]
        public void BeforeTest()
        {
            Driver = new RemoteWebDriver(new ChromeOptions().ToCapabilities());
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Manage().Window.Size = new Size(1360, 1020);
        }

        [Test, TestCaseSource(typeof(Config),nameof(Config.AuthenticateSet))]
        public void AuthenticateTest(ConfigModel config)
        {
            Driver.Navigate().GoToUrl(config.ResourceUri);
            var mainPage = new MainPage(Driver);

            string cookiesFileName = Path.Combine(TestContext.CurrentContext.TestDirectory,
                config.ResourceUri.Split(Delimiter, StringSplitOptions.RemoveEmptyEntries)[1]);

            using (var cookiesHelper = new CookiesHelper(cookiesFileName))
            {
                if (cookiesHelper.SavedCookiesAreAvailable())
                {
                    foreach (Cookie cookie in cookiesHelper.Cookies)
                    {
                        Driver.Manage().Cookies.AddCookie(cookie);
                    }
                    Driver.Navigate().Refresh();
                }
                else
                {
                    mainPage.GoToLoginPage()
                        .TypeUser(config.UserName)
                        .TypePassword(config.UserPassword)
                        .LoginButtonClick();

                    new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(drv => mainPage.GetAvatar());
                    cookiesHelper.Cookies = Driver.Manage().Cookies.AllCookies;
                }
            }
            Assert.NotNull(mainPage.GetAvatar());
        }

        [TearDown]
        public void AfterTest()
        {
            Driver.Quit();
        }
    }
}
