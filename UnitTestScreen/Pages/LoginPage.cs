using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace UnitTestScreen
{
    public class LoginPage
    {
        private RemoteWebDriver Driver;

        private By User = By.Id("user_email");
        private By Password = By.Id("user_password");
        private By LoginButton = By.CssSelector(@"#new_user input.login-button");

        public LoginPage(RemoteWebDriver driver)
        {
            Driver = driver;
        }

        public LoginPage TypeUser(string userName)
        {
            Driver.FindElement(User).SendKeys(userName);
            return this;
        }

        public LoginPage TypePassword(string password)
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
