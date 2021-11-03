using System;
using System.Collections.Generic;
using System.Text;
using Selenium.Pages;
using Selenium.Pages.MainPages;

namespace Selenium.Initializer
{
    public static class Page
    {
        [ThreadStatic]
        public static LoginPage loginPage;
        [ThreadStatic]
        public static HomePage home;
        [ThreadStatic]
        public static SignUpPages SignUp;


        public static void InitPages()
        {
            loginPage = new LoginPage();
            home = new HomePage();
            SignUp = new SignUpPages();
        }

    }
}
