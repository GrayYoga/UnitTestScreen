using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace UnitTestScreen
{
    public class MainPage : BasePage, IGoToAuthenticate
    {
        private By SignIn = By.CssSelector(@"#navbar a[href='/sign_in']");
        private By Avatar = By.CssSelector(@"#navbar img.gravatar");

        public MainPage(RemoteWebDriver driver) : base(driver)
        {
        }
        public MainPage() : base ()
        {
        }

        public IBaseLoginPage GoToLoginPage()
        {
            Driver.FindElement(SignIn).Click();
            return new LoginPage(Driver);
        }
        
        public IWebElement GetAvatar()
        {
            return Driver.FindElement(Avatar);
        }

        public bool IsAutorized()
        {
            return (null != GetAvatar());
        }
    }
}
