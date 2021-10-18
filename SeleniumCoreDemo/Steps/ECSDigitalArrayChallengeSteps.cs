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
        
       // public const string chromeDriverPath = @"C:\Users\S\source\repos\ChromeBrowser";
       // IWebDriver webDriver = new ChromeDriver(chromeDriverPath);

       ////ArrayChallengeHomePage arrayChallengeHomePage = new ArrayChallengeHomePage(IWebDriver  webDriver);
        //ArrayChallengeHomePage arrayChallengeHomePage;
        // private int? returnedIndx;
       // private IList<int?> returnedIndx;
       // IDictionary listOfResults = new Dictionary<int, int>();
        public static IList<int?> indexList { get; set; }
        private readonly IWebDriver webDriver;
        private readonly ArrayChallengeHomePage _arrayChallengeHomePage;
       
        

        public ECSDigitalArrayChallengeSteps(ArrayChallengeHomePage arrayChallengeHomePage)
        {
            _arrayChallengeHomePage = arrayChallengeHomePage;
        }
       

        //internal ArrayChallengeHomePage ArrayChallengeHomePage { get => arrayChallengeHomePage; set => arrayChallengeHomePage = value; }

        public string AppUrl = "http://localhost:3000/";



        [Given(@"I have launched ECS digital home page")]
        public void GivenIHaveLaunchedECSDigitalHomePage()
        {
            //ScenarioContext.Current.Pending();
            _arrayChallengeHomePage.GoToECSDigitalHomePage(AppUrl);
            //webDriver.Navigate().GoToUrl(AppUrl);
        }

        [Given(@"I have clicked on Render the Challenge button")]
        public void GivenIHaveClickedOnRenderTheChallengeButton()
        {
            _arrayChallengeHomePage.ClickRenderChallengeButton();

            // ScenarioContext.Current.Pending();
        }
        [When(@"I have read the Array Challenge table for row ""(.*)""")]
        public void WhenIHaveReadTheArrayChallengeTableForRow(int p0)
        {
            Dictionary<int,int[]> dictAllTableRows = _arrayChallengeHomePage.returnTableRow(p0);
            indexList = _arrayChallengeHomePage.ArrayChecker(dictAllTableRows);
            //var dlist = indexList;
            // returnedIndx = _arrayChallengeHomePage.ArrayChecker(_arrayChallengeHomePage.returnTableRow(p0));

        }


        [Then(@"I should see array index for ""(.*)""")]
        public void ThenIShouldSeeArrayIndexFor(int expectedIndx)
        {
            IList<int?> expectedResultIndices = new List<int?>() { 4, 3, 5 };
            //Assert.AreEqual(returnedIndx, expectedIndx);
            Assert.AreEqual(indexList, expectedResultIndices);
            //var returnedIndx = _arrayChallengeHomePage.ArrayChecker(_arrayChallengeHomePage.returnTableRow(p0));
            //Console.WriteLine("returnedIndx is" + returnedIndx);
        }

        [Then(@"I have entered the Array indices as results along my name ""(.*)""")]
        public void ThenIHaveEnteredTheArrayIndicesAsResultsAlongMyName(string p0)
        {

            _arrayChallengeHomePage.EnterResults(indexList);
        }


        [Then(@"I have clicked on Submit Answers button")]
        public void ThenIHaveClickedOnSubmitAnswersButton()
        {
            _arrayChallengeHomePage.ClickSubmitAnswersButton();
        }

        [Then(@"I should see below successful message")]
        public void ThenIShouldSeeBelowSuccessfulMessage()
        {
            string expectedMessage = @"Congratulations you have succeeded. Please submit your challenge";
            _arrayChallengeHomePage.VerifySuccessMessage(expectedMessage);
            //driver.SwitchTo().Frame("frame-name");
           // driver.SwitchTo().DefaultContent();
          
        }

        [Then(@"I should see below unsuccessful message")]
        public void ThenIShouldSeeBelowUnsuccessfulMessage(Table table)
        {
            //string expectedMessage = @"Congratulations you have succeeded. Please submit your challenge";

            _arrayChallengeHomePage.VerifyErrorMessage(table);           

        }


    }
}
