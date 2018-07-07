using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using EbayAutomation.Helpers;
using System.Net;
using System.Net.Http;

namespace EbayAutomation.Model
{
    public class TopNavigationValidator : INavigationValidator
    {
        private IWebDriver _driver;

        private HttpWebResponse _response;

        private List<string> _erroringLinks;

        private bool anyFailedLinks = false;

        private IReadOnlyCollection<IWebElement> _topNavigationLinks => _driver.FindElements(By.CssSelector("#gh-top > a"));

        public TopNavigationValidator(IWebDriver driver)
        {
            _driver = driver;
            _erroringLinks = new List<string>();
        }

        public bool Verify()
        {
            foreach (IWebElement naviLink in _topNavigationLinks)
            {
                String href = naviLink.GetAttribute("href");

                _response = HttpRequestDispatcher.Perform(href);

                if(_response.StatusCode == HttpStatusCode.OK)
                {
                    continue;
                }
                else
                {
                    _erroringLinks.Add(href);
                    continue;
                }
            }

            if (_erroringLinks.Count == 0)
                return true;
            else
            return false;
        }
    }
}
