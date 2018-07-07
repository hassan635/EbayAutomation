using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EbayAutomation.Model;

namespace EbayAutomation.Helpers
{
    public static class DynamicNavigationFactory
    {
        public static INavigationValidator Create(string className)
        {
            var type = Type.GetType($"EbayAutomation.Model.{className}NavigationValidator");
            INavigationValidator instance = (INavigationValidator)Activator.CreateInstance(type, new object[] { DriverFactory.GetCurrentDriver() });
            return instance;
        }
    }

}
