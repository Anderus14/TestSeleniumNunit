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

        public void FillDetails(string Country, string Address, string Email, string Phone)
        {
            var selectCountry = new SelectElement(CountryDropdown);
            selectCountry.SelectByText(Country);
            this.Address.SendKeys(Address);
            this.Email.SendKeys(Email);
            this.Phone.SendKeys(Phone);
            SaveButton.Click();
        }

        public bool AreDetailsSaved(string SavedLabel)
        {
            return this.SavedLabel.Text.Equals(SavedLabel);
        }

        public void GoBackToHomePage()
        {
            LogoutButton.Click();
        }
    }
}
