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
        private HomePage homePage;
        private DetailsPage detailsPage;

        private IWebDriver webDriver;

        [SetUp]
        public void Setup()
        {         
          var options = new ChromeOptions();
          options.AddArguments("headless"); 
          new DriverManager().SetUpDriver(new ChromeConfig(), "Latest", Architecture.X64);
          webDriver = new ChromeDriver(options);
          webDriver.Navigate().GoToUrl("https://example.testproject.io/");
          webDriver.Manage().Window.Maximize();
          homePage = new HomePage(webDriver);
          detailsPage = new DetailsPage(webDriver);
        }

        [TearDown]
        public void Teardown()
        {
            webDriver.Close();
            webDriver.Quit();
        }

        [Test]
        public void Test1()
        {
          homePage.Login("Mateusz Małolepszy", "12345");
          homePage.IsLoginSuccesful("Mateusz Małolepszy");
          detailsPage.FillDetails("Poland","Obornicka 115E/26","mateusz.malolepszy@gmail.com","783757710");
          detailsPage.AreDetailsSaved("Saved");
          detailsPage.GoBackToHomePage();
          homePage.IsLogoutSuccesful();
        }

        [Test]
        public void Test2()
        {
          homePage.Login("MM", "12345");
          homePage.IsLoginSuccesful("Mateusz Małolepszy");
          detailsPage.FillDetails("Poland","Obornicka 115E/26","mateusz.malolepszy@gmail.com","783757710");
          detailsPage.AreDetailsSaved("Saved");
          detailsPage.GoBackToHomePage();
          homePage.IsLogoutSuccesful();
        }

        [Test]
        public void Test3()
        {
          homePage.Login("MM", "12345");
          homePage.IsLoginSuccesful("Mateusz Małolepszy");
          detailsPage.FillDetails("Poland","Obornicka 115E/26","mateusz.malolepszy@gmail.com","783757710");
          detailsPage.AreDetailsSaved("Saved");
          detailsPage.GoBackToHomePage();
          homePage.IsLogoutSuccesful();
        }
    }
}
