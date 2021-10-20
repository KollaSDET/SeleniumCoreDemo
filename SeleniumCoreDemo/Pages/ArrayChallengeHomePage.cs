using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Extensions;
using TechTalk.SpecFlow;
using static OpenQA.Selenium.Support.Extensions.WebDriverExtensions;

namespace SeleniumCoreDemo.Pages
{
    class ArrayChallengeHomePage
    {
        private readonly IWebDriver WebDriver;
        public ArrayChallengeHomePage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }


       
        public IList<IWebElement> arrayChallengeTableRows => WebDriver.FindElements(By.XPath("//section[@id='challenge']//table/tbody/tr/td[contains(@data-test-id,'array-item')]/parent::tr"));

        public IWebElement inputChallengeResult2 => WebDriver.Find(By.XPath("//section[@id='challenge']//input[@id='undefined-submitchallenge1-undefined-16475' and @data-test-id = 'submit-2']"),10);

        public IWebElement renderChallengeButton => WebDriver.Find(By.XPath("//button[@data-test-id='render-challenge']"),10);

        public IWebElement submitAnswersButton => WebDriver.Find(By.XPath("//section[@id='challenge']//button[@tabindex='0']//div//span[text()='Submit Answers']"),10);
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
                
                for (fIndx = 0; fIndx < maxLength; fIndx++)
                {

                    //Console.WriteLine("the new forward Array integer value: " + rowArray[fIndx] + "@index as: " + fIndx);
                 
                    forwardTotal = rowArray[fIndx] + forwardTotal;
                    int backwardTotal = 0;
                    for (bIndx = maxLength - 1; bIndx >= fIndx + 2; bIndx--)
                    {
                        backwardTotal = rowArray[bIndx] + backwardTotal;
                        //Console.WriteLine("the new backward Array integer value: " + rowArray[bIndx] + "@index as: " + bIndx);
                    }
                    //Console.WriteLine("forwardTotal is" + forwardTotal);
                    //Console.WriteLine("backwardTotal is" + backwardTotal);
                    if (forwardTotal == backwardTotal)
                    {
                        
                        returnVal = fIndx + 1;
                        arrayRowResults.Add(Convert.ToInt32(returnVal));
                    }


                }
            }
            return arrayRowResults;
            /*if (returnVal.Equals(null))
            { return null;}
            else
            { return arrayRowResults; }*/

        }


        public void EnterResults(IList<int?> resultsList)
        {    IList<IWebElement> inputSubmitResults = WebDriver.FindElements(By.XPath("//section[@id='challenge']//input[contains(@id,'undefined') and contains(@data-test-id,'submit')]"));
          
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

        public void VerifySuccessMessage(Table table)
        {
            var wait2 = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(40));
            wait2.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='dialog']//div[contains(text(),'Congratulations')]")));
            IList<IWebElement> actualMessageDialog = WebDriver.FindElements(By.XPath("//div[@class='dialog']"));
           
            var actualMessage = actualMessageDialog[0].Text;
            Assert.That(actualMessage.Contains(table.Rows[0][0]));
         
        }

      
        public void VerifyErrorMessage(Table table)
        {
             var wait2 = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(40));
            wait2.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='dialog']//div[contains(text(),'It looks like')]")));
            IList<IWebElement> actualMessageDialog = WebDriver.FindElements(By.XPath("//div[@class='dialog']"));
            var actualMessage = actualMessageDialog[0].Text.ToLower();
            Assert.That(actualMessage.Contains(table.Rows[0][0].ToLower()));
          
        }
       



    }
}
