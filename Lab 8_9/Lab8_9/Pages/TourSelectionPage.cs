using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8_9.Pages
{
    public class TourSelectionPage : Page
    {
        public TourSelectionPage(IWebDriver webDriver) : base(webDriver, "https://neotour.by/podbor-tura") { }

        public override TourSelectionPage OpenPage()
        {
            WebDriver.Navigate().GoToUrl(EntryUrl);
            return this;
        }


        public TourSelectionPage AddHotelToCompilation()
        {
            var xPathFindToursButton = "//*[@id=\"sppb-addon-1500421709226\"]/div/div/div/div/div/div[2]/div[3]/div[3]";
            FindBy(By.XPath(xPathFindToursButton)).Click();


            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(25));
            wait.Until(driver => driver.FindElement(By.XPath("//*[@id=\"sppb - addon - 1500421709226\"]/div/div/div/div[3]/div[1]/div[1]/div/div/div[1]")).Displayed);


            var xPathFirstTourFromList = "//*[@id=\"sppb-addon-1500421709226\"]/div/div/div/div[3]/div[1]/div[4]/div[2]/div[1]/div/div[1]/div[1]/div[2]/div[2]/div/text/a";
            FindBy(By.XPath(xPathFirstTourFromList)).Click();

            var xPathAddToSelectionButton = "//*[@id=\"page\"]/div[10]/div[1]/div[2]/div[2]/div[2]/div[2]/div[3]/div[2]";
            FindBy(By.XPath(xPathAddToSelectionButton)).Click();

            return this;
        }

    }
}
