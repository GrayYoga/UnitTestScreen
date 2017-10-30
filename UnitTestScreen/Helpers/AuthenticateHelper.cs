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

        public static void Authenticate(RemoteWebDriver driver, ConfigModel config)
        {
            var cookieFileName = config.ResourceUri.Host;
            string absoluteCookiesFleName = Path.Combine(TestContext.CurrentContext.TestDirectory, cookieFileName);

            using (var cookiesHelper = new CookiesHelper(absoluteCookiesFleName))
            {
                if (cookiesHelper.SavedCookiesAreAvailable())
                {
                    foreach (Cookie cookie in cookiesHelper.Cookies)
                    {
                        driver.Manage().Cookies.AddCookie(cookie);
                    }
                    driver.Navigate().Refresh();
                }
                else
                {
                    var mainPage = new MainPage(driver);
                    mainPage.GoToLoginPage()
                        .TypeUser(config.UserName)
                        .TypePassword(config.UserPassword)
                        .LoginButtonClick();

                    new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(drv => mainPage.GetAvatar());
                    cookiesHelper.Cookies = driver.Manage().Cookies.AllCookies;
                }
            }
        }
    }
}
