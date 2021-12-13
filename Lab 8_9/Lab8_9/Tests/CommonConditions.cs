using Lab_8_9.Services;
using Lab_8_9.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8_9.Tests
{
    public class CommonConditions
    {
        protected IWebDriver _driver;
        protected DriverSingleton _driverSingleton;

        [SetUp]
        public void SetupDriver()
        {
            _driver = DriverSingleton.GetDriver(BrowserType.CHROME);
        }


        [TearDown]
        public void CloseDriver()
        {
            DriverSingleton.closeDriver();
        }
    }
}
