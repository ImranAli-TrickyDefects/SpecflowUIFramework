using OpenQA.Selenium;
using Selenium.Initializer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium.Pages.MainPages
{
    public class HomePage
    {
        private IWebElement Tab_SignIn
        {
            get
            {
                return Driver.Current.FindElement(By.ClassName("login"));
            }
        }

        public void SelectSignInTab()
        {
            Tab_SignIn.Click();
        }

    }
}
