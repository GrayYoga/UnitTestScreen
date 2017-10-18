using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;

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
            driver.Navigate().GoToUrl("https://www.simbirsoft.com");
        }
        [Test]
        public void TestMethod()
        {
            Assert.AreEqual(1, 2, new ScreenshotHelper(driver).TakeScreenshotAndGetBase64Link(), new object[] { });
        }
        [OneTimeTearDown]
        public void CloseDriver()
        {
            driver.Quit();
        }
    }
}
