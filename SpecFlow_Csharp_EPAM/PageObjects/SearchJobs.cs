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
            IWebElement cityLink = wait.Until(ExpectedConditions.ElementIsVisible(cityBy));
            cityLink.Click();
        }

        public void checkSpecificCity(string city)
        {
            By byCityCheckbox = By.XPath("//ul[contains(concat(' ', @class, ' '), ' facetList ')]//label[contains(text(),'"+city+"')]/../input");
            //String cityId = _driver.FindElement(By.XPath("//label[starts-with(text(),'"+city+"')]")).GetAttribute("id");
            IWebElement cityCheckbox = _driver.FindElement(byCityCheckbox);
            cityCheckbox.Click();

            By selection = By.XPath("//div[contains(@class,'ng-binding')][contains(text(),'Your selections: ')]");
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement selectionText = wait.Until(ExpectedConditions.ElementIsVisible(selection));

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
