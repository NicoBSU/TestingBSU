using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Lab8.Pages
{
    public class HomePage : Page
    {
        public HomePage(IWebDriver webDriver) : base(webDriver, "https://neotour.by/") { }

        public string XPathLocation = "//*[@id=\"sppb-addon-1543614584688\"]/div/div/div/div/div/div/div/div[1]";
        public string XPathCountry = "//*[@id=\"sppb-addon-1543614584688\"]/div/div/div/div/div/div/div/div[2]";
        public string XPathDates = "//*[@id=\"sppb-addon-1543614584688\"]/div/div/div/div/div/div/div/div[3]";
        public string XPathNights = "//*[@id=\"sppb-addon-1543614584688\"]/div/div/div/div/div/div/div/div[4]";
        public string XPathSearchButton = "//*[@id=\"sppb-addon-1543614584688\"]/div/div/div/div/div/div/div/div[6]";


        public IWebElement LocationButton => FindBy(By.XPath(XPathLocation));
        public IWebElement CountryButton => FindBy(By.XPath(XPathCountry));
        public IWebElement DatesButton => FindBy(By.XPath(XPathDates));
        public IWebElement NightsButton => FindBy(By.XPath(XPathNights));
        public IWebElement SubmitButton => FindBy(By.XPath(XPathSearchButton));

        public HomePage EnterLocation(string country, string city)
        {
            //By clicking on location button we open modal
            LocationButton.Click();

            //Then we find button to click on
            var xPathCountrySelection = 
                $"//div[@class='TVNationContainer' and contains(text(), {country})]";
            var countryButton = FindBy(By.XPath(xPathCountrySelection));
            countryButton.Click();



            //Then we select city
            var xPathCitySelection = $"//div[@class='TVCheckBox TVTableCitiesItem TVDisableCheckbox' and contains(text(),{city})]";
            var cityButton = FindBy(By.XPath(xPathCitySelection));
            cityButton.Click();

            return this;
        }

        public HomePage EnterCountry(string country)
        {
            //By clicking on country button we open modal to choose which country to visit
            CountryButton.Click();


            //Then We Select Country
            var xPathCountryButton = $"//div[@class='TVCountryCheckboxContent' and ./div[contains(text(), {country})]]";
            var countryButton = FindBy(By.XPath(xPathCountryButton));
            countryButton.Click();

            return this;
        }

        public HomePage EnterDates(int earlierDepartureDate, int laterDepartureDate)
        {

            DatesButton.Click();

            //Now that we've opened calendar modal, let's select dates

            var xPathEarlierDeparture = $"//td[@class='TVAvailableDays' and @data-value='{earlierDepartureDate}']";
            var xPathLaterDeparture = $"//td[@class='TVAvailableDays' and @data-value='{laterDepartureDate}']";

            var earlierDepartureButton = FindBy(By.XPath(xPathEarlierDeparture));
            earlierDepartureButton.Click();
            var laterDepartureButton = FindBy(By.XPath(xPathLaterDeparture));
            laterDepartureButton.Click();
            
            return this;
        }

        public HomePage EnterNights(int minNights, int maxNights)
        {
            NightsButton.Click();
            var xPathMinNights = $"//div[./div[contains(text(),'{minNights}')]]";
            var minNightsButton = FindBy(By.XPath(xPathMinNights));
            minNightsButton.Click();

            var xPathMaxNights = $"//div[./div[contains(text(),'{maxNights}')]]";
            var maxNightsButton = FindBy(By.XPath(xPathMinNights));
            maxNightsButton.Click();


            return this;
        }
        

        public HomePage SearchTours()
        {
            SubmitButton.Click();
            return this;
        }

        public override HomePage OpenPage()
        {
            WebDriver.Navigate().GoToUrl(EntryUrl);
            return this;
        }
        
        private IWebElement FindBy(By key)
        {
            return new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5)).Until(driver => driver.FindElement(key));
        }
    }
}