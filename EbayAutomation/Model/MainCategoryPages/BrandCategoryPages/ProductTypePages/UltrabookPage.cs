using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using EbayAutomation.Helpers;

namespace EbayAutomation.Model
{
    public class UltrabookPage : BasePage, IProductTypePage
    {
        private IWebDriver _driver;

        IWebElement _firstListingLinks => _driver.FindElement(By.CssSelector("li#w7-items[0] > div > div.s-item__info clearfix > a"));

        private IProductPage _product;

        public string productTypeName => "Ultrabook";

        public UltrabookPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IProductTypePage Load()
        {
            _driver.Navigate().GoToUrl("");
            return this;
        }

        public IProductPage SelectProduct(Type productPage)
        {
            _firstListingLinks.Click();
            return (IProductPage)DynamicPageFactory.Create(productPage);
        }

        public BasePage SelectFirstListing()
        {
            _firstListingLinks.Click();
            return DynamicPageFactory.Create(typeof(ProductPage));
        }
    }
}
