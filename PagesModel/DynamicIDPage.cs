using NUnit.Framework;
using OpenQA.Selenium;

namespace PagesModel
{
	public class DynamicIDPage
	{
		private readonly IWebDriver _webdriver;

		public IWebElement DynamicIDLabel => _webdriver.FindElement(By.TagName("h3"));
		public IWebElement PlaygroundLabel => _webdriver.FindElement(By.TagName("h4"));
		public IWebElement ButtonWithDynamicId => _webdriver.FindElement(RelativeBy.WithLocator(By.TagName("button")).Below(PlaygroundLabel));
		
		public DynamicIDPage(IWebDriver webdriver)
		{
			_webdriver = webdriver;
		}
		
		public void CheckMainLabelTextAndVisiblity(string text)
		{
			Assert.That(DynamicIDLabel.Displayed);
			Assert.That(DynamicIDLabel.Enabled);
			Assert.That(DynamicIDLabel.Text.Equals(text));
		}
		
		public void CheckDynamicIdButtonText(string text)
		{
			Assert.That(ButtonWithDynamicId.Displayed);
			Assert.That(ButtonWithDynamicId.Enabled);
			Assert.That(ButtonWithDynamicId.Text.Equals(text));
		}
	}
}