using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumCoreDemo.Pages;
using TechTalk.SpecFlow;


namespace SeleniumCoreDemo.Steps
{
    [Binding]
    class ECSDigitalArrayChallengeSteps
    {
        
        public const string chromeDriverPath = @"C:\Users\S\source\repos\ChromeBrowser";
        IWebDriver webDriver = new ChromeDriver(chromeDriverPath);
       //ArrayChallengeHomePage arrayChallengeHomePage = new ArrayChallengeHomePage(IWebDriver  webDriver);
        ArrayChallengeHomePage arrayChallengeHomePage;
        // private int? returnedIndx;
        private IList<int?> returnedIndx;
        IDictionary listOfResults = new Dictionary<int, int>();
        public static IList<int?> cList { get; set; }
        
        public ECSDigitalArrayChallengeSteps()
        {
            arrayChallengeHomePage = new ArrayChallengeHomePage(webDriver);
        }

        //internal ArrayChallengeHomePage ArrayChallengeHomePage { get => arrayChallengeHomePage; set => arrayChallengeHomePage = value; }

        //public string AppUrl = "https://www.thoughtworks.com/";



        [Given(@"I have launched ECS digital home page")]
        public void GivenIHaveLaunchedECSDigitalHomePage()
        {
            //ScenarioContext.Current.Pending();
            webDriver.Navigate().GoToUrl("http://localhost:3000/");
        }

        [Given(@"I have clicked on Render the Challenge button")]
        public void GivenIHaveClickedOnRenderTheChallengeButton()
        {
            arrayChallengeHomePage.ClickRenderChallengeButton();

            // ScenarioContext.Current.Pending();
        }
        [When(@"I have read the Array Challenge table for row ""(.*)""")]
        public void WhenIHaveReadTheArrayChallengeTableForRow(int p0)
        {
            Dictionary<int,int[]> gg = arrayChallengeHomePage.returnTableRow(p0);
            cList = arrayChallengeHomePage.ArrayChecker(gg);
            //var dlist = cList;
            // returnedIndx = arrayChallengeHomePage.ArrayChecker(arrayChallengeHomePage.returnTableRow(p0));

        }

        //[When(@"I have read the first row from Array Challenge table")]
        //public void WhenIHaveReadTheFirstRowFromArrayChallengeTable()
        //{

        //    var returnedIndx = arrayChallengeHomePage.ArrayChecker(arrayChallengeHomePage.returnTableRow(p0));

        //}

        [Then(@"I should see array index for ""(.*)""")]
        public void ThenIShouldSeeArrayIndexFor(int expectedIndx)
        {
            IList<int?> expectedResultIndices = new List<int?>() { 4, 3, 5 };
            //Assert.AreEqual(returnedIndx, expectedIndx);
            Assert.AreEqual(cList, expectedResultIndices);
            //var returnedIndx = arrayChallengeHomePage.ArrayChecker(arrayChallengeHomePage.returnTableRow(p0));
            //Console.WriteLine("returnedIndx is" + returnedIndx);
        }

        [Then(@"I have entered the Array indices as results along my name ""(.*)""")]
        public void ThenIHaveEnteredTheArrayIndicesAsResultsAlongMyName(string p0)
        {
            // ScenarioContext.Current.Pending();
            arrayChallengeHomePage.EnterResults(cList);
        }


        [Then(@"I have clicked on Submit Answers button")]
        public void ThenIHaveClickedOnSubmitAnswersButton()
        {
            arrayChallengeHomePage.ClickSubmitAnswersButton();
        }

        [Then(@"I should see below successful message")]
        public void ThenIShouldSeeBelowSuccessfulMessage()
        {
            string expectedMessage = @"Congratulations you have succeeded. Please submit your challenge";
            arrayChallengeHomePage.VerifySuccessMessage(expectedMessage);
            //driver.SwitchTo().Frame("frame-name");
           // driver.SwitchTo().DefaultContent();
            //ScenarioContext.Current.Pending();
        }

        [Then(@"I should see below unsuccessful message")]
        public void ThenIShouldSeeBelowUnsuccessfulMessage(Table table)
        {
            //string expectedMessage = @"Congratulations you have succeeded. Please submit your challenge";
            
            //arrayChallengeHomePage.VerifySuccessMessage(expectedMessage);
            arrayChallengeHomePage.VerifyErrorMessage(table);
           

        }


    }
}
