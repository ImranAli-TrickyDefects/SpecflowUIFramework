using Selenium.Intilaizer;
using System;

using Selenium.Support.Extensions;
using TechTalk.SpecFlow;
using Selenium.Configuration;
using AventStack.ExtentReports;
using BoDi;
using AventStack.ExtentReports.Gherkin.Model;
using System.IO;
using AventStack.ExtentReports.Reporter;
using System.Reflection;

namespace Specflow_BDD_UI_Test_Automation_Framwork.Hooks
{
    [Binding]
    public sealed class Hooks
    {

        private static ExtentTest featureName;
        private static ExtentTest scenario;
        public static AventStack.ExtentReports.ExtentReports extent;
        private readonly ScenarioContext _scenarioContext;

        private readonly IObjectContainer _objectContainer;
        public Hooks(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _objectContainer = objectContainer;
        }
        //------------------------------------------------------------------


        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            //Create dynamic feature name
            featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
            //Initialize Extent report before test starts
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            outPutDirectory = outPutDirectory.Substring(0, outPutDirectory.IndexOf("bin"));

            outPutDirectory = outPutDirectory.Substring(outPutDirectory.IndexOf("\\") + 1);
            String path = Path.Combine(outPutDirectory, "TestResults\\index.html");
            var htmlReporter = new ExtentHtmlReporter(path);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            //Attach report to reporter
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [AfterStep]
        public void InsertReportingSteps()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            if (_scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (_scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
            }
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var config = ConfigurationManager.Configuration();
            var Url = config["TestEnviornmentUrl"];
            Driver.Init(Browser.Chrome);
            Driver.Current.GoToTheSite(Url.ToString());
            Page.InitPages();
            scenario = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }
        [AfterTestRun]
        public static void TearDownReport()
        {
            extent.Flush();
        }
        [AfterScenario]
        public void AfterScenario()
        {
            Driver.Current.Quit();
        }
    }
}
