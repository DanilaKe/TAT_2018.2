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
        private IWebElement BtnLogin { get; set; }
        
        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = ButtonBarLocator)]
        [FindsBy(How = How.XPath, Using = "//*[contains(@href,\"schedule\")]")]
        private IWebElement BtnPageRouteSelection { get; set; }

        public bool GoToLoginPage()
        {
            WaitUntil(BtnLogin).Click();
            return Browser.WebDriver.Url.Contains(LoginPage.Url);
        }

        public bool GoToRoutePage()
        {
            WaitUntil(BtnPageRouteSelection).Click();
            return Browser.WebDriver.Url.Contains(RouteSelectionPage.Url);
        }

        public MainPage()
        {
            PageFactory.InitElements(Browser.WebDriver, this);
        }
    }
}