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
        private readonly SignInPopup _signIn;
        private readonly ApplicationForm _appForm;

        public StepsDefinitions(IWebDriver driver)
        {
            _homePage = new HomePage(driver);
            _jobBoard = new JobBoard(driver);
            _searchJobs = new SearchJobs(driver);
            _signIn = new SignInPopup(driver);
            _appForm = new ApplicationForm(driver);
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

        [When(@"new tab is open")]
        public void WhenNewTabIsOpen()
        {
            _searchJobs.switchToNewTab();
        }


        [When(@"I select EMEA Proffessional job position ""(.*)""")]
        public void WhenIApplyForEMEProffessionalJobPosition(string positionName)
        {
            _searchJobs.selectFirstJobOfferThatMatchesPositionName(positionName);
        }

        [When(@"I click Apply now")]
        public void WhenIClickApplyNow()
        {
            _searchJobs.clickApplyNow();
        }


        [When(@"I check City ""(.*)""")]
        public void WhenICheckCity(string city)
        {
            _searchJobs.expandCitySelection();
            _searchJobs.checkSpecificCity(city);
        }

        [When(@"I check Job Type ""(.*)""")]
        public void WhenICheckJobType(string jobType)
        {
            _searchJobs.checkSpecificJobType(jobType);
        }

        [When(@"I check Function Category ""(.*)""")]
        public void WhenICheckFunctionCategory(string functionCategory)
        {
            _searchJobs.expandFunctionCategory();
            _searchJobs.checkSpecificFunctionCategory(functionCategory);
        }


        [When(@"user sign in with login and password")]
        public void WhenUserMustSignIn()
        {
            _signIn.Login();
        }

        [Then(@"there are (.*) open positions")]
        public void ThenThereAreOpenPositions(int results)
        {
            _searchJobs.AssertNumberOfResults(results+" results");
        }

        [Then(@"user can see ""(.*)""")]
        public void ThenUserCanSee(string startUpText)
        {
            _appForm.applicationIsStarted(startUpText);
        }

    }
}
