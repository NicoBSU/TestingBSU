using Lab8.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8_9.Services
{
    public class PageService : IPageService
    {
        public HomePage GetHomePage(IWebDriver _driver)
        {
            return new HomePage(_driver).OpenPage();
        }
    }
}
