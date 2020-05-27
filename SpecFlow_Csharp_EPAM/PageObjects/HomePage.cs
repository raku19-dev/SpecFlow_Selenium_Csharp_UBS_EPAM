﻿using OpenQA.Selenium;
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

        public void clickLinkMenu(String menuLink)
        {
            
            _driver.FindElement(By.LinkText(menuLink)).Click();
        }

        public void clickSubMenuItem(String menuLink, String subMenuLink)
        {
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
            _driver.SwitchTo().Frame(0);
            IWebElement handleCookie = _driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//span[contains(@class, 'actionbutton__txt')]")));
            handleCookie.Click();
            _driver.SwitchTo().ParentFrame();
        }
    }
}
