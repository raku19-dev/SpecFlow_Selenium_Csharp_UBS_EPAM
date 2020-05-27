using OpenQA.Selenium;
using SpecFlow_Csharp_EPAM.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace SpecFlow_Csharp_EPAM.StepsDefinitions
{
 
    [Binding]
    public class StepsDefinitions
    {
        private readonly HomePage _homePage;
        private readonly JobBoard _jobBoard;
        private readonly SearchJobs _searchJobs;

        public StepsDefinitions(IWebDriver driver)
        {
            _homePage = new HomePage(driver);
            _jobBoard = new JobBoard(driver);
            _searchJobs = new SearchJobs(driver);
        }

        [Given(@"I am on ""(.*)""")]
        public void GivenIAmOn(string url)
        {
            _homePage.Navigate(url);
            _homePage.handlePrivacySettings();
        }

        [When(@"I click ""(.*)""")]
        public void WhenIClick(string menu)
        {
            String[] strlink = menu.Split("/");
            _homePage.clickMenuItem(strlink[0],strlink[1]);
        }


        [When(@"I open Professionals for EMEA")]
        public void WhenIOpenProfessionalsForEMEA()
        {
            _jobBoard.clickLinkForEMEA("Professionals");
        }
        
        [Then(@"there are (.*) open positions")]
        public void ThenThereAreOpenPositions(int p0)
        {
            //ScenarioContext.Current.Pending();
        }
    }
}
