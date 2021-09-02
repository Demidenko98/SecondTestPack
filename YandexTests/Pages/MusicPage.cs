using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YandexTests.Core;

namespace YandexTests.Pages
{
    class MusicPage : BasePage
    {
        IWebDriver insDriver = DriverWrapper.GetInstance().CurrentDriver;

        public readonly By clickToOpenSearchField = By.XPath("//*[@data-b='12']");
        public readonly By inputInSearchField = By.XPath("//*[@type='text']");
        public readonly By firstItemInDropdownInSearchField = By.XPath("//*[@class='d-suggest__items d-suggest__items_type_artist']/div[2]/a");
        public readonly By artistName = By.XPath("//*[@class='page-artist__title typo-h1 typo-h1_big']");
        public readonly By MainPlayMusicBtn = By.XPath("//*[@class='d-generic-page-head__main-actions']/button");
        public readonly By playMusicBtn = By.XPath("//*[@class='player-controls__btn deco-player-controls__button player-controls__btn_play']");
        public readonly By pauseMusicBtn = By.XPath("//*[@class='player-controls__btn deco-player-controls__button player-controls__btn_play player-controls__btn_pause']");

        public void ExecuteSearchRequestOnMusicPage(string searchText)
        {
            ButtonClick(clickToOpenSearchField);
            SendKeys(inputInSearchField, searchText);
            Thread.Sleep(900);
            ButtonClick(firstItemInDropdownInSearchField);
        }

        public string GetArtistName()
        {
            return GetText(artistName);
        }

        public string[] GetArtistOfPopularAlbumsOnPage()
        {

            IList<IWebElement> all = insDriver.FindElements(By.XPath("//*[@class='album__artist deco-typo-secondary typo-add']/span"));

            string[] allText = new string[all.Count];
            int i = 0;
            foreach (IWebElement element in all)
            {
                allText[i++] = element.Text;
            }

            return allText;

        }


        public void CheckSongIsPlaying()
        {
            ButtonClick(MainPlayMusicBtn);     //Start playing song on main play music button
            IsElementExists(pauseMusicBtn);    //Check play button locator has been changed to the pause button locator
        }

        public void CheckSongIsPaused()
        {
            ButtonClick(MainPlayMusicBtn);          //Start playing song on main play music button
            ButtonClick(pauseMusicBtn);
            IsElementExists(playMusicBtn);         // //Check pause button locator has been changed to the play button locator
        }

    } 
}
