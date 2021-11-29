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
        private IWebDriver webDriver;
        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), "Latest", Architecture.X64);
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://example.testproject.io/");
            webDriver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            HomePage homePage = new HomePage(webDriver);
            DetalisPage detalisPage = new DetalisPage(webDriver);
            homePage.Login("Mateusz Małolepszy", "12345");
            homePage.IsLoginSuccesful("Mateusz Małolepszy");
            detalisPage.FillDetails("Poland","Obornicka 115E/26","mateusz.malolepszy@gmail.com","783757710");
            detalisPage.AreDetailsSaved("Saved");
            detalisPage.GoBackToHomePage();
            homePage.IsLogoutSuccesful();
        }

        [TearDown]
        public void Teardown()
        {
            webDriver.Quit();
        }
    }
}