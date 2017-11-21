using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;

namespace UnitTestScreen
{
    public class W2aLoginPage : BasePage , IBaseLoginPage
    {
        private By SignInRef = By.CssSelector("div#load_box a[href='#login']");
        private By DivLogin = By.CssSelector("div#login");
        private By User = By.CssSelector("div#login input[name='username']");
        private By Password = By.CssSelector("div#login input[name='password']");
        private By LoginButton = By.CssSelector("div#login input[type='submit']");
        private By ErrorAuthAlert = By.CssSelector("p#alert1");

        public W2aLoginPage(RemoteWebDriver driver) : base (driver)
        {
        }

        public W2aLoginPage () : base ()
        {
        }

        public IBaseLoginPage GoToLoginPage()
        {
            Driver.FindElement(SignInRef).Click();
            new WebDriverWait(Driver, TimeSpan.FromSeconds(10))
                .Until(drv => Driver.FindElement(DivLogin).Displayed);
            return this;
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
