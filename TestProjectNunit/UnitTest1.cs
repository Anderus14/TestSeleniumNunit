using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PagesModel;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace TestProjectNunit
{
		public class Tests
		{
		private TextInputPage textInputPage;

				private IWebDriver webDriver;

				[SetUp]
				public void Setup()
				{         
					var options = new ChromeOptions();
					//options.AddArguments("headless"); 
					new DriverManager().SetUpDriver(new ChromeConfig(), "Latest", Architecture.X64);
					webDriver = new ChromeDriver(options);
					webDriver.Navigate().GoToUrl("http://uitestingplayground.com/textinput");
					webDriver.Manage().Window.Maximize();
					textInputPage = new TextInputPage(webDriver);
				}

				[TearDown]
				public void Teardown()
				{
						webDriver.Close();
						webDriver.Quit();
				}

				[Test]
				public void FirstTest()
				{
						textInputPage.EnterTextIntoInput("dupa");
						textInputPage.ClickButton();
						Assert.That(textInputPage.Button.Text == "dupa");
				}
		}
}
