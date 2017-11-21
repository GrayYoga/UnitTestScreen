using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestScreen
{
    class W2aFramesAndWindowsPage : BasePage, IGoToAuthenticate
    {
        private By OpenMultipleWindowsTab = By.CssSelector("a[href = '#example-1-tab-4']");
        private By WindowsFrame = By.CssSelector("iframe[src = 'frames-windows/defult4.html']");
        private By LinkToNewMultipleWindows = By.XPath("//a[text()='Open multiple pages']");

        public W2aFramesAndWindowsPage(RemoteWebDriver driver) : base(driver)
        {
        }

        public W2aFramesAndWindowsPage() : base()
        {
        }

        public IBaseLoginPage GoToLoginPage()
        {
            return new W2aLoginPage(Driver).GoToLoginPage();
        }

        public W2aFramesAndWindowsPage GoToMultipleWindowsTab()
        {
            Driver.FindElement(OpenMultipleWindowsTab).Click();
            return this;
        }

        public W2aFramesAndWindowsPage SwitchToFramesAndWindowsFrame()
        {
            Driver.SwitchTo().Frame(Driver.FindElement(WindowsFrame));
            return this;
        }

        public W2aFramesAndWindowsPage ClickToLinkToNewMultipleWindows()
        {
            Driver.FindElement(LinkToNewMultipleWindows).Click();
            return this;
        }
    }
}
