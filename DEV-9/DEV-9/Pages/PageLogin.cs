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
    public class PageLogin : Page
    {
        [FindsBy(How = How.XPath, Using = "//*[@id=\"index_email\"]")]
        public IWebElement TxtEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"index_pass\"]")]
        public IWebElement TxtPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"index_login_button\"]")]
        public IWebElement BtnLogin { get; set; }

        public PageLogin(IWebDriver webDriver) : base(webDriver)
        {
            // Using PageFactory.
            PageFactory.InitElements(webDriver, this);
        }

        public void Login(string login,string password)
        {
            WaitUntil(TxtEmail).Click();
            TxtEmail.SendKeys(login);
            WaitUntil(TxtPassword).Click();
            TxtPassword.SendKeys(password);
            WaitUntil(BtnLogin).Click();
        }
    }
}