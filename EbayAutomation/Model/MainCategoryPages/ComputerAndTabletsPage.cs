using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using EbayAutomation.Helpers;

namespace EbayAutomation.Model
{
    public class ComputerAndTabletsPage : BasePage
    {
        private IWebDriver _driver;
        private IReadOnlyCollection<IWebElement> _categoryLinks => _driver.FindElements(By.CssSelector("div.b-visualnav__grid > a"));

        public ComputerAndTabletsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public ComputerAndTabletsPage Load()
        {
            _driver.Navigate().GoToUrl(Config.baseUrl + "");
            return this;
        }


        public BasePage SelectComputerOrTabletCategory(string categoryName)
        {
            //Using JS to manupilate display attribute
            //IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;
            //executor.ExecuteScript("document.getElementById('gh-sbc-o').style.display='block';‌​");
            _driver.Navigate().GoToUrl("https://www.ebay.com.au/b/Computers-Tablets-Network-Hardware/58058/bn_1843425");


            foreach (IWebElement category in _categoryLinks)
            {
                if (category.Text == categoryName)
                {
                    category.Click();
                }
                else
                {
                    continue;
                }
            }
            return DynamicPageFactory.Create(categoryName);
        }
    }
}
