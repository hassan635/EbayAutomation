using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace EbayAutomation
{
    public enum BrowserType
    {
        Firefox,
        Chrome,
        Edge
    }
    public static class DriverFactory
    {
        private static IWebDriver _driver = null;
        public static IWebDriver MakeDriver(BrowserType type)
        {
            switch (type)
            {
                case BrowserType.Chrome:
                    {
                        if (_driver == null)
                        {
                            _driver = new ChromeDriver();
                            return _driver;
                        }
                        return _driver;
                    }
                case BrowserType.Firefox:
                    {
                        if (_driver == null)
                        {
                            _driver = new FirefoxDriver();
                            return _driver;
                        }
                        return _driver;
                    }
                case BrowserType.Edge:
                    {
                        if (_driver == null)
                        {
                            _driver = new EdgeDriver();
                            return _driver;
                        }
                        return _driver;
                    }
                default:
                    throw new Exception("Driver already instantiated as " + type.ToString());
            }
        }
        
        public static void ConfigureDriver(params string[] Configs)
        {
            //use configs array to apply configs on the driver instance.
        }
        public static IWebDriver GetCurrentDriver()
        {
            return _driver;
        }

        public static void DisposeDriver()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
