using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using EbayAutomation.Helpers;

namespace EbayAutomation.Model
{
    public class DefaultCheckoutPage : BasePage, ICheckOutPage
    {
        private IWebDriver _driver;

        public DefaultCheckoutPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public BasePage PerformCheckout(string ReturnPageName)
        {
            //Add checkout logic here
            return DynamicPageFactory.Create(ReturnPageName);
        }
    }
}
