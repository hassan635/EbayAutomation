using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using EbayAutomation.Model;

namespace EbayAutomation.Helpers
{
    public static class DynamicPageFactory
    {
        public static BasePage Create(Type className, params BasePage[] additionalDependencies)
        {
            var type = Type.GetType($"EbayAutomation.Model.{className.Name}");
            BasePage instance = (BasePage)Activator.CreateInstance(type, new object[] { DriverFactory.GetCurrentDriver()}, additionalDependencies);
            return instance;
        }
    }
}
