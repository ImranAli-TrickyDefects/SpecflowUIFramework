using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Selenium.Initializer;

namespace Selenium.Support.Extensions
{
    public static class SeleniumWebdriverExtensions
    {
        public static bool WaitForAjax(this IWebDriver driver)
        {
            try
            {
                while (true) // Handle timeout somewhere
                {
                    var ajaxIsComplete = (bool)(driver as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0");
                    if (ajaxIsComplete)
                        break;
                    Thread.Sleep(100);
                }
            }
            catch (TimeoutException e)
            {
                Console.Error.WriteLine(e.Message + "Error waiting for ajax");
            }

            return true;
        }

       public static void GoToTheSite(this IWebDriver driver, string Url)
        {
            driver = Driver.Current;
            driver.Navigate().GoToUrl(Url);
        }

    }
}
