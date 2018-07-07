using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using EbayAutomation.Helpers;

namespace EbayAutomation.Model
{
    public class SignInPage : BasePage
    {
        private IWebDriver _driver;

        private IWebElement _username => _driver.FindElement(By.Id("userid"));
        private IWebElement _password => _driver.FindElement(By.Id("pass"));
        private IWebElement _signInButton => _driver.FindElement(By.Id("sgnBt"));
        public SignInPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public SignInPage Load()
        {
            _driver.Navigate().GoToUrl("https://signin.ebay.com.au");
            return this;
        }

        public BasePage PerformSignIn(string Username, string Password)
        {
            _username.SendKeys(Username);
            _password.SendKeys(Password);
            _signInButton.Click();
            return DynamicPageFactory.Create("Home");
        }

    }
}
