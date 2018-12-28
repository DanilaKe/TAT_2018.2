using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumTestFramework.Pages
{
    public class MainPage : Page
    {
        const string UserBarLocator = "//*[@class=\"logo\"]//*[@class=\"user\"]";
        
        const string ButtonBarLocator = "//*[@class=\"center\"]//*[@class=\"tabs\"]";

        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = UserBarLocator)]
        [FindsBy(How = How.XPath, Using = "//*[contains(@onclick,\"login\")]")]
        public IWebElement BtnLogin { get; set; }
        
        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = ButtonBarLocator)]
        [FindsBy(How = How.XPath, Using = "//*[contains(@href,\"schedule\")]")]
        public IWebElement BtnPageRouteSelection { get; set; }

        public bool GoToLoginPage()
        {
            WaitUntil(BtnLogin).Click();
            return Browser.WebDriver.Url.Contains(LoginPage.Url);
        }

        public MainPage()
        {
            PageFactory.InitElements(Browser.WebDriver, this);
        }
    }
}