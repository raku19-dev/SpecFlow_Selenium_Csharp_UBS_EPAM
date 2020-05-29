using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlow_Csharp_EPAM.PageObjects
{
    public class ApplicationForm : PageObject
    {
        private readonly IWebDriver _driver;
        public IWebElement startUpHeader;
        public ApplicationForm(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void applicationIsStarted(string startUpText)
        {
            By startUpId = By.Id("ApplyPageHead");
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement startUpHeader = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(startUpId));
            Assert.AreEqual(startUpText, startUpHeader.Text);//(expected,actual)
        }


    }
}
