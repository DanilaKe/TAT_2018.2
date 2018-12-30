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
        [TestCase("", "Брест", "26.12.18")]
        [TestCase("МинСк","","26.12.18")]
        public void NegativeTest(string departureStation, string destinationStation, string date)
        {
            var mainPage = new MainPage();
            var routeSelectionPage = new RouteSelectionPage();
            
            Assert.True(mainPage.GoToRoutePage(),
                "The \"Open route selection page\" button on the main page does not work.");
            Assert.IsFalse(routeSelectionPage.TryChooseRoute(departureStation,destinationStation,date));
        }

        [Test]
        [TestCase("Минск","Брест","30.12.2018")]
        [TestCase("Брест", "Минск","")]
        public void PositiveTest(string departureStation, string destinationStation, string date)
        {
            var mainPage = new MainPage();
            var routeSelectionPage = new RouteSelectionPage();
            
            Assert.True(mainPage.GoToRoutePage(),
                "The \"Open route selection page\" button on the main page does not work.");
            Assert.True(routeSelectionPage.TryChooseRoute(departureStation,destinationStation,date));
        }

        [Test]
        public void DefaultDeparture()
        {
            var mainPage = new MainPage();
            var routeSelectionPage = new RouteSelectionPage();
            
            Assert.True(mainPage.GoToRoutePage(),
                "The \"Open route selection page\" button on the main page does not work.");
            
            foreach (var station in routeSelectionPage.BtnDefaultDepartureRouteStation)
            {
                routeSelectionPage.SetDefaultStation(station);
                PageFactory.InitElements(Browser.WebDriver, routeSelectionPage);
                
                Assert.True(routeSelectionPage.TxtDepartureStation.Text == station.Text);
            }
        }
    }
}