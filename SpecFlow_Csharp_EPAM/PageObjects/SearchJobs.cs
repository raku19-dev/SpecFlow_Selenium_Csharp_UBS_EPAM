using OpenQA.Selenium;
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
    }
}
