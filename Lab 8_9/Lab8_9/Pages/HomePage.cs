using Lab_8_9.Models;
using Lab_8_9.Models.TourSearchModal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab8.Pages
{
    public class HomePage : Page
    { 
        public HomePage(IWebDriver webDriver) : base(webDriver, "https://neotour.by/") {}
        public override HomePage OpenPage()
        {
            WebDriver.Navigate().GoToUrl(EntryUrl);
            return this;
        }



        public HomePage TestSearchToursForm(TourSearchButtonsXPaths tourSearchModalDto, TourSearchTestData testData)
        {
            var buttons = FindTourSearchButtons(tourSearchModalDto);
            EnterStartLocation(buttons["startLocation"], testData.startLocationCountry, testData.startLocationCity);

            EnterDestinationCountry(buttons["destinationCountry"], testData.destinationCountry);

            EnterDepartureDates(buttons["departureDates"], testData.earlierDepartureDate, testData.laterDepartureDate);

            EnterNights(buttons["nights"], testData.minNights, testData.maxNights);

            SearchToursButton(buttons["searchButton"]);

            return this;

        }

        //Here we get all necessary buttons for FindTour form
        private Dictionary<string, IWebElement> FindTourSearchButtons(TourSearchButtonsXPaths tourSearchModalDto)
        {
            var buttons = new Dictionary<string,IWebElement>();
            buttons.Add("startLocation", FindBy(By.XPath(tourSearchModalDto.StartLocation)));
            buttons.Add("destinationCountry", FindBy(By.XPath(tourSearchModalDto.DestinationCountry)));
            buttons.Add("departureDates", FindBy(By.XPath(tourSearchModalDto.Dates)));
            buttons.Add("nights", FindBy(By.XPath(tourSearchModalDto.Nights)));
            buttons.Add("searchButton", FindBy(By.XPath(tourSearchModalDto.SearchButton)));

            return buttons;
        }

        //Here we enter start location based on country and city
        private HomePage EnterStartLocation(IWebElement enterStartLocationButton, string startLocationCountry, string startLocationCity)
        {
            enterStartLocationButton.Click();
           
            var xPathCountrySelection = $"//div[@class='TVNationContainer' and contains(text(), {startLocationCountry})]";
            FindBy(By.XPath(xPathCountrySelection)).Click();

            var xPathCitySelection = $"//div[@class='TVCheckBox TVTableCitiesItem TVDisableCheckbox' and contains(text(),{startLocationCity})]";
            FindBy(By.XPath(xPathCitySelection)).Click();

            return this;
        }

        //Here we enter destination button
        private HomePage EnterDestinationCountry(IWebElement enterDestinationButton, string destinationCountry)
        {
            enterDestinationButton.Click();

            var xPathCountryButton = $"//div[@class='TVCountryCheckboxContent' and ./div[contains(text(), {destinationCountry})]]";
            FindBy(By.XPath(xPathCountryButton)).Click();

            return this;
        }

        //Here we enter departure dates
        private HomePage EnterDepartureDates(IWebElement enterDepartureDatesButton, int earlierDepartureDate, int laterDepartureDate)
        {

            enterDepartureDatesButton.Click();
            
            var xPathEarlierDeparture = $"//td[@class='TVAvailableDays' and @data-value='{earlierDepartureDate}']";
            var xPathLaterDeparture = $"//td[@class='TVAvailableDays' and @data-value='{laterDepartureDate}']";

            FindBy(By.XPath(xPathEarlierDeparture)).Click();
            FindBy(By.XPath(xPathLaterDeparture)).Click();
            
            return this;
        }

        //Here we enter number of nights
        private HomePage EnterNights(IWebElement enterNightsButton, int minNights, int maxNights)
        {
            enterNightsButton.Click();
            var xPathMinNights = $"//div[./div[contains(text(),'{minNights}')]]";
            FindBy(By.XPath(xPathMinNights)).Click();

            var xPathMaxNights = $"//div[./div[contains(text(),'{maxNights}')]]";
            FindBy(By.XPath(xPathMinNights)).Click();


            return this;
        }
        
        //Here we press search button
        private HomePage SearchToursButton(IWebElement searchToursButton)
        {
            searchToursButton.Click();
            return this;
        }

        
        private IWebElement FindBy(By key)
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5));
            Thread.Sleep(100);
            return wait.Until(driver => driver.FindElement(key));;
        }
    }
}