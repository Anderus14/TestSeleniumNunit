using OpenQA.Selenium;
using System;

namespace PagesModel
{
    public class HomePage
    {
        private readonly IWebDriver webDriver;
        private IWebElement Name => webDriver.FindElement(By.Id("name"));
        private IWebElement Password => webDriver.FindElement(By.Id("password"));
        private IWebElement LoginButton => webDriver.FindElement(By.Id("login"));
        private IWebElement DisplayName => webDriver.FindElement(By.Id("greetings"));
        private IWebElement HomePageLabel => webDriver.FindElement(By.Id("pageLogin"));
        public HomePage(IWebDriver driver)
        {
            this.webDriver = driver;
        }

        public void Login()
        {
            Name.SendKeys("Mateusz Małolepszy");
            Password.SendKeys("12345");
            LoginButton.Click();
        }

        public bool IsLoginSuccesful()
        {
            return DisplayName.Text.Equals("Mateusz Małolepszy");
        }

        public bool IsLogoutSuccesful()
        {
            if(HomePageLabel.Text.Contains("TestProject Example page") || HomePageLabel.Text.Contains("This is the TestProject playground website. Feel free to play around it :)"))
            {
                return true;
            }
            return false;
        }
    }
}
