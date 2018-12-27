using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumTestFramework.Pages
{
    public class LoginPage : Page
    {
        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//*[@id=\"login\"]")]
        [FindsBy(How = How.Name, Using = "login")]
        public IWebElement TxtLogin { get; set; }
        
        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//*[@id=\"login\"]")]
        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement TxtPassword { get; set; }
        
        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//*[@id=\"login\"]")]
        [FindsBy(How = How.ClassName, Using = "btn")]
        public IWebElement BtnLogin { get; set; }

        public static readonly string Url = "home/login_main";

        public LoginPage(IWebDriver driver, TimeSpan defaultTimeSpan) : base(driver, defaultTimeSpan) { }
    }
}