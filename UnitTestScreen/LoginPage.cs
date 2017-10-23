using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestScreen
{
    public class LoginPage
    {
        private RemoteWebDriver Driver;

        By User = By.CssSelector(@"#user_email");
        By Password = By.CssSelector(@"#user_password");
        By LoginButton = By.CssSelector(@"#new_user input.login-button");

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
