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
        private String link;

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
        public void WhenIClick(string menuLink)
        {
            this.link = menuLink;
            _homePage.clickLinkMenu(menuLink);
        }


        [When(@"I click subitem ""(.*)""")]
        public void WhenIClickSubItem(string subMenu)
        {
             _homePage.clickSubMenuItem(this.link, subMenu);
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
