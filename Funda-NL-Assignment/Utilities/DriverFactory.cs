using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Opera;

namespace Funda_NL_Assignment.Utilities
{
    public static class DriverFactory
    {
        public const string Key = "driver";

        public static IWebDriver Current
        {
            get
            {
                if (!ScenarioContext.Current.ContainsKey(Key))
                {
                    IWebDriver driver = null;

                    switch (Constants.Browser)
                    {
                        case "firefox":
                            FirefoxProfile profile = new FirefoxProfile();
                            profile.SetPreference("funda-qa-test", "96ayx3hwm9yw8n9f");
                            driver = new FirefoxDriver(profile);
                            break;
                        case "chrome":
                            driver = new ChromeDriver();
                            break;
                        case "ie":
                            driver = new InternetExplorerDriver();
                            break;
                        case "safari":
                            driver = new SafariDriver();
                            break;
                        case "opera":
                            driver = new OperaDriver();
                            break;
                        case "phantom":
                            driver = new PhantomJSDriver();
                            break;
                        default:
                            //Could be error logging or precondition
                            break;
                    }

                    driver.Manage().Window.Maximize();
                    ScenarioContext.Current[Key] = driver;
                }

                return ScenarioContext.Current[Key] as IWebDriver;
            }
        }
    }
}