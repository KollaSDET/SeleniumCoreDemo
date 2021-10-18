using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Extensions;
using TechTalk.SpecFlow;

namespace SeleniumCoreDemo.Pages
{
    class ArrayChallengeHomePage
    {
        private readonly IWebDriver WebDriver;
        public ArrayChallengeHomePage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }


        public IWebElement FeaturedContentLabel => WebDriver.FindElement(By.ClassName("featured-card__header"));
        public IList<IWebElement> arrayChallengeTableRows => WebDriver.FindElements(By.XPath("//section[@id='challenge']//table/tbody/tr/td[contains(@data-test-id,'array-item')]/parent::tr"));

        public IWebElement inputChallengeResult2 => WebDriver.FindElement(By.XPath("//section[@id='challenge']//input[@id='undefined-submitchallenge1-undefined-16475' and @data-test-id = 'submit-2']"));

        public IWebElement renderChallengeButton => WebDriver.FindElement(By.XPath("//button[@data-test-id='render-challenge']"));

        public IWebElement submitAnswersButton => WebDriver.FindElement(By.XPath("//section[@id='challenge']//button[@tabindex='0']//div//span[text()='Submit Answers']"));
        IDictionary<int, int> listOfResults = new Dictionary<int, int>();
        public void GoToECSDigitalHomePage(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
        }
        

        public void ClickRenderChallengeButton()
        {
            renderChallengeButton.Click();
        }

        public void ClickSubmitAnswersButton()
        {
            submitAnswersButton.Click();
        }

        public void InputChallengeResult2(string inputResult)
        {
            inputChallengeResult2.Clear();
            inputChallengeResult2.SendKeys(inputResult);
        }
        public void VerifyLabelContent(string expectedLabel)
        {
            Assert.AreEqual(expectedLabel, FeaturedContentLabel.Text);
        }

        public void AcceptCookies()
        {
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            var btnList = WebDriver.FindElements(By.Id("onetrust-accept-btn-handler"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriver;
            js.ExecuteScript("arguments[0].click();", btnList[0]);
        }


        public Dictionary<int, int[]> returnTableRow(int rowIndx)
        {
            Dictionary<int, int[]> resultsDict = new Dictionary<int, int[]>();
            var tdRows = WebDriver.FindElements(By.XPath("//section[@id='challenge']//table/tbody/tr/td[contains(@data-test-id,'array-item')]//parent::tr"));

            for (int rowId = 0; rowId < tdRows.Count; rowId++)
            {
                var tdList = tdRows[rowId].FindElements(By.XPath("./td"));
                List<int> rowCells = new List<int>();
                foreach (var rowCell in tdList)
                {
                    rowCells.Add(Convert.ToInt32(rowCell.Text));
                }
                resultsDict.Add(rowId, rowCells.ToArray());
            }
            return resultsDict;


        }
        public int[] returnTableRow2(int rowIndx)
        {
            //int[] rowArray = new int[8] { 10, 15, 5, 7, 1, 24, 36, 2 };
            //int[] rowArray = new int[9] { 30, 43, 29, 10, 50, 40, 99, 51, 12 };
            //int[] rowArray = new int[9] { 23, 50, 63, 90, 10, 30, 155, 23, 18 };
            //rowArray = {10, 15, 5, 7, 1, 24, 36, 2};
            //int[] tableArray =  { 133, 60, 23, 92, 6, 7, 168, 16, 19 };
            // var oo = WebDriver.FindElements(By.Id("challenge"));
            // var pp = WebDriver.FindElements(By.XPath("//section[@id='challenge']//table/tbody/tr/td[contains(@data-test-id,'array-item')]"));//parent::tr"));
            var tdRows = WebDriver.FindElements(By.XPath("//section[@id='challenge']//table/tbody/tr/td[contains(@data-test-id,'array-item')]//parent::tr"));

            //var tdRowIndx = pppp[1];

            var tdList = tdRows[rowIndx].FindElements(By.XPath("./td"));
            List<int> rowCells = new List<int>();
            foreach (var rowCell in tdList)
            {
                rowCells.Add(Convert.ToInt32(rowCell.Text));
            }

            return rowCells.ToArray();
        }

        public IList<int?> ArrayChecker(Dictionary<int, int[]> inputTable)
        {
            IList<int?> arrayRowResults = new List<int?>();
           
            for (int idx = 0; idx < inputTable.Keys.Count; idx++)
            {
                var rowArray = inputTable[idx];

                int maxLength = rowArray.Length;
                int fIndx, bIndx;
                int forwardTotal = 0;
                int? returnVal = null;
                //var returnVal = default(int?);

                // for (fIndx = 0, bIndx = maxLength - 1; fIndx < maxLength; fIndx++, bIndx--)
                for (fIndx = 0; fIndx < maxLength; fIndx++)
                {

                    Console.WriteLine("the new forward Array integer value: " + rowArray[fIndx] + "@index as: " + fIndx);
                 
                    forwardTotal = rowArray[fIndx] + forwardTotal;
                    int backwardTotal = 0;
                    for (bIndx = maxLength - 1; bIndx >= fIndx + 2; bIndx--)
                    {
                        backwardTotal = rowArray[bIndx] + backwardTotal;
                        Console.WriteLine("the new backward Array integer value: " + rowArray[bIndx] + "@index as: " + bIndx);
                    }
                    Console.WriteLine("forwardTotal is" + forwardTotal);
                    Console.WriteLine("backwardTotal is" + backwardTotal);
                    if (forwardTotal == backwardTotal)
                    {
                        Console.WriteLine("2000");
                        returnVal = fIndx + 1;
                        arrayRowResults.Add(Convert.ToInt32(returnVal));
                    }


                    // return 1;
                }
            }
            return arrayRowResults;
            /*if (returnVal.Equals(null))
            { return null;}
            else
            { return arrayRowResults; }*/

        }


        public void EnterResults(IList<int?> resultsList)
        {
            //IList<int?> arrayRowResults = new List<int?>();
            //int[] rowArray = new int[8] { 10, 15, 5, 7, 1, 24, 36, 2 };
            //int[] rowArray = new int[9] { 30, 43, 29, 10, 50, 40, 99, 51, 12 };
            //int[] rowArray = new int[9] { 23, 50, 63, 90, 10, 30, 155, 23, 18 };
            //rowArray = {10, 15, 5, 7, 1, 24, 36, 2};
            //int[] rowArray = new int[9] { 133, 60, 23, 92, 6, 7, 168, 16, 19 };
            //IList<IWebElement> inputSubmitResults =    WebDriver.FindElement(By.XPath("//section[@id='challenge']//input[@id='undefined-submitchallenge1-undefined-16475' and @data-test-id = 'submit-2']"));
            IList<IWebElement> inputSubmitResults = WebDriver.FindElements(By.XPath("//section[@id='challenge']//input[contains(@id,'undefined') and contains(@data-test-id,'submit')]"));
            //IList<IWebElement> inputSubmitResults = WebDriver.FindElements(By.XPath("//section[@id='challenge']//input[contains(@data-test-id,'submit')]"));

            for (int idx = 0; idx < resultsList.Count; idx++)
            {
                if (!String.IsNullOrEmpty(resultsList[idx].ToString()))
                {
                    inputSubmitResults[idx].SendKeys(resultsList[idx].ToString());
                }

            }
            inputSubmitResults[inputSubmitResults.Count-1].SendKeys("Srihari Kolla");

            submitAnswersButton.Click();
        }

        public void VerifySuccessMessage(string message)
        {
            var wait2 = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(40));
            wait2.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='dialog']//div[contains(text(),'Congratulations')]")));
            IList<IWebElement> actualMessageDialog = WebDriver.FindElements(By.XPath("//div[@class='dialog']"));
           
            var actualMessage = actualMessageDialog[0].Text;
            Assert.That(actualMessage.Contains(message));
         
        }

