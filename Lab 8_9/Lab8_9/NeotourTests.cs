using Lab8.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text;

namespace Lab8
{
    [TestFixture]
    public class NeotourTests
    {
        private IWebDriver _driver;
        
        [SetUp]
        public void SetupDriver()
        {
            var option = new ChromeOptions();
            option.AddArguments("--headless", "--window-size=1920,1920");
            _driver = new ChromeDriver(option);
        }

        [Test]
        public void SearchToursTest()
        {
            var homePage = new HomePage(_driver).OpenPage();
            byte[] bytes = Encoding.Default.GetBytes("Минск");
            var city = Encoding.UTF8.GetString(bytes);
            bytes = Encoding.Default.GetBytes("Египет");
            var country = Encoding.UTF8.GetString(bytes);

            homePage.EnterLocation(city)
                .EnterCountry(country)
                .EnterDates(17,20)
                .EnterNights(7,12)
                .SearchTours();

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