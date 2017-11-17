using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace UnitTestScreen
{
    public class LoginPage : BasePage, IBaseLoginPage
    {
        private By User = By.Id("user_email");
        private By Password = By.Id("user_password");
        private By LoginButton = By.CssSelector(@"#new_user input.login-button");

        public LoginPage(RemoteWebDriver driver) : base (driver)
        {
        }

        public LoginPage():base()
        {
        }

        public IBaseLoginPage TypeUser(string userName)
        {
            Driver.FindElement(User).SendKeys(userName);
            return this;
        }

        public IBaseLoginPage TypePassword(string password)
        {
            Driver.FindElement(Password).SendKeys(password);
            return this;
        }

        public void LoginButtonClick()
        {
            Driver.FindElement(LoginButton).Click();
        }
    }
}
