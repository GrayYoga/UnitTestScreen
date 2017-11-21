using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace UnitTestScreen
{
    public class W2aAlertsPage : BasePage, IGoToAuthenticate
    {
        private By OpenInputAlertTab = By.CssSelector("a[href = '#example-1-tab-2']");
        private By InputAlertFrame = By.CssSelector("iframe[src = 'alert/input-alert.html']");
        private By Button = By.CssSelector("button");
        private By DemoText = By.Id("demo");

        public W2aAlertsPage(RemoteWebDriver driver) : base(driver)
        {
        }

        public W2aAlertsPage() : base()
        {
        }

        public IBaseLoginPage GoToLoginPage()
        {
            return new W2aLoginPage(Driver).GoToLoginPage();
        }

        public W2aAlertsPage GoToInputAlertTab()
        {
            Driver.FindElement(OpenInputAlertTab).Click();
            return this;
        }

        public W2aAlertsPage SwitchToInputAlertFrame()
        {
            Driver.SwitchTo().Frame(Driver.FindElement(InputAlertFrame));
            return this;
        }

        public W2aAlertsPage ClickButton()
        {
            Driver.FindElement(Button).Click();
            return this;
        }

        public W2aAlertsPage OpenAlertAndInputCustomText(string customText)
        {
            try
            {
                Driver.FindElement(InputAlertFrame).Click();
            }
            catch (UnhandledAlertException)
            {
                var alert = Driver.SwitchTo().Alert();
                alert.SendKeys(customText);
                alert.Accept();
            }
            return this;
        }

        public string GetDemoText()
        {
            return Driver.FindElement(DemoText).Text;
        }
    }
}
