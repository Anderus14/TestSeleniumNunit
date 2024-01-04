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
		private DynamicIDPage dynamicIDPage;
		private IWebDriver webDriver;

		[SetUp]
		public void Setup()
		{
			var options = new ChromeOptions();
			//options.AddArguments("headless"); 
			new DriverManager().SetUpDriver(new ChromeConfig(), "Latest", Architecture.X64);
			webDriver = new ChromeDriver(options);
			webDriver.Manage().Window.Maximize();
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
			webDriver.Navigate().GoToUrl("http://uitestingplayground.com/textinput");
			textInputPage = new TextInputPage(webDriver);
			Assert.That(textInputPage.Button.Text.Equals("Button That Should Change it's Name Based on Input Value"));
			textInputPage.EnterTextIntoInput("dupa");
			textInputPage.ClickButton();
			Assert.That(textInputPage.Button.Text.Equals("dupa"));
		}
		
		[Test]
		public void SecondTest()
		{
			webDriver.Navigate().GoToUrl("http://uitestingplayground.com/dynamicid");
			dynamicIDPage = new DynamicIDPage(webDriver);
			dynamicIDPage.CheckMainLabelTextAndVisiblity("Dynamic ID");
			dynamicIDPage.CheckDynamicIdButtonText("Button with Dynamic ID");
		}
	}
}
