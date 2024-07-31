using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.Utilities
{
    public class TakeScreenshot:GlobalHelper
    {
        public string Screenshot(IWebDriver driver)
        {
            string directoryPath = ConstantHelper.ScreenShotPath;
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            // Capture screenshot
            string screenshotPath = Path.Combine(directoryPath, $"screenshot_{DateTime.Now:yyyyMMddHHmmssfff}.png");
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(screenshotPath);
            return screenshotPath;

        }
    }
}
