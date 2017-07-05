using OpenQA.Selenium;
using Funda_NL_Assignment.Utilities;
using TechTalk.SpecFlow;
using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Funda_NL_Assignment.Helpers
{
    public class Base
    {
        public IWebDriver WebDriver { get; set; }

        public Base()
        {
            if (WebDriver == null)
            {
                WebDriver = DriverFactory.Current;
            }

        }

        protected static String read(String value)
        {
            var data = new System.Collections.Generic.Dictionary<string, string>();
            var thisPath = Environment.CurrentDirectory;
            foreach (var row in File.ReadAllLines(thisPath + "/Funda-NL-Assignment/Funda-NL-Assignment/Resources/css.properties"))
                data.Add(row.Split('=')[0], string.Join("=", row.Split('=').Skip(1).ToArray()));
            return data[value];
        }

        [BeforeScenario]
        protected void Open()
        {
            WebDriver.Navigate().GoToUrl(Constants.Url);
        }

        [AfterScenario]
        protected void Dispose()
        {
            WebDriver.Dispose();
        }

        protected void Wait(int second)
        {
            System.Threading.Thread.Sleep(second * 1000);
        }

        protected IWebElement FindElement(string css)
        {
            WaitForElementLoad(css, 10);
            IWebElement el = WebDriver.FindElement(By.CssSelector(css));
            return el;
        }

        protected void ClickElement(string css)
        {
            FindElement(css).Click();
        }

        protected void HighlightElement(string css)
        {
            IWebElement el = FindElement(css);
            IJavaScriptExecutor js = WebDriver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", el,
                " border: 3px solid red;");
        }

        protected string GetText(string css)
        {
            return FindElement(css).Text;
        }

        protected string GetValue(string css)
        {
            return FindElement(css).GetAttribute("value");
        }

        protected string GetUrl()
        {
            return WebDriver.Url;
        }

        protected void SetValue(string css, string key)
        {
            ClearValue(css);
            FindElement(css).SendKeys(key);
        }

        protected void ClearValue(string css)
        {
            FindElement(css).Clear();
        }

        protected void WaitForElementLoad(string element, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(element)));
            }

        }
        public static void WaitForLoad(IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            int timeoutSec = 15;
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeoutSec));
            wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

    }
}