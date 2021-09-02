using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTests.Pages
{
    class LoginForm : BasePage
    {
        By enterButtonOnMainPageLocator = By.XPath("//*[@data-statlog='notifications.mail.logout.enter']");
        By loginFormLocator = By.ClassName("Textinput-Control");
        By passwdFormLocator = By.Name("passwd");
        By enterButtonOnLoginFormLocator = By.XPath("//*[@data-t='button:action:passp:sign-in']");


        string email = ConfigurationManager.AppSettings["email"];
        string password = ConfigurationManager.AppSettings["password"];

        public void Authorization()
        {
             ButtonClick(enterButtonOnMainPageLocator);
            EnterLogin();
            ButtonClick(enterButtonOnLoginFormLocator);
            EnterPassword();
            ButtonClick(enterButtonOnLoginFormLocator);
        }

        public void EnterLogin()
        {
            SendKeys(loginFormLocator, email);
        }
        public void EnterPassword()
        {
            SendKeys(passwdFormLocator, password);
        }
    }
}
