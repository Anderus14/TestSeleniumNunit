using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace PagesModel
{
    public class DetalisPage
    {
        private readonly IWebDriver webDriver;
        private IWebElement CountryDropdown => webDriver.FindElement(By.Id("country"));
        private IWebElement Address => webDriver.FindElement(By.Id("address"));
        private IWebElement Email => webDriver.FindElement(By.Id("email"));
        private IWebElement Phone => webDriver.FindElement(By.Id("phone"));
        private IWebElement SaveButton => webDriver.FindElement(By.Id("save"));
        private IWebElement SavedLabel => webDriver.FindElement(By.Id("saved"));
        private IWebElement LogoutButton => webDriver.FindElement(By.Id("logout"));

        public DetalisPage(IWebDriver driver)
        {
            this.webDriver = driver;
        }

        public void FillDetails()
        {
            var selectCountry = new SelectElement(CountryDropdown);
            selectCountry.SelectByText("Poland");
            Address.SendKeys("Obornicka 115E/26");
            Email.SendKeys("mateusz.malolepszy@gmail.com");
            Phone.SendKeys("783757710");
            SaveButton.Click();
        }

        public bool AreDetailsSaved()
        {
            return SavedLabel.Text.Equals("Saved");
        }

        public void GoBackToHomePage()
        {
            LogoutButton.Click();
        }
    }
}
