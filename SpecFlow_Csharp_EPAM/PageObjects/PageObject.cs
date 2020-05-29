using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace SpecFlow_Csharp_EPAM.PageObjects
{
    public abstract class PageObject
    {
        private readonly OpenQA.Selenium.IWebDriver _driver;

        public PageObject(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Navigate(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void AssertTitle(string title)
        {
            string pageTitle = _driver.Title;
            Assert.Equals(title, pageTitle);//(expected, actual)
        }
    }
}
