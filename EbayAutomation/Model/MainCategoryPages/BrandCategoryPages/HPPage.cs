using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using EbayAutomation.Helpers;

namespace EbayAutomation.Model
{
    public class HPPage : BasePage, IBrandCategoryPage
    {
        private IWebDriver _driver;
        private IReadOnlyCollection<IWebElement> _typeLinks => _driver.FindElements(By.CssSelector("div#w5-xCarousel-x-carousel-items > ul > li > a"));

        public HPPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IBrandCategoryPage Load()
        {
            _driver.Navigate().GoToUrl("https://www.ebay.com.au/");
            return this;
        }


        public IProductTypePage SelectProductType(string typeName)
        {
            //Using JS to manupilate display attribute
            //IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;
            //executor.ExecuteScript("document.getElementById('gh-sbc-o').style.display='block';‌​");
            _driver.Navigate().GoToUrl("https://www.ebay.com.au/b/Computers-Tablets-Network-Hardware/58058/bn_1843425");


            foreach (IWebElement type in _typeLinks)
            {
                if (type.Text == typeName)
                {
                    type.Click();
                }
                else
                {
                    continue;
                }
            }
            return (IProductTypePage)DynamicPageFactory.Create(typeName);
        }
    }
}
