using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestScreen
{
    public interface IGoToAuthenticate
    {
        RemoteWebDriver Driver { get; set; }
        IBaseLoginPage GoToLoginPage();
    }
}