        public void VerifyErrorMessage(Table table)
        {
             var wait2 = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(40));
            wait2.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='dialog']//div[contains(text(),'It looks like')]")));
            IList<IWebElement> actualMessageDialog = WebDriver.FindElements(By.XPath("//div[@class='dialog']"));
            var actualMessage = actualMessageDialog[0].Text.ToLower();
            Assert.That(actualMessage.Contains(table.Rows[0][0].ToLower()));
          
        }
        /*public int[] ArrayChecker22(int[] inputArray)
        {

            //int[] rowArray = new int[8] { 10, 15, 5, 7, 1, 24, 36, 2 };
            //int[] rowArray = new int[9] { 30, 43, 29, 10, 50, 40, 99, 51, 12 };
            //int[] rowArray = new int[9] { 23, 50, 63, 90, 10, 30, 155, 23, 18 };
            //rowArray = {10, 15, 5, 7, 1, 24, 36, 2};
            //int[] rowArray = new int[9] { 133, 60, 23, 92, 6, 7, 168, 16, 19 };
            var rowArray = inputArray;

            int maxLength = rowArray.Length;
            int fIndx, bIndx;
            int forwardTotal = 0;
            int? returnVal = null;
            //var returnVal = default(int?);

            // for (fIndx = 0, bIndx = maxLength - 1; fIndx < maxLength; fIndx++, bIndx--)
            for (fIndx = 0; fIndx < maxLength; fIndx++)
            {

                Console.WriteLine("the new forward Array integer value: " + rowArray[fIndx] + "@index as: " + fIndx);
                //Console.WriteLine("the new backward Array integer value: " + rowArray[bIndx] + "@index as: " + bIndx);

                forwardTotal = rowArray[fIndx] + forwardTotal;
                int backwardTotal = 0;
                for (bIndx = maxLength - 1; bIndx >= fIndx + 2; bIndx--)
                {
                    backwardTotal = rowArray[bIndx] + backwardTotal;
                    Console.WriteLine("the new backward Array integer value: " + rowArray[bIndx] + "@index as: " + bIndx);
                }
                Console.WriteLine("forwardTotal is" + forwardTotal);
                Console.WriteLine("backwardTotal is" + backwardTotal);
                if (forwardTotal == backwardTotal)
                {
                    Console.WriteLine("2000");
                    returnVal = fIndx + 1;
                    return Convert.ToInt32(returnVal);
                }


                // return 1;
            }

            if (returnVal.Equals(null))
            { return null; }
            else
            { return returnVal; }

        }*/



    }
}
