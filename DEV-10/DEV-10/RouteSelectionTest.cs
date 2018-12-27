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
    public class RouteSelectionTest
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
        [TestCase("", "Брест", "26.12.18", 1)]
        [TestCase("МинСк","","26.12.18", 2)]
        [TestCase("Брест", "Минск","", 3)]
        [TestCase("Брест", "Минск","26.12.18", 0)]
        public void PositiveTest(string departureStation, string destinationStation, string date, int invalidPosition)
        {
            var mainPage = new MainPage(_browser.WebDriver,DefaultTimeSpan);
            PageFactory.InitElements(_browser.WebDriver, mainPage);
            mainPage.WaitUntil(mainPage.BtnPageRouteSelection).Click();
            
            Assert.True(_browser.WebDriver.Url.Contains(RouteSelectionPage.Url),
                "The \"Open route selection page\" button on the main page does not work.");
            var routeSelectionPage = new RouteSelectionPage(_browser.WebDriver, DefaultTimeSpan);
            PageFactory.InitElements(_browser.WebDriver,routeSelectionPage);
            
            routeSelectionPage.WaitUntil(routeSelectionPage.TxtDepartureStation).Click();
            routeSelectionPage.TxtDepartureStation.SendKeys(departureStation);
            routeSelectionPage.TxtDepartureStation.SendKeys(Keys.Escape);
            
            routeSelectionPage.WaitUntil(routeSelectionPage.TxtDestinationStation).Click();
            routeSelectionPage.TxtDestinationStation.SendKeys(destinationStation);
            routeSelectionPage.TxtDestinationStation.SendKeys(Keys.Escape);
            
            routeSelectionPage.WaitUntil(routeSelectionPage.BtnSearch).Click();

         /*   if (!Assert.True(_browser.WebDriver.Url.Contains()))
            {
                Assert.True();
            }*/
            
        }
    }
}