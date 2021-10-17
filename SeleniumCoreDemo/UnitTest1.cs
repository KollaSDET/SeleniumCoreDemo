using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCoreDemo
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
           
        }

        //[Test]
        //public void Test1()
        //{
        //    var chromeDriverPath = @"C:\Users\S\source\repos\ChromeBrowser";
        //    IWebDriver browser = new ChromeDriver(chromeDriverPath);
        //    browser.Navigate().GoToUrl("https://www.sriharikolla.com/");
        //    browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);       
         
        //    var btnList = browser.FindElements(By.Id("onetrust-accept-btn-handler"));          IJavaScriptExecutor js = (IJavaScriptExecutor)browser;
            
        //    js.ExecuteScript("arguments[0].click();", btnList[0]);
        //    var featuredNameText = browser.FindElement(By.ClassName("featured-card__header")).Text;
           
        //    Assert.AreEqual("Featured content", featuredNameText);          
     
        //}
    }
}