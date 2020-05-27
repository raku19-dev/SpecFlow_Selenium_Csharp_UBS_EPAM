using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlow_Csharp_EPAM.PageObjects
{
    public class JobBoard : PageObject
    {
        private readonly IWebDriver _driver;

        public JobBoard(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void clickLinkForEMEA(string jobType)
        {
            //Actions actions = new Actions(_driver);
           // actions.MoveToElement(_EMEAWebElement);
            //actions.Perform();
            _EMEAWebElement.FindElement(By.LinkText(jobType)).Click();
        }

        public IWebElement _EMEAWebElement => _driver.FindElement(By.XPath("//div[contains(string(),\"Europe, Middle East, Africa(excl.Switzerland)\"])"));
    }
}
