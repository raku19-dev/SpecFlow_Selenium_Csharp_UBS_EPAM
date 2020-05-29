using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlow_Csharp_EPAM.PageObjects
{
    public class SearchJobs : PageObject
    {
        private readonly IWebDriver _driver;

        public SearchJobs(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void switchToNewTab()
        {
            var newTab = _driver.WindowHandles[1];
            Assert.IsTrue(!string.IsNullOrEmpty(newTab)); // tab was opened
            _driver.SwitchTo().Window(newTab);
        }

        public void expandCitySelection()
        {
            By cityBy = By.LinkText("City");
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement cityLink = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(cityBy));
            cityLink.Click();
        }

        public void expandFunctionCategory()
        {
            By functionCategoryBy = By.LinkText("Function Category");
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement functionCategoryLink = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(functionCategoryBy));
            functionCategoryLink.Click();
        }

        public void checkSpecificCity(string city)
        {
            By byCityCheckbox = By.XPath("//ul[contains(concat(' ', @class, ' '), ' facetList ')]//label[contains(text(),'"+city+"')]/../input");
            IWebElement cityCheckbox = _driver.FindElement(byCityCheckbox);
            cityCheckbox.Click();

            By selection = By.XPath("//div[contains(@class,'ng-binding')][contains(text(),'Your selections: ')]");
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement selectionText = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(selection));
        }

        public void checkSpecificJobType(string jobType)
        {
            By byJobType = By.XPath("//ul[contains(concat(' ', @class, ' '), ' facetList ')]//label[contains(text(),'" + jobType + "')]/../input");
            IWebElement jobTypeCheckbox = _driver.FindElement(byJobType);
            jobTypeCheckbox.Click();

            By selection = By.XPath("//div[contains(@class,'ng-binding')][contains(text(),'Your selections: ')]");
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement selectionText = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(selection));
        }

        public void checkSpecificFunctionCategory(string functionCategory)
        {
            By byFunctionCategory = By.XPath("//ul[contains(concat(' ', @class, ' '), ' facetList ')]//label[contains(text(),'" + functionCategory + "')]/../input");
            IWebElement functionCategoryCheckbox = _driver.FindElement(byFunctionCategory);
            functionCategoryCheckbox.Click();

            By selection = By.XPath("//div[contains(@class,'ng-binding')][contains(text(),'Your selections: ')]");
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement selectionText = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(selection));
        }

        public void selectFirstJobOfferThatMatchesPositionName(string positionName)
        {
            By positionNameCheckboxBy = By.XPath("//a[contains(text(),'"+positionName+ "')]/../../../..//input");
            IList<IWebElement> positionNameCheckbox = _driver.FindElements(positionNameCheckboxBy);
            IWebElement firstCheckbox = positionNameCheckbox[0];
            firstCheckbox.Click();
        }

        public void clickApplyNow()
        {
            By applyNowBy = By.XPath("//span[contains(text(),'Apply now')]");
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement applyNowButton = wait.Until(ExpectedConditions.ElementToBeClickable(applyNowBy));
            applyNowButton.Click();
        }

        public void AssertNumberOfResults(string expectedNumberOfResults)
        {
            By resultsCount = By.XPath("//div[@class='sectionHeading']");
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement _actualNumberOfResults = wait.Until(ExpectedConditions.ElementIsVisible(resultsCount));
            Assert.AreEqual(expectedNumberOfResults, _actualNumberOfResults.Text);//(expected,actual)
        }

         
    }
}
