using OpenQA.Selenium;

namespace PagesModel
{
    public class TextInputPage
    {
        private readonly IWebDriver _webDriver;
        public IWebElement TextInput => _webDriver.FindElement(By.Id("newButtonName"));
        public IWebElement Button => _webDriver.FindElement(RelativeBy.WithLocator(By.TagName("button")).Below(By.Id("newButtonName")));

        public TextInputPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void EnterTextIntoInput(string text)
        {
            TextInput.SendKeys(text);
        }

        public void ClickButton()
        {
            Button.Click();
        }
    }
}