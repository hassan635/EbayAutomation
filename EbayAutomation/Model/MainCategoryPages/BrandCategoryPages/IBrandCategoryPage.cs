using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbayAutomation.Model
{
    public interface IBrandCategoryPage
    {
        IBrandCategoryPage Load();
        IProductTypePage SelectProductType(string typeName);
    }
}
