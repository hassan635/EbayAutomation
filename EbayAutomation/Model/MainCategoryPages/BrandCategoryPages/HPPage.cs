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

        private IProductTypePage _productType;
        public string brandCategoryName => "HP";

        public HPPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IBrandCategoryPage Load()
        {
            _driver.Navigate().GoToUrl("https://www.ebay.com.au/");
            return this;
        }


        public IProductTypePage SelectProductType(Type typeName)
        {
            _productType = (IProductTypePage)typeName;

            foreach (IWebElement type in _typeLinks)
            {
                if (type.Text == _productType.productTypeName)
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
