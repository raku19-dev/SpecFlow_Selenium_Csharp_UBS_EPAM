using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using SpecFlow.Selenium.Factories;

namespace SpecFlow_Csharp_EPAM.Support
{
	[Binding]
    public class Hooks
    {
		private readonly IObjectContainer _objectContainer;
		private IWebDriver _driver;
		private static DriverFactory _driverFactory;

		public Hooks(IObjectContainer objectContainer)
		{
			_objectContainer = objectContainer;
		}

		[BeforeTestRun]
		public static void BeforeTestRun()
		{
			_driverFactory = new DriverFactory();
		}

		[BeforeScenario]
		public void BeforeScenario()
		{
			_driver = _driverFactory.CreateDriver(); ;
			//_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
			_driver.Manage().Window.Maximize();
			_objectContainer.RegisterInstanceAs(_driver);
		}

		//[AfterScenario]
		//public void AfterScenario(ScenarioContext scenarioContext)
		//{
		//	if (scenarioContext.TestError != null)
		//	{
		//		((ITakesScreenshot)_driver).GetScreenshot().SaveAsFile(Directory.GetCurrentDirectory(), ScreenshotImageFormat.Png);
		//	}
		//	_driver?.Dispose();
		//}

		[AfterScenario]
		public void TearDown()
		{
			//_driver.Dispose();
		}
	}
}
