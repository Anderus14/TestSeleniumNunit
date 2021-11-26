using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PagesModel;

namespace TestProjectNunit
{
    public class Tests
    {
        private readonly IWebDriver webDriver = new ChromeDriver();
        [SetUp]
        public void Setup()
        {
            webDriver.Navigate().GoToUrl("https://example.testproject.io/");
            webDriver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            HomePage homePage = new HomePage(webDriver);
            DetalisPage detalisPage = new DetalisPage(webDriver);
            homePage.Login();
            homePage.IsLoginSuccesful();
            detalisPage.FillDetails();
            detalisPage.AreDetailsSaved();
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