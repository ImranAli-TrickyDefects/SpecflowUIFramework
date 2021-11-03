using System;
using TechTalk.SpecFlow;
using Selenium.Intilaizer;
using NUnit.Framework;
using Selenium.Configuration;
using Specflow_BDD_UI_Test_Automation_Framwork.Contexts;

namespace Specflow_BDD_UI_Test_Automation_Framwork.Steps_Defination
{
    [Binding]
    public class LoginFeatureSteps
    {
        readonly UserContext context;
        public LoginFeatureSteps(UserContext context)
        {
            this.context = context;
        }

        [Given(@"User must need to login before purchasing")]
        public void GivenUserMustNeedToLoginBeforePurchasing()
        {
            Page.home.SelectSignInTab();
        }
        
        [When(@"User provide Valid ""(.*)"" and ""(.*)""")]
        public void WhenUserProvideValidAnd(string email, string password)
        {
            Page.loginPage.EnterLoginDetail(email, password);
            context.EmailAdress = email;
            context.Password = password;
        }
        
        [When(@"Select the Login Button")]
        public void WhenSelectTheLoginButton()
        {
            Page.loginPage.SelectLogginButton();
        }

        [Then(@"User must be Logged in to Sample Site Successfully")]
        public void ThenUserMustBeLoggedInToSampleSiteSuccessfully()
        {
            Assert.IsTrue(Driver.Current.Url.Contains(""),"Unable to login to the site");
        }

        //---------------------------------------------------------------------------

        [Given(@"User Try to login with invalid credentials")]
        public void GivenUserTryToLoginWithInvalidCredentials()
        {
            Page.home.SelectSignInTab();
            
        }

        [When(@"User provide InValid ""(.*)"" and ""(.*)""")]
        public void WhenUserProvideInValidAnd(string email, string password)
        {
            Page.loginPage.EnterLoginDetail(email, password);
        }

        [Then(@"User must be not allowed to logged in to the sample site")]
        public void ThenUserMustBeNotAllowedToLoggedInToTheSampleSite()
        {
            Assert.IsFalse(Driver.Current.Url.Contains("sam"),"User is allowed to logged in with incorrect credentials");
        }

    }
}
