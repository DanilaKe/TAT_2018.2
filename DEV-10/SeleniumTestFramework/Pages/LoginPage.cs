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
        [FindsBy(How = How.XPath, Using = "//*[@id=\"login\"]")]
        public IWebElement TxtLogin { get; set; }
        
        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = ContentLocator)]
        [FindsBy(How = How.XPath, Using = "//*[@id=\"password\"]")]
        public IWebElement TxtPassword { get; set; }
        
        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = ContentLocator)]
        [FindsBy(How = How.XPath, Using = "//*[@class=\"btn\"]")]
        public IWebElement BtnLogin { get; set; }

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