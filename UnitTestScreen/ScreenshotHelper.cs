using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.IO;

namespace UnitTestScreen
{
    public class ScreenshotHelper
    {
        private RemoteWebDriver _remoteWebDriver;

        public ScreenshotHelper(RemoteWebDriver remoteWebDriver)
        {
            _remoteWebDriver = remoteWebDriver;
        }
        private string TakeScreenshot(string screenshotDirectoryPath)
        {
            var screenshot = ((ITakesScreenshot)_remoteWebDriver).GetScreenshot();
            var directoryPath = $"{screenshotDirectoryPath}\\images";
            Directory.CreateDirectory(directoryPath);
            var filePath = $"{directoryPath}\\{DateTime.Now.ToString("yyyyMMdd-HHmmss")}-{Guid.NewGuid()}.png";
            screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
            return filePath;
        }
        private string TakeB64Screenshot()
        {
            var screenshot = ((ITakesScreenshot)_remoteWebDriver).GetScreenshot();
            return screenshot.AsBase64EncodedString;
        }
        public string TakeScreenshotAndGetLink(string screenshotDirectoryPath)
        {
            string filePath = TakeScreenshot(screenshotDirectoryPath);
            return $"<a href = \"file://{filePath.Replace('\\', '/').Replace(':', '|')}\" target = \"_blank\"> " +
                $"<img src = \"file://{filePath.Replace('\\', '/').Replace(':', '|')}\" alt = \"Screensot\" width = \"100%\" ></a><br>";
        }
        public string TakeScreenshotAndGetBase64Link()
        {
            string fileContent = TakeB64Screenshot();
            return $"<a href = \"data:image/png;base64,{fileContent}\" target = \"_blank\"> " +
                $"<img src = \"data:image/png;base64,{fileContent}\" alt = \"Screensot\" width=\"100%\" ></a><br>";
        }
    }
}
