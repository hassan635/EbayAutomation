using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using EbayAutomation;
using System.IO;
using LumenWorks.Framework.IO.Csv;

namespace Tests
{
    public abstract class BaseTest
    {
        [SetUp, TestCaseSource("GetBrowserConfigData")]
        protected virtual void SetUp(string browserName)
        {
            switch(browserName)
            {
                case "Chrome":
                    DriverFactory.MakeDriver(BrowserType.Chrome);
                    break;
                case "Firefox":
                    DriverFactory.MakeDriver(BrowserType.Firefox);
                    break;
                case "Edge":
                    DriverFactory.MakeDriver(BrowserType.Edge);
                    break;
            }
            
        }

        [TearDown]
        protected virtual void TearDown()
        {
            DriverFactory.DisposeDriver();
        }

        protected static IEnumerable<string[]> GetBrowserConfigData()
        {
            using (var csv = new CsvReader(new StreamReader("browser-config.csv"), true))
            {
                while (csv.ReadNextRecord())
                {
                    string browserName = csv[0].ToString();
                    yield return new[] { browserName };
                }
            }
        }
    }
}
