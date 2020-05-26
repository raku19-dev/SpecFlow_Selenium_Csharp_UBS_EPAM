using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace SpecFlow_Csharp_EPAM.Support
{
	[Binding]
    public class Hooks
    {
		private IWebDriver _driver;

		[BeforeScenario(Order = 0)]
		public void BeforeScenario()
		{
			_driver = new ChromeDriver();
			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
			_driver.Manage().Window.Maximize();
		}

		[AfterScenario]
		public void AfterScenario(ScenarioContext scenarioContext)
		{
			if (scenarioContext.TestError != null)
			{
				((ITakesScreenshot)_driver).GetScreenshot().SaveAsFile(Directory.GetCurrentDirectory(), ScreenshotImageFormat.Png);
			}
			_driver?.Dispose();
		}

		[TearDown]
		public void TearDown()
		{
			_driver.Close();
		}
	}
}
