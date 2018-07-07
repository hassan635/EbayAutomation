using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using EbayAutomation.Helpers;

namespace EbayAutomation.Model
{
    public class PCLaptopsNotebooksPage : BasePage, IMainCategoryPage
    {
        private IWebDriver _driver;
        private IReadOnlyCollection<IWebElement> _brandLinks => _driver.FindElements(By.CssSelector("div#w5-xCarousel-x-carousel-items > ul > li > a"));

        private IBrandCategoryPage _brandCategory;
        public string mainCategoryName => "PCLaptopsNotebooks";

        public PCLaptopsNotebooksPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IMainCategoryPage Load()
        {
            _driver.Navigate().GoToUrl("https://www.ebay.com.au/");
            return this;
        }


        public IBrandCategoryPage SelectBrandCategory(Type brandNamePage)
        {
            //Using JS to manupilate display attribute
            //IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;
            //executor.ExecuteScript("document.getElementById('gh-sbc-o').style.display='block';‌​");
            _driver.Navigate().GoToUrl("https://www.ebay.com.au/b/Computers-Tablets-Network-Hardware/58058/bn_1843425");

            _brandCategory = (IBrandCategoryPage)brandNamePage;

            foreach (IWebElement brand in _brandLinks)
            {
                if (brand.Text == _brandCategory.brandCategoryName)
                {
                    brand.Click();
                }
                else
                {
                    continue;
                }
            }
            return (IBrandCategoryPage)DynamicPageFactory.Create(brandNamePage);
        }
    }
}
