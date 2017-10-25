using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace UnitTestScreen
{
    public class MainPage
    {
        private RemoteWebDriver Driver;

        private By Sign_in = By.CssSelector(@"#navbar a[href='/sign_in']");
        private By Avatar = By.CssSelector(@"#navbar img.gravatar");

        public MainPage(RemoteWebDriver driver)
        {
            Driver = driver;
        }

        public LoginPage GoToLoginPage()
        {
            Driver.FindElement(Sign_in).Click();
            return new LoginPage(Driver);
        }
        
        public IWebElement GetAvatar()
        {
            return Driver.FindElement(Avatar);
        }
    }
}
