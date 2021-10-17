using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumCoreDemo.Pages;
using TechTalk.SpecFlow;

namespace SeleniumCoreDemo.Steps
{
    [Binding]
   public sealed class HomePageSteps
    {
       // HomePage homePage = null;
        public const string chromeDriverPath = @"C:\Users\S\source\repos\ChromeBrowser";
    
        IWebDriver webDriver = new ChromeDriver(chromeDriverPath);
        public string AppUrl = "https://www.thoughtworks.com/";
        HomePage homePage;
        public HomePageSteps()
        {
            homePage = new HomePage(webDriver);
        }

        [Given(@"I have logged into thoughtworks site")]
        public void GivenIHaveLoggedIntoThoughtworksSite()
        {
           // IWebDriver webDriver = new ChromeDriver(chromeDriverPath);
            webDriver.Navigate().GoToUrl(AppUrl);
            //homePage = new HomePage(webDriver);


        }

        [When(@"I clicked on feature content link")]
        public void WhenIClickedOnFeatureContentLink()
        {
            homePage.AcceptCookies();
        }


        [Then(@"I should see ""(.*)"" over the Home page")]
        public void ThenIShouldSeeOverTheHomePage(string p0)
        {
            homePage.VerifyLabelContent(p0);
        }

    }
}
