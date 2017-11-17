using OpenQA.Selenium.Remote;

namespace UnitTestScreen
{
    public interface IBaseLoginPage
    {

        RemoteWebDriver Driver { get;  set; }

        IBaseLoginPage TypeUser(string username);

        IBaseLoginPage TypePassword(string password);

        void LoginButtonClick();
    }
}