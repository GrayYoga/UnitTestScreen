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
        private By WindowsFrame = By.CssSelector("iframe[src = 'frames-windows/defult1.html']");
        private By LinkToNewTab = By.CssSelector("a");

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

        public W2aFramesAndWindowsPage SwitchToSortableFrame()
        {
            Driver.SwitchTo().Frame(Driver.FindElement(WindowsFrame));
            return this;
        }

        public W2aFramesAndWindowsPage ClickToLinkToNewTab()
        {
            Driver.FindElement(LinkToNewTab).Click();
            return this;
        }
    }
}
