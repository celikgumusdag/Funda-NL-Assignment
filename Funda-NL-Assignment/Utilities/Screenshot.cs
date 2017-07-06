using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Drawing.Imaging;
using System.IO;
using TechTalk.SpecFlow;
using System.Net;
using System.Drawing;
using System.Text;


namespace Funda_NL_Assignment.Utilities
{
    public static class Screenshot
    {
        public static void TakeScreenshot(IWebDriver driver)
        {
            try
            {
                string fileNameBase = string.Format(DateTime.Now.ToString("yyyyMMdd_HHmmss"));
                string cur = AppDomain.CurrentDomain.BaseDirectory;
                cur = cur + "../../";
                var artifactDirectory = Path.Combine(cur + "\\TestResults", "Screenshots");
                if (!Directory.Exists(artifactDirectory))
                    Directory.CreateDirectory(artifactDirectory);

                ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;

                if (takesScreenshot != null)
                {
                    var screenshot = takesScreenshot.GetScreenshot();
                    string screenshotFilePath = Path.Combine(artifactDirectory, fileNameBase + "_screenshot.png");
                    screenshot.SaveAsFile(screenshotFilePath, ImageFormat.Jpeg);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while taking screenshot: {0}", ex);
            }
        }
    }
}
