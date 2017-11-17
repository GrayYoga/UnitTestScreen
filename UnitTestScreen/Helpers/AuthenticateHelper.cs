using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.IO;
using UnitTestScreen.Models;

namespace UnitTestScreen
{
    public class AuthenticateHelper
    {
        public static void Authenticate<T>(RemoteWebDriver driver, ConfigModel config) where T : IGoToAuthenticate, new()
        {
            var cookieFileName = config.ResourceUri.Host;
            string absoluteCookiesFileName = Path.Combine(TestContext.CurrentContext.TestDirectory, cookieFileName);

            using (var cookiesHelper = new CookiesHelper(absoluteCookiesFileName))
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
                    T mainPage = new T
                    {
                        Driver = driver
                    };

                    mainPage.GoToLoginPage()
                        .TypeUser(config.UserName)
                        .TypePassword(config.UserPassword)
                        .LoginButtonClick();

                    cookiesHelper.Cookies = driver.Manage().Cookies.AllCookies;
                }
            }
        }
    }
}
