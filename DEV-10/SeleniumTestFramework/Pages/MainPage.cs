using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumTestFramework.Pages
{
    public class MainPage : Page
    {
        private By UserBar = By.XPath("//*[@class=\"logo\"]//*[@class=\"user\"]");
        
        private By ButtonBar = By.XPath("//*[@class=\"center\"]//*[@class=\"tabs\"]");

        public IWebElement BtnLogin => Driver.FindElement(UserBar).FindElement(By.XPath("//*[contains(@onclick,\"login\")]"));

        public IWebElement BtnPageRouteSelection =>
            Driver.FindElement(ButtonBar).FindElement(By.XPath("//*[contains(@href,\"schedule\")]"));

        public void GoToLoginPage()
        {
            WaitUntil(BtnLogin).Click();
        }

      public MainPage(IWebDriver driver, TimeSpan defaultTimeSpan) : base(driver, defaultTimeSpan)
      {
          PageFactory.InitElements(Driver, this);
      }
    }
}