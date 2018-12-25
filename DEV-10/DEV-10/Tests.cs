using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumTestFramework;
using SeleniumTestFramework.Pages;

namespace DEV_10
{
    [TestFixture]
    public class Tests
    {
        private  Browser _browser;
        private MainPage _mainPage;
        private LoginPage _loginPage;
        private static readonly TimeSpan DefaultTimeSpan = TimeSpan.FromSeconds(10);
        
        [SetUp]
        public void SetUp()
        {
            if (_browser == null || _browser.Initialised == false)
            {
                _browser = new Browser();
                _browser.Initialize();
            }
            _browser.WebDriver.Manage().Window.Maximize();
            _browser.WebDriver.Navigate().GoToUrl("https://poezd.rw.by");   

            _mainPage = new MainPage(_browser.WebDriver,TimeSpan.FromSeconds(10));
            _loginPage = new LoginPage(_browser.WebDriver,TimeSpan.FromSeconds(10));
        }
        
        [TearDown]
        public void After()
        {
            _browser.Quit(); 
        }
        
        [Test]
        [TestCase("","sadfas","home/login_main")]
        [TestCase("dsdfsdf","","home/login_main")]
        [TestCase("login", "password","home/login_main")]
        public void CheckLogin(string login, string password, string expectedResult)
        {
            PageFactory.InitElements(_browser.WebDriver, _mainPage);
            _mainPage.BtnLogin.Click();
            Assert.True(_browser.WebDriver.Url.Contains("home/login_main"),"The \"Login\" button on the main page does not work.");
            PageFactory.InitElements(_browser.WebDriver, _loginPage);
            
            _loginPage.WaitUntil(_loginPage.TxtLogin).Click();
            _loginPage.TxtLogin.Clear();
            _loginPage.TxtLogin.SendKeys(login);
            
            _loginPage.WaitUntil(_loginPage.TxtPassword).Click();
            _loginPage.TxtPassword.Clear();
            _loginPage.TxtPassword.SendKeys(password);
            
            _loginPage.WaitUntil(_loginPage.BtnLogin).Click();
            Assert.True(_browser.WebDriver.Url.Contains(expectedResult));
            
        }
    }
}