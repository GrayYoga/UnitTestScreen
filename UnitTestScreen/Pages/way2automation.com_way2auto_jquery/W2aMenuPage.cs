using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;

namespace UnitTestScreen
{
    public class W2aMenuPage : BasePage, IGoToAuthenticate
    {
        private By MenuWithSubmenu = By.CssSelector("a[href = '#example-1-tab-2']");
        private By MenuFrame = By.CssSelector("iframe[src = 'menu/defult2.html']");
        private By MenuItenWithSubmenu = By.CssSelector("li[aria-haspopup='true']");
        private By Submenu = By.CssSelector("li[aria-haspopup='true'] ul[aria-expanded='true']");

        public W2aMenuPage(RemoteWebDriver driver) : base(driver)
        {
        }

        public W2aMenuPage() : base()
        {
        }

        public W2aMenuPage OpenMenuWithSubmenu()
        {
            Driver.FindElement(MenuWithSubmenu).Click();
            Driver.SwitchTo().Frame(Driver.FindElement(MenuFrame));
            return this;
        }
        
        public W2aMenuPage MoveCursorToMenuItemWithSubmenu()
        {
            var Builder = new Actions(Driver);
            Builder.MoveToElement(Driver.FindElement(MenuItenWithSubmenu)).Build().Perform();
            return this;
        }

        public bool SubmenuIsVisible()
        {
            return (Driver.FindElement(Submenu).Displayed);
        }

        public IBaseLoginPage GoToLoginPage()
        {
            return new W2aLoginPage(Driver).GoToLoginPage();
        }
    }
}
