using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SpecFlow_Csharp_EPAM.PageObjects
{
    public class User
    {
        private String email;

        public string Email { get => email; set => email = value; }

        private string password;

        public string Password { get => password; set => password = value; }

}
    public class SignInPopup : PageObject
    {
        private readonly IWebDriver _driver;
        private IWebElement email => _driver.FindElement(By.XPath("//input[@name='loginField']"));
        private IWebElement password => _driver.FindElement(By.Name("password"));
        private IWebElement signInButton => _driver.FindElement(By.Id("signInForm_BUTTON_4"));

        public SignInPopup(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public ApplicationForm Login()
        {
            User login = loadLoggingDataFromJsonFile();

            email.Clear();
            email.SendKeys(login.Email);

            password.Clear();
            password.SendKeys(login.Password);

            signInButton.Click();

            return new ApplicationForm(_driver);
        }

        private User loadLoggingDataFromJsonFile()//change it private method
        {
            string filePath = System.IO.Path.GetFullPath("test_data.json");

            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                User _user = System.Text.Json.JsonSerializer.Deserialize<User>(json);
                return _user;
            }
        }
    }
}
