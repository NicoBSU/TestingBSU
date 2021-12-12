using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Lab8.Pages
{
    public class Page
    {
        public Page(IWebDriver webDriver, string entryUrl)
        {
            WebDriver = webDriver;
            EntryUrl = entryUrl;
            PageFactory.InitElements(webDriver, this);
        }

        protected IWebDriver WebDriver { get; }

        protected string EntryUrl { get; }

        public string CurrentUrl => WebDriver.Url;

        public virtual Page OpenPage()
        {
            WebDriver.Navigate().GoToUrl(EntryUrl);

            return this;
        }
    }
}