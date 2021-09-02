using System;
using NUnit.Framework;
using OpenQA.Selenium;
using Xunit.Abstractions;
using YandexTests.Core;
using YandexTests.Pages;

namespace YandexTests
{
  
    public class BaseTests : IDisposable
    {
        IWebDriver InsDriver = DriverWrapper.GetInstance().CurrentDriver;

        public BaseTests()
        {
            new LoginForm().Authorization();
        }

    
        public void Dispose()
        {
          //  InsDriver.Close();
        }
    }
}
