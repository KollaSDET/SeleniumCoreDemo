using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SeleniumCoreDemo
{

    [Binding]
    public class Hooks
        {
            private readonly IObjectContainer _objectContainer;
            public const string chromeDriverPath = @"C:\Users\S\source\repos\ChromeBrowser";

        public Hooks(IObjectContainer objectContainer)
            {
                _objectContainer = objectContainer;
            }

            [BeforeScenario]
            public void BeforeScenario()
            {
                IWebDriver driver = new ChromeDriver(chromeDriverPath);
                _objectContainer.RegisterInstanceAs(driver);
            }

            [AfterScenario]
            public void AfterScenario()
            {
            IWebDriver driver = _objectContainer.Resolve<IWebDriver>();
                driver.Quit();
            }
        }
    
}

