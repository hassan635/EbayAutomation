using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbayAutomation.Model
{
    public interface IMainCategoryPage
    {
        IMainCategoryPage Load();

        string mainCategoryName
        {
            get;
        }
        IBrandCategoryPage SelectBrandCategory(Type brandNamePage);

    }
}
