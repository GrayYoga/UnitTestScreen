using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;

namespace UnitTestScreen
{
    public class MainPage
    {
        private RemoteWebDriver Driver;
        private TestContext CurrentTestContext;

        private By sign_in = By.CssSelector(@"#navbar a[href='/sign_in']");
        private By avatar = By.CssSelector(@"#navbar img.gravatar");

        string[] delimiter = new string[] { "://" };

        public MainPage(RemoteWebDriver driver, TestContext currentTestContext)
        {
            Driver = driver;
            CurrentTestContext = currentTestContext;
        }
        private LoginPage GoToLoginPage()
        {
            Driver.FindElement(sign_in).Click();

            return new LoginPage(Driver);
        }

        public MainPage Authenticate(string resourceUri, string userName, string userPassword)
        {
            string CookiesFileName = Path.Combine(CurrentTestContext.TestDirectory,
                    resourceUri.Split(delimiter, StringSplitOptions.RemoveEmptyEntries)[1]);

            using (CookiesHelper cookiesHelper = new CookiesHelper(CookiesFileName))
            {
                if (cookiesHelper.SavedCookiesIsAvailable())
                {
                    foreach (Cookie cookie in cookiesHelper.Cookies)
                    {
                        Driver.Manage().Cookies.AddCookie(cookie);
                    }
                    Driver.Navigate().Refresh();
                }
                else
                {
                    this.GoToLoginPage().TypeUser(userName)
                        .TypePassword(userPassword)
                        .LoginButtonClick();

                    new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(drv => Driver.FindElements(avatar));
                    cookiesHelper.Cookies = Driver.Manage().Cookies.AllCookies;
                }
            }
            return this;
        }
        public IReadOnlyCollection<IWebElement> GetAvatar()
        {
            return Driver.FindElements(avatar);
        }
    }
}
