using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace DEV_9.Pages
{
    /// <summary>
    /// Class LoginPage
    /// Page with login function.
    /// </summary>
    public class PageLogin
    {
        private IWebDriver _webDriver;
        
        [FindsBy(How = How.XPath, Using = "//*[@id=\"index_email\"]")]
        public IWebElement TxtEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"index_pass\"]")]
        public IWebElement TxtPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"index_login_button\"]")]
        public IWebElement BtnLogin { get; set; }

        public PageLogin(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            // Using PageFactory.
            PageFactory.InitElements(webDriver, this);
            var wait = new WebDriverWait(webDriver,TimeSpan.FromSeconds(60));
            // Custom expected condition.
            wait.Until((d) => BtnLogin.Displayed ? BtnLogin : null);
        }

        public bool TryLogin(string login,string password)
        {
            TxtEmail.Click();
            TxtEmail.SendKeys(login);
            TxtPassword.Click();
            TxtPassword.SendKeys(password);
            BtnLogin.Click();

            return _webDriver.Url  == PageFeed.Url;
        }
    }
}