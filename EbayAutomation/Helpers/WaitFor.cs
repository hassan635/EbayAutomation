using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace EbayAutomation.Helpers
{
    public static class Wait
    {
        private static WebDriverWait wait; 

        public static IWebElement For(IWebDriver driver, By locator, TimeSpan timeout)
        {
            wait = new WebDriverWait(driver, timeout);

            Func<IWebDriver, IWebElement> waitForElement = (IWebDriver Web) =>
            {
                IWebElement element = Web.FindElement(locator);
                if (element.Displayed)
                {
                    return element;
                }
                return null;
            };

            IWebElement targetElement = wait.Until(waitForElement);
            throw new WebDriverTimeoutException("Element not visible in the expected time.");
        }

        
    }
}
