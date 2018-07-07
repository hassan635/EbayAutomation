using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace EbayAutomation.Model
{
    public enum Page
    {
        HomePage,
        SignInPage,
    }
    public static class PageFactory
    {
        //private static IWebDriver _driver => DriverFactory.GetCurrentDriver();

        //public static BasePage Make(Page page)
        //{
        //    switch (page)
        //    {
        //        case Page.HomePage:
        //            return new HomePage(_driver);
        //        case Page.SignInPage:
        //            return new SignInPage(_driver);
        //        default:
        //            throw new Exception("Page not supported");
        //    }
        //}
    }
}
