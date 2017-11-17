using OpenQA.Selenium.Remote;

namespace UnitTestScreen
{
    public class BasePage
    {
        public RemoteWebDriver Driver { get; set; }

        public BasePage()
        {
        }

        public BasePage(RemoteWebDriver driver)
        {
            Driver = driver;
        }
    }
}
