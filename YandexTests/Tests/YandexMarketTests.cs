using OpenQA.Selenium;
using YandexTests.Pages;
using YandexTests.Core;
using System.Threading;
using Xunit;


namespace YandexTests.Tests
{
  
    public class YandexMarketTests: IClassFixture<BaseTests>
    {     
        BasePage basePage = new BasePage();
        MarketPage marketPage = new MarketPage();
        MainPage mainPage = new MainPage();
  
        [Fact]
        public void AddAndCompareTwoProduct()
        {
            basePage.ButtonClick(mainPage.marketButtonOnMainPage);
            Thread.Sleep(3000); //Yandex estimates WebDriver as a robot and adds captcha checks, so I need to make tests a bit slower 
            basePage.GoToFrame(1);
            marketPage.SearchProductOnMarket("Note 8");
            marketPage.AddTwoProductsToCompare();
            marketPage.SwitchToTheComparePage();
            marketPage.CheckProdutcAreDisplayedOnComparePage();  // Check two products are added to comparing
        }


        [Fact]
        public void ProductsAreDeletedFromComparing()
        {
            basePage.ButtonClick(mainPage.marketButtonOnMainPage);
            Thread.Sleep(3000);
            basePage.GoToFrame(1);
            marketPage.SearchProductOnMarket("Note 8");
            marketPage.AddTwoProductsToCompare();
            marketPage.SwitchToTheComparePage();
            marketPage.CheckProdutcAreDisplayedOnComparePage();
            marketPage.DeleteProductsFromComparePage();
            string actualTextOfDeletedItemsFromComparing = marketPage.CheckProductsAreDeletedFromComparePage();
            Assert.Equal("Сравнивать пока нечего", actualTextOfDeletedItemsFromComparing);  // Check two products are deleted from comparing
        }


        [Fact]
        public void CheckProductsAreSortedByPrice()
        {
            basePage.ButtonClick(mainPage.marketButtonOnMainPage);
            Thread.Sleep(3000);
            basePage.GoToFrame(1);
            marketPage.SwitchToTheElectronicPageAndOpenCameras();
            string actualFirstCameraPrice = marketPage.SortByPriceAndCheckResult();
            Assert.Equal("180 грн", actualFirstCameraPrice);   //Check action cameras are sorted by price and the first element has a price 180 грн
        }

        [Fact]
        public void CheckProductsAreSortedByTag()
        {
            basePage.ButtonClick(mainPage.marketButtonOnMainPage);
            Thread.Sleep(3000);
            basePage.GoToFrame(1);
            marketPage.SwitchToTheBytovaiaTechPageAndOpenRefrigerators();
            string actualFirstRefrigeratorPrice = marketPage.SortByWidthTagAndCheckResult();
            Assert.Equal("31 715 грн", actualFirstRefrigeratorPrice);   //Check refrigerators are sorted by width tag and the first element has a price 31 715 грн
        }


    }
}
