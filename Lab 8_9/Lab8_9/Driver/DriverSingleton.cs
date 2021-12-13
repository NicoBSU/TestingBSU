using Lab_8_9.Pages;
using Lab_8_9.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8_9.Services
{
    public class DriverSingleton
    {
        private static WebDriver driver;

        public DriverSingleton() { }

        public static WebDriver GetDriver(BrowserType browserType) {
            if (null == driver)
            {
                switch (browserType) {
                    case BrowserType.MOZILLA:
                    {
                        var option = new FirefoxOptions();
                        option.AddArguments("--headless", "--window-size=1920,1920", "--lang=ru-RU");
                        driver = new FirefoxDriver(option);
                        break;
                    }

                    case BrowserType.CHROME:
                    {
                        var option = new ChromeOptions();
                        option.AddArguments("--headless", "--window-size=1920,1920", "--lang=ru-RU");
                        driver = new ChromeDriver(option);
                        break;
                    }

                    default:
                    {
                        return driver;
                    }
                }
            }
            return driver;
        }

        public static void closeDriver()
        {
            driver.Quit();
            driver = null;
        }
    }
}
