using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.IO;

namespace UnitTestScreen
{
    public class ScreenshotHelper
    {
        private RemoteWebDriver RemoteWebDriver;

        private string TakeScreenshot(string screenshotDirectoryPath)
        {
            var screenshot = ((ITakesScreenshot)RemoteWebDriver).GetScreenshot();
            var directoryPath = $"{screenshotDirectoryPath}\\images";
            Directory.CreateDirectory(directoryPath);
            var filePath = $"{directoryPath}\\{DateTime.Now.ToString("yyyyMMdd-HHmmss")}" +
                $"-{Guid.NewGuid()}.png";
            screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
            return filePath;
        }

        private string TakeB64Screenshot()
        {
            var screenshot = ((ITakesScreenshot)RemoteWebDriver).GetScreenshot();
            return screenshot.AsBase64EncodedString;
        }

        public ScreenshotHelper(RemoteWebDriver remoteWebDriver)
        {
            RemoteWebDriver = remoteWebDriver;
        }

        public string TakeScreenshotAndGetLink(string screenshotDirectoryPath)
        {
            string filePath = TakeScreenshot(screenshotDirectoryPath);
            filePath = filePath.Replace('\\', '/').Replace(':', '|');
            return $"<a href = \"file://{filePath}\" target = \"_blank\"> " +
                $"<img src = \"file://{filePath}\" alt = \"Screensot\" width = \"100%\" ></a><br>";
        }

        public string TakeScreenshotAndGetBase64Link()
        {
            string fileContent = TakeB64Screenshot();
            return $"<a href = \"data:image/png;base64,{fileContent}\" target = \"_blank\"> " +
                $"<img src = \"data:image/png;base64,{fileContent}\" alt = \"Screensot\" width=\"100%\" ></a><br>";
        }
    }
}
