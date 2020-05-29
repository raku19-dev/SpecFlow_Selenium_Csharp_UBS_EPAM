using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
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

        public void clickMenuItem(String menuLink, String subMenuLink)
        {
            _driver.FindElement(By.LinkText(menuLink)).Click();
            Actions actions = new Actions(_driver);
            IWebElement menuHoverLink = _driver.FindElement(By.LinkText(menuLink));
            actions.MoveToElement(menuHoverLink).Perform();

            IWebElement subLink = _driver.FindElement(By.LinkText(subMenuLink));
            actions.MoveToElement(subLink);
            actions.Click();
            actions.Perform();

        }

        public void handlePrivacySettings()
        {
            WebDriverWait _driverWait =  new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            //_driverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("doc")));
            _driver.SwitchTo().Frame(0);
            IWebElement handleCookieButton = _driverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(@class, 'actionbutton__txt')]")));
            handleCookieButton.Click();
            _driver.SwitchTo().ParentFrame();
        }
    }
}
