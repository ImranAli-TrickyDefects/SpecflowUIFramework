using System;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Selenium.Support.Extensions;
using System.IO;

namespace Selenium.Intilaizer
{
    public enum Browser
    {
        Chrome,
        FireFox,
        Edge
    }
    public static class Driver
    {
        [ThreadStatic]
        private static IWebDriver _driver;

        public static void Init(Browser browser)
        {
            if (browser == Browser.Chrome)
            {
                string dirpath = Directory.GetCurrentDirectory();
                _driver = new ChromeDriver(dirpath);
            }
            else if (browser == Browser.FireFox)
            {
                _driver = new FirefoxDriver();
            }

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is null");
    }
}
