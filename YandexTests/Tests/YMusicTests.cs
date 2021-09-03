using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using YandexTests.Pages;

namespace YandexTests.Tests
{
    public class YMusicTests: IClassFixture<BaseTests>
    {
        BasePage basePage = new BasePage();
        MusicPage musicPage = new MusicPage();
        MainPage mainPage = new MainPage();

        private readonly ITestOutputHelper output;

       

        public YMusicTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void CheckMetallicaInPopularAlbums()
        {
            basePage.ButtonClick(mainPage.musicButtonOnMainPage);
            basePage.GoToFrame(1);
            musicPage.ExecuteSearchRequestOnMusicPage("Metallica");
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
            basePage.ButtonClick(mainPage.musicButtonOnMainPage);
            basePage.GoToFrame(1);
            musicPage.ExecuteSearchRequestOnMusicPage("Metallica");
            Thread.Sleep(1000);
            string actualArtistName = musicPage.GetArtistName();
            Assert.Equal("Metallica", actualArtistName);  //Checking actualArtistName is Metallica
        }

        [Fact]
        public void SongIsPlaying()
        {
            basePage.ButtonClick(mainPage.musicButtonOnMainPage);
            basePage.GoToFrame(1);
            musicPage.ExecuteSearchRequestOnMusicPage("beyo");
            Thread.Sleep(1000);
            musicPage.CheckSongIsPlaying();  //Check the song is playing(play locator became pause locator)
            Thread.Sleep(4000);
        }

        [Fact]
        public void SongIsPaused()
        {
            basePage.ButtonClick(mainPage.musicButtonOnMainPage);
            basePage.GoToFrame(1);
            musicPage.ExecuteSearchRequestOnMusicPage("beyo");
            Thread.Sleep(1000);
            musicPage.CheckSongIsPaused(); //Check the song is paused(paused locator became play locator)
        }

    }
}
