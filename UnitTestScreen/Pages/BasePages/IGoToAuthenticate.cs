using OpenQA.Selenium.Remote;

namespace UnitTestScreen
{
    public interface IGoToAuthenticate
    {
        RemoteWebDriver Driver { get; set; }
        IBaseLoginPage GoToLoginPage();
    }
}
