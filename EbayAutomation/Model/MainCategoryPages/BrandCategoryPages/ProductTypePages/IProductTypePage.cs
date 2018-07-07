using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbayAutomation.Model
{
    public interface IProductTypePage
    {
        IProductTypePage Load();

        string productTypeName
        {
            get;
        }
        IProductPage SelectProduct(Type productPage);
    }
}
