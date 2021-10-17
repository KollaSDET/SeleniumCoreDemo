using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;



namespace SeleniumCoreDemo.Pages
{
    public class HomePage
    {
        public IWebDriver WebDriver;
        public  HomePage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public IWebElement FeaturedContentLabel => WebDriver.FindElement(By.ClassName("featured-card__header"));
   
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
    }
}
