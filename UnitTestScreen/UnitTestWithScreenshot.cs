using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;

using NUnit.Framework;
using System.Threading;
using System.IO;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Drawing;

namespace UnitTestScreen
{
    [TestFixture]
    public class UnitTestWithScreenshot
    {
        private const string resourceUri = @"http://courses.way2automation.com";
        private const string UserName = @"i1go1by@gmail.com";
        private const string UserPassword = @"321654";

        
        private RemoteWebDriver driver;

         [Test]
        public void TestMethod()
        {
            driver = new RemoteWebDriver(new ChromeOptions().ToCapabilities());
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Size = new Size(1360, 1020);

            driver.Navigate().GoToUrl(resourceUri);

            MainPage mainPage = new MainPage(driver, TestContext.CurrentContext);
            mainPage.Authenticate(resourceUri,UserName, UserPassword);

            CollectionAssert.IsNotEmpty(mainPage.GetAvatar());
            driver.Quit();
        }
    }
}
