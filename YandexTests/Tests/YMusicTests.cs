using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using YandexTests.Pages;
using YandexTests.Core;

namespace YandexTests.Tests
{
    public class YMusicTests: BaseTests
    {
       

        string metallicaSearch = Variables.metallicaSearch;
            string beyonceSearch = Variables.beyonceSearch;


        //    private readonly ITestOutputHelper output;

        ////private YMusicTests(ITestOutputHelper output)
        ////{
        ////    this.output = output;
        ////}

        [Fact]
        public void CheckMetallicaInPopularAlbums()
        {
            BasePage basePage = new BasePage();
            MusicPage musicPage = new MusicPage();
            MainPage mainPage = new MainPage();
            basePage.ButtonClick(mainPage.musicButtonOnMainPage);
            basePage.GoToFrame(1);
            musicPage.ExecuteSearchRequestOnMusicPage(metallicaSearch);
            Thread.Sleep(1000);  //Webdriver works too fast and some elements are shown, but with another values, so i need to wait some time the needed elements have correct values
            string[] ExpectedArtistsOfPopularAlbums = new string[8] 
            { "Metallica", "Metallica", 
              "Metallica", "Metallica", 
              "J. Balvin, Metallica", 
              "Metallica", "Metallica",
              "Metallica" 
            };

           string[]ActualArtistsOfPopularAlbums = musicPage.GetArtistOfPopularAlbumsOnPage();
           Assert.Equal(ExpectedArtistsOfPopularAlbums, ActualArtistsOfPopularAlbums);   //Comparing ExpectedArtistsOfPopularAlbums with ActualArtistsOfPopularAlbums
        }


        [Fact]
        public void MetallicaIsArtirt()
        {
            BasePage basePage = new BasePage();
            MusicPage musicPage = new MusicPage();
            MainPage mainPage = new MainPage();
            basePage.ButtonClick(mainPage.musicButtonOnMainPage);
            basePage.GoToFrame(1);
            musicPage.ExecuteSearchRequestOnMusicPage(metallicaSearch);
            Thread.Sleep(1000);
            string actualArtistName = musicPage.GetArtistName();
            Assert.Equal("Metallica", actualArtistName);  //Checking actualArtistName is Metallica
        }

        [Fact]
        public void SongIsPlaying()
        {
            BasePage basePage = new BasePage();
            MusicPage musicPage = new MusicPage();
            MainPage mainPage = new MainPage();
            basePage.ButtonClick(mainPage.musicButtonOnMainPage);
            basePage.GoToFrame(1);
            musicPage.ExecuteSearchRequestOnMusicPage(beyonceSearch);
            Thread.Sleep(1000);
            musicPage.CheckSongIsPlaying();  //Check the song is playing(play locator became pause locator)
            Thread.Sleep(4000);
        }

        [Fact]
        public void SongIsPaused()
        {
            BasePage basePage = new BasePage();
            MusicPage musicPage = new MusicPage();
            MainPage mainPage = new MainPage(); 
            basePage.ButtonClick(mainPage.musicButtonOnMainPage);
            basePage.GoToFrame(1);
            musicPage.ExecuteSearchRequestOnMusicPage(beyonceSearch);
            Thread.Sleep(1000);
            musicPage.CheckSongIsPaused(); //Check the song is paused(paused locator became play locator)
        }

    }
}
