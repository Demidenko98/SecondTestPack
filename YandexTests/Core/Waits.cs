using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTests.Core
{
    class Waits
    {
        IWebDriver insDriver = DriverWrapper.GetInstance().CurrentDriver;
        public IWebElement ElementIsVisible(By locator)
        {


            //DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            //fluentWait.Timeout = TimeSpan.FromSeconds(10);
            //fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            //fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            //return fluentWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));

            WebDriverWait wait = new WebDriverWait(insDriver, TimeSpan.FromSeconds(15));
            IWebElement searchResult = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
            return searchResult;
        }

        public IWebElement ElementIsClickable(By locator)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(insDriver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return fluentWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }


    }
}
