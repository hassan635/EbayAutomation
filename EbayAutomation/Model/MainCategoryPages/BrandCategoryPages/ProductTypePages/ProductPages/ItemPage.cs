using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using EbayAutomation.Helpers;

namespace EbayAutomation.Model
{
    public class ItemPage : BasePage, IProductPage
    {
        private IWebDriver _driver;

        private IWebElement _buyNowButton => _driver.FindElement(By.Id("binBtn_btn"));

        public ItemPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IProductPage Load()
        {
            _driver.Navigate().GoToUrl("");
            return this;
        }

        public ICheckOutPage BuyProduct(string checkOutMethod)
        {
            _buyNowButton.Click();
            return (ICheckOutPage)DynamicPageFactory.Create(checkOutMethod);
        }

    }
}
