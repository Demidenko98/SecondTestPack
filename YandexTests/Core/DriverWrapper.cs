using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTests.Core
{
    class DriverWrapper
    {
        private IWebDriver driver;
        string url = ConfigurationManager.AppSettings["URL"];

        private static readonly Lazy<DriverWrapper> lazy =
     new Lazy<DriverWrapper>(() => new DriverWrapper());

        public IWebDriver CurrentDriver => GetDriver();

        public IWebDriver GetDriver()
        {

            if (driver == null)
            {
                driver = new ChromeDriver();

                driver.Url = url;

                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static DriverWrapper GetInstance()
        {
            return lazy.Value;
        }

        public string GetUrl()
        {
            return driver.Url;
        }

        public void Quit()
        {

            if (driver == null)
                return;

            else
            {
                driver.Quit();
                driver = null;
            }

        }

    }
}

