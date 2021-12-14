using Lab_8_9.Models;
using Lab_8_9.Services;
using Lab_8_9.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lab_8_9.Tests
{
    [TestFixture]
    public class NeotourTests : CommonConditions
    {
        
        [Test]
        public void SearchToursTest()
        {
            var homePage = new HomePage(_driver).OpenPage();

            var testData = new TourSearchParameters
            {
                startLocationCountry = "Беларусь",
                startLocationCity = "Минск",
                destinationCountry = "Египет",
                earlierDepartureDate = 17,
                laterDepartureDate = 20,
                minNights = 7,
                maxNights = 12
            };

            homePage.TestSearchToursForm(new TourSearchButtonsXPaths(), testData);

            var expectedPageUrl = "https://neotour.by/podbor-tura?ts_dosearch=1&s_j_date_from=17.12.2021&s_j_date_to=20.12.2021&s_nights_from=7&s_nights_to=12&s_adults=2&s_country=1&s_flyfrom=57&s_currency=1&s_regular=2";
            var expectedPage = new Page(_driver, expectedPageUrl).OpenPage();
            
            Assert.AreEqual(homePage.CurrentUrl, expectedPage.CurrentUrl);
        }
        
        //[Test]
        //public void TestAddTourToSelection()
        //{
            //var tourSelectionPage = new TourSelectionPage(_driver).OpenPage();
            //tourSelectionPage.AddHotelToCompilation();
            //Assert.Pass();
        //}

        //[Test]
        //public void Test3()
        //{
        //    Assert.Pass();
        //}
        //[Test]
        //public void Test4()
        //{
        //    Assert.Pass();
        //}

        //[Test]
        //public void Test5()
        //{
        //    Assert.Pass();
        //}

        //[Test]
        //public void Test6()
        //{
        //    Assert.Pass();
        //}

        //[Test]
        //public void Test7()
        //{
        //    Assert.Pass();
        //}

        //[Test]
        //public void Test8()
        //{
        //    Assert.Pass();
        //}

        //[Test]
        //public void Test9()
        //{
        //    Assert.Pass();
        //}

        //[Test]
        //public void Test10()
        //{
        //    Assert.Pass();
        //}
    }
}