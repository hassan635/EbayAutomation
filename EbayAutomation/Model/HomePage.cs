using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using EbayAutomation.Helpers;
using EbayAutomation.Model;

namespace EbayAutomation.Model
{
    public class HomePage : BasePage
    {
        private IWebDriver _driver;
        private IReadOnlyCollection<IWebElement> _categoryLinks => _driver.FindElements(By.CssSelector("table[id=\"gh-sbc\"] > tbody > tr > td > ul > li > a"));

        private IMainCategoryPage _categoryPage;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public HomePage Load()
        {
            _driver.Navigate().GoToUrl("https://www.ebay.com.au/");
            return this;
        }
        

        public IMainCategoryPage OpenCategoryMenuAndSelectCategory(Type categoryPageName)
        {
            _categoryPage = (IMainCategoryPage)categoryPageName;

            foreach (IWebElement category in _categoryLinks)
            {
                if (category.Text == _categoryPage.mainCategoryName)
                {
                    category.Click();
                }
                else
                {
                    continue;
                }
            }
            return (IMainCategoryPage)DynamicPageFactory.Create(categoryPageName);
        }
    }
    
}
