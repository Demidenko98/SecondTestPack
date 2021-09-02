using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YandexTests.Core;

namespace YandexTests.Pages
{
    class MarketPage : BasePage
    {
        public readonly By searchFormLocator = By.Id("header-search");
        public readonly By searchButton = By.ClassName("JqPid");
        public readonly By addCompareBtnFirstElement = By.XPath("//*[@class='_3U6u5 _1EDYE cia-vs']/article[1]/div/div[2]/div");
        public readonly By addCompareBtnSecondElement = By.XPath("//*[@class='_3U6u5 _1EDYE cia-vs']/article[2]/div/div[2]/div");
        public readonly By userIcon = By.ClassName("_3RDrv");
        public readonly By compareItemInDropdown = By.XPath("//*[@data-autotest-id='side-menu-item-comparison']");
        public readonly By textFirstElement = By.XPath("//*[@class='_3B3AA']/div[1]");
        public readonly By textSecondElement = By.XPath("//*[@class='_3B3AA']/div[2]");
        public readonly By deleteBtnOnComparePage = By.XPath("//*[@class='_1KpjX _1KU3s']");
        public readonly By textOnEmptyComparePage = By.ClassName("_2szVR");

        public readonly By electronicBtnOnMarketPage = By.XPath("//a[contains(@href,'catalog--elektronika/54440')]");
        public readonly By actionCamerasSectionBtnOnMarketPage = By.XPath("//a[contains(@href,'catalog--ekshn-kamery-v-dnepre/18041807')]");
        public readonly By watchAllProductsBtn = By.XPath("//*[@data-zone-name='action']/a");
        public readonly By sortByPriceBtn = By.XPath("//*[@data-autotest-id='dprice']");
        public readonly By firstCameraPrice = By.XPath("//*[@data-autotest-value='180']");

        public readonly By bytovaiaTechnikaBtnOnMarketPage = By.XPath("//*[@class='_35SYu _1vnug']/a[contains(@href,'/catalog--bytovaia-tekhnika/54419')]");
        public readonly By RefrigiratorsSectionBtnOnMarketPage = By.XPath("//a[contains(@href,'/catalog--kholodilniki-v-dnepre/71639/l')]");
        public readonly By widthTagOnRefrigiratorPage = By.Name("Ширина до");
        public readonly By firstRefrigeratorPrice = By.XPath("//*[@data-autotest-value='31']");

        public void SearchProductOnMarket(string searchRequestText)
        {
            SendKeys(searchFormLocator, searchRequestText);
            ButtonClick(searchButton);
        }

        public void AddTwoProductsToCompare()
        {
              ButtonClick(addCompareBtnFirstElement);
              ButtonClick(addCompareBtnSecondElement);
        }

        public void SwitchToTheComparePage()
        {
            ButtonClick(userIcon);
            ButtonClick(compareItemInDropdown);
            GoToFrame(1);
        }

        public void CheckProdutcAreDisplayedOnComparePage()
        {
            GetText(textFirstElement);
            GetText(textSecondElement);
        }

        public void DeleteProductsFromComparePage()
        {
            ButtonClick(deleteBtnOnComparePage);
        }

        public string CheckProductsAreDeletedFromComparePage()
        {
            return GetText(textOnEmptyComparePage);
        }

        public void SwitchToTheElectronicPageAndOpenCameras()
        {
            ButtonClick(electronicBtnOnMarketPage);
            ButtonClick(actionCamerasSectionBtnOnMarketPage);
            ButtonClick(watchAllProductsBtn);
           
        }

        public string SortByPriceAndCheckResult()
        {
            ButtonClick(sortByPriceBtn);
           return GetText(firstCameraPrice);
        }

        public void SwitchToTheBytovaiaTechPageAndOpenRefrigerators()
        {
            ButtonClick(bytovaiaTechnikaBtnOnMarketPage);
            ButtonClick(RefrigiratorsSectionBtnOnMarketPage);
        }

        public string SortByWidthTagAndCheckResult()
        {
            SendKeys(widthTagOnRefrigiratorPage, "50");
            return GetText(firstRefrigeratorPrice);
        }

    }
}
