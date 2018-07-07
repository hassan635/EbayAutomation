using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbayAutomation.Model
{
    public interface ICheckOutPage
    {
        BasePage PerformCheckout(string returnPageName);
    }
}
