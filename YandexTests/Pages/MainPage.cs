using OpenQA.Selenium;

namespace YandexTests.Pages
{
    class MainPage
    {
        public readonly By marketButtonOnMainPage = By.XPath("//*[@data-id='market']");
        public readonly By musicButtonOnMainPage = By.XPath("//*[@data-id='music']");
    }
}
