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
        public void Search_And_Select_Item_To_Checkout2(string mainCategory, string brandCategory, string productType, string product)
        {
            INavigationValidator topNavigationValidator = DynamicNavigationFactory.Create("Top");

            SignInPage signInPage = (SignInPage)DynamicPageFactory.Create("SignIn");

            signInPage.Load();

            //REMEMBER TO REMOVE CREDENTIALS AND MENTION IN COMMENTS TO GRABS IT FROM CONFIG FILE
            HomePage homePage = (HomePage)signInPage.PerformSignIn(Config.Username, Config.Password);

            //Varify top navigation links when on Home page
            Assert.True(topNavigationValidator.Verify());

            IMainCategoryPage pcLaptopsNotebooksPage = (IMainCategoryPage)homePage.OpenCategoryMenuAndSelectCategory(mainCategory);

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

            ICheckOutPage checkOutPage = itemPage.BuyProduct("DefaultCheckout");

            checkOutPage.PerformCheckout(typeof(HomePage).ToString());
        }

        public static IEnumerable<string[]> GetTestCaseData()
        {
            using (var csv = new CsvReader(new StreamReader(AppDomain.CurrentDomain.BaseDirectory + ".\\test-data.csv"), true))
            {
                while (csv.ReadNextRecord())
                {
                    string mainCategory = csv[0].ToString();
                    string brandCategory = csv[1].ToString();
                    string productType = csv[2].ToString();
                    string product = csv[3].ToString();
                    yield return new[] { mainCategory, brandCategory, productType, product };
                }
            }
        }
    }
}
