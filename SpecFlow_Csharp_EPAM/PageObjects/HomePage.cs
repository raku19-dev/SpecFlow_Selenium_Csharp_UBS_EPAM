using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlow_Csharp_EPAM.PageObjects
{
    public class HomePage : PageObject
    {
        private readonly IWebDriver _driver;

        public HomePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void clickText(String linkText)
        {

        }
    }
}
