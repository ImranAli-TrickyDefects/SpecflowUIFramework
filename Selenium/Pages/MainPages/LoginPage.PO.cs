using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Selenium.Configuration;
using Selenium.Intilaizer;

namespace Selenium.Pages.MainPages
{
   public class LoginPage
   {
        private IWebElement Txt_Email
        {
            get
            {
                return Driver.Current.FindElement(By.CssSelector("#email"));
            }
        }

        private IWebElement Txt_Password
        {
            get
            {
                return Driver.Current.FindElement(By.CssSelector("#passwd"));
            }
        }
        private IWebElement Btn_LogIn
        {
            get
            {
                return Driver.Current.FindElement(By.CssSelector("#SubmitLogin"));
            }
        }

        public void EnterLoginDetail(string email, string password)
        {
            Txt_Email.SendKeys(email);
            Txt_Password.SendKeys(ConfigurationManager.DecodePassword(password));
        }

        public void SelectLogginButton()
        {
            Btn_LogIn.Click();
        }




    }
}
