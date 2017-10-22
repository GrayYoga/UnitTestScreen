using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;

using NUnit.Framework;
using System.Threading;
using System.IO;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace UnitTestScreen
{
    [TestFixture]
    public class UnitTestWithScreenshot
    {
        private RemoteWebDriver driver;

        [OneTimeSetUp]
        public void RunDriver()
        {
            driver = new RemoteWebDriver(new ChromeOptions().ToCapabilities());
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void TestMethod()
        {
            const string resourceUri = @"http://courses.way2automation.com";
            //Assert.AreEqual(1, 2, new ScreenshotHelper(driver).TakeScreenshotAndGetBase64Link(), new object[] { });
            driver.Navigate().GoToUrl(resourceUri);
            // insert cookies managing
            CookiesHelper cookiesHelper = new CookiesHelper(
                Path.Combine( TestContext.CurrentContext.TestDirectory,
                    resourceUri.Substring(resourceUri.LastIndexOf(".", resourceUri.LastIndexOf(".") - 1) + 1)));
            if (cookiesHelper.IsSet)
            {
                foreach (Cookie cookie in cookiesHelper.Cookies)
                {
                    driver.Manage().Cookies.AddCookie(cookie);
                }
                driver.Navigate().Refresh();
            }
            else
            { // authenticate
                driver.FindElement(By.XPath(@"//a[contains(concat(' ',@href,' '),' /sign_in ')]")).Click();
                
                driver.FindElement(By.XPath(@"//input[contains(concat(' ',@id,' '),' user_email ')]")).SendKeys(@"i1go1by@gmail.com");
                driver.FindElement(By.XPath(@"//input[contains(concat(' ',@id,' '),' user_password ')]")).SendKeys(@"321654");
                driver.FindElement(By.XPath(@"//*[contains(concat(' ',@id,' '),' new_user ')]//input[contains(concat(' ',@class,' '),' login-button ')]")).Click();

                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(drv => driver.FindElements(By.XPath(@"//*[contains(concat(' ',@id,' '),' navbar ')]//img[contains(concat(' ',@alt,' '),' i1go1by@gmail.com ')]")));

                cookiesHelper.Cookies = driver.Manage().Cookies.AllCookies; 
            }
            CollectionAssert.IsNotEmpty(driver.FindElements(By.XPath(@"//*[contains(concat(' ',@id,' '),' navbar ')]//img[contains(concat(' ',@alt,' '),' i1go1by@gmail.com ')]")));
        }

        [OneTimeTearDown]
        public void CloseDriver()
        {
            driver.Quit();
        }
    }
}
