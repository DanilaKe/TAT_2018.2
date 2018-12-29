using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumTestFramework.Pages
{
    public class LoginPage : Page
    {
        const string ContentLocator = "//*[@class=\"content\"]";

        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = ContentLocator)]
        [FindsBy(How = How.XPath, Using = "//*[@name=\"login\"]")]
        private IWebElement TxtLogin { get; set; }
        
        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = ContentLocator)]
        [FindsBy(How = How.XPath, Using = "//*[@name=\"password\"]")]
        private IWebElement TxtPassword { get; set; }
        
        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = ContentLocator)]
        [FindsBy(How = How.XPath, Using = "//*[@class=\"btn\"]")]
        private IWebElement BtnLogin { get; set; }

        public static readonly string Url = "home/login_main";

        public bool TryLogin(string login, string password)
        {
            WaitUntil(TxtLogin).Click();
            TxtLogin.Clear();
            TxtLogin.SendKeys(login);
            
            WaitUntil(TxtPassword).Click();
            TxtPassword.Clear();
            TxtPassword.SendKeys(password);
            
            WaitUntil(BtnLogin).Click();
            return Browser.WebDriver.Url.Contains(BuyTicketPage.Url);
        }
        
        public LoginPage()
        {
            PageFactory.InitElements(Browser.WebDriver, this);
        }
    }
}