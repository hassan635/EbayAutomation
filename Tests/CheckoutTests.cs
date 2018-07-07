using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using EbayAutomation;
using EbayAutomation.Model;
using EbayAutomation.Helpers;
using System.IO;
using LumenWorks.Framework.IO.Csv;

namespace Tests
{
    [TestFixture]
    public class CheckoutTests : BaseTest
    {
        [Test, TestCaseSource("GetTestCaseData")]
        public void Search_And_Select_Item_To_Checkout(Type mainCategory, Type brandCategory, Type productType, Type product)
        {
            INavigationValidator topNavigationValidator = DynamicNavigationFactory.Create(typeof(TopNavigationValidator));

            SignInPage signInPage = (SignInPage)DynamicPageFactory.Create(typeof(SignInPage));

            signInPage.Load();
            
            HomePage homePage = (HomePage)signInPage.PerformSignIn(Config.Username, Config.Password);

            //Varify top navigation links when on Home page
            Assert.True(topNavigationValidator.Verify());

            IMainCategoryPage pcLaptopsNotebooksPage = homePage.OpenCategoryMenuAndSelectCategory(mainCategory);

            //Varify top navigation links when on Main catogory page
            Assert.True(topNavigationValidator.Verify());

            IBrandCategoryPage hpPage = pcLaptopsNotebooksPage.SelectBrandCategory(brandCategory);

            //Varify top navigation links when on Brand Category page
            Assert.True(topNavigationValidator.Verify());

            IProductTypePage ultraBookPage = hpPage.SelectProductType(productType);

            //Varify top navigation links when on Product Type page
            Assert.True(topNavigationValidator.Verify());

            IProductPage itemPage = ultraBookPage.SelectProduct(product);

            //Varify top navigation links when on Product page
            Assert.True(topNavigationValidator.Verify());

            ICheckOutPage checkOutPage = itemPage.BuyProduct(typeof(DefaultCheckoutPage));

            checkOutPage.PerformCheckout(typeof(HomePage));
        }

        public static IEnumerable<Type[]> GetTestCaseData()
        {
            using (var csv = new CsvReader(new StreamReader(AppDomain.CurrentDomain.BaseDirectory + ".\\test-data.csv"), true))
            {
                while (csv.ReadNextRecord())
                {
                    Type mainCategory = Type.GetType(csv[0].ToString());
                    Type brandCategory = Type.GetType(csv[1].ToString());
                    Type productType = Type.GetType(csv[2].ToString());
                    Type product = Type.GetType(csv[3].ToString());
                    yield return new[] { mainCategory, brandCategory, productType, product };
                }
            }
        }
    }
}
