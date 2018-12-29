using System;
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
        [TestCase("", "Брест", "26.12.18", 1)]
        [TestCase("МинСк","","26.12.18", 2)]
        [TestCase("Брест", "Минск","", 3)]
        public void PositiveTest(string departureStation, string destinationStation, string date, int invalidPosition)
        {
            var mainPage = new MainPage();
            var routeSelectionPage = new RouteSelectionPage();
            
            Assert.True(mainPage.GoToRoutePage(),
                "The \"Open route selection page\" button on the main page does not work.");
            Assert.IsFalse(routeSelectionPage.TryChooseRoute(departureStation,departureStation,destinationStation));
        }
    }
}