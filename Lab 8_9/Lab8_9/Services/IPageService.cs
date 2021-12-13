using Lab8.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8_9.Services
{
    public interface IPageService
    {
        HomePage GetHomePage(IWebDriver _driver);
    }
}
