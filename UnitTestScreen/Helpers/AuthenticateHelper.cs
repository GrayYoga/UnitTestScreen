using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using UnitTestScreen.Models;

namespace UnitTestScreen
{
    public class AuthenticateHelper
    {
        private RemoteWebDriver Driver;

        public AuthenticateHelper(RemoteWebDriver driver)
        {
            Driver = driver;
        }
        public void Authenticate(ConfigModel config)
        {
            var cookieFileName = config.ResourceUri.Host;
            string absoluteCookiesFleName = Path.Combine(TestContext.CurrentContext.TestDirectory, cookieFileName);

            MainPage mainPage = new MainPage(Driver);

            using (var cookiesHelper = new CookiesHelper(absoluteCookiesFleName))
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
        }
    }
}
