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
        [SetUp]
        public void SetUp()
        {
            if (!Browser.Initialised)
            {
                Browser.Initialize();
            }
            Browser.WebDriver.Navigate().GoToUrl("https://poezd.rw.by");   
        }
        
        [TearDown]
        public void After()
        {
            Browser.Quit(); 
        }
        
        [Test]
        [TestCase("","sadfas", TestName = "Login empty test.")]
        [TestCase("dsdfsdf","", TestName = "Password empty test")]
        [TestCase("login", "password", TestName = "Invalid login/password test.")]
        public void CheckLogin(string login, string password)
        {
            var mainPage = new MainPage();
            var loginPage = new LoginPage();
            
            Assert.True(mainPage.GoToLoginPage(),"The \"Login\" button on the main page does not work.");
            Assert.True(!loginPage.TryLogin(login, password));
        }
    }
}