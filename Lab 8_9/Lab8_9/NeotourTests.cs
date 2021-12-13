using Lab_8_9.Models;
using Lab_8_9.Models.TourSearchModal;
using Lab_8_9.Services;
using Lab8.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lab8
{
    [TestFixture]
    public class NeotourTests
    {
        private IWebDriver _driver;
        private IPageService _pageService;
        
        [SetUp]
        public void SetupDriver()
        {
            var option = new ChromeOptions();
            option.AddArguments("--headless", "--window-size=1920,1920", "--lang=ru-RU");
            
            _driver = new ChromeDriver(option);
            _pageService = new PageService();
        }

        [Test]
        public void SearchToursTest()
        {
            var homePage = _pageService.GetHomePage(_driver);
            
            var testData = new TourSearchTestData
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
        

        [TearDown]
        public void CloseDriver()
        {
            _driver.Quit();
        }
    }
}