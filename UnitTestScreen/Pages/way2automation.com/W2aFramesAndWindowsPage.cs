using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace UnitTestScreen
{
    class W2aFramesAndWindowsPage : BasePage, IGoToAuthenticate
    {
        private By OpenNewWindowTab = By.CssSelector("a[href = '#example-1-tab-1']");
        private By NewWindowFrame = By.CssSelector("iframe[src = 'frames-windows/defult1.html']");
        private By LinkToNewBrowserTab = By.XPath("//a[text()='New Browser Tab']");

        private By OpenMultipleWindowsTab = By.CssSelector("a[href = '#example-1-tab-4']");
        private By MultipleWindowsFrame = By.CssSelector("iframe[src = 'frames-windows/defult4.html']");
        private By LinkToNewMultipleWindows = By.XPath("//a[text()='Open multiple pages']");
        private By LinkToOpenWindow = By.CssSelector("a");
        
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

        public W2aFramesAndWindowsPage GoToNewWindowTab()
        {
            Driver.FindElement(OpenNewWindowTab).Click();
            return this;
        }
        public W2aFramesAndWindowsPage SwitchToNewWindowFrame()
        {
            Driver.SwitchTo().Frame(Driver.FindElement(NewWindowFrame));
            return this;
        }

        public W2aFramesAndWindowsPage ClickToLinkToNewBrowserTab()
        {
            Driver.FindElement(LinkToNewBrowserTab).Click();
            return this;
        }

        public W2aFramesAndWindowsPage GoToMultipleWindowsTab()
        {
            Driver.FindElement(OpenMultipleWindowsTab).Click();
            return this;
        }

        public W2aFramesAndWindowsPage SwitchToMoltipleWindowsFrame()
        {
            Driver.SwitchTo().Frame(Driver.FindElement(MultipleWindowsFrame));
            return this;
        }

        public W2aFramesAndWindowsPage ClickToLinkToNewMultipleWindows()
        {
            Driver.FindElement(LinkToNewMultipleWindows).Click();
            return this;
        }

        public W2aFramesAndWindowsPage ClickToLinkToOpenWindow()
        {
            Driver.FindElement(LinkToOpenWindow).Click();
            return this;
        }
    }
}
