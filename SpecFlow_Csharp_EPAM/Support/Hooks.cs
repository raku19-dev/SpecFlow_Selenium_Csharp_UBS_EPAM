using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace SpecFlow_Csharp_EPAM.Support
{
	[Binding]
    public class Hooks
    {
		private readonly IObjectContainer _objectContainer;
		private IWebDriver _driver;

		public Hooks(IObjectContainer objectContainer)
		{
			_objectContainer = objectContainer;
		}

		[BeforeScenario(Order = 0)]
		public void BeforeScenario()
		{
			_driver = new ChromeDriver("C:\\Selenium\\");
			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
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

		[TearDown]
		public void TearDown()
		{
			_driver.Quit();
			_driver.Dispose();
		}
	}
}
