using System;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumTestFramework;
using SeleniumTestFramework.Pages;

namespace DEV_10
{
    [TestFixture]
    public class LoginTest
    {
        private  Browser _browser;
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
        }
        
        [TearDown]
        public void After()
        {
            _browser.Quit(); 
        }
        
        [Test]
        [TestCase("","sadfas","home/login_main", TestName = "Login empty test.")]
        [TestCase("dsdfsdf","","home/login_main", TestName = "Password empty test")]
        [TestCase("login", "password","home/login_main", TestName = "Invalid login/password test.")]
        
        public void CheckLogin(string login, string password, string expectedResult)
        {
            var mainPage = new MainPage(_browser.WebDriver,DefaultTimeSpan);
            PageFactory.InitElements(_browser.WebDriver, mainPage);
            mainPage.BtnLogin.Click();
            Assert.True(_browser.WebDriver.Url.Contains("home/login_main"),"The \"Login\" button on the main page does not work.");
            
            var loginPage = new LoginPage(_browser.WebDriver,DefaultTimeSpan);
            PageFactory.InitElements(_browser.WebDriver, loginPage);
            
            loginPage.WaitUntil(loginPage.TxtLogin).Click();
            loginPage.TxtLogin.Clear();
            loginPage.TxtLogin.SendKeys(login);
            
            loginPage.WaitUntil(loginPage.TxtPassword).Click();
            loginPage.TxtPassword.Clear();
            loginPage.TxtPassword.SendKeys(password);
            
            loginPage.WaitUntil(loginPage.BtnLogin).Click();
            Assert.True(_browser.WebDriver.Url.Contains(expectedResult));
        }
    }
}