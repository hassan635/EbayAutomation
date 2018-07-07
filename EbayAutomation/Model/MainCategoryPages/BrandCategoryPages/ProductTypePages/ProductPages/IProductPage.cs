using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbayAutomation.Model
{
    public interface IProductPage
    {
        IProductPage Load();

        ICheckOutPage BuyProduct(Type checkoutMethodPage);
    }
}
