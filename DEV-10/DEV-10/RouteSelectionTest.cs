using NUnit.Framework;
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
        public void SetRouteNegativeTest(string departureStation, string destinationStation, string date)
        {
            var mainPage = new MainPage();
            var routeSelectionPage = new RouteSelectionPage();
            
            Assert.True(mainPage.TryGoToRoutePage(),
                "The \"Open route selection page\" button on the main page does not work.");
            Assert.IsFalse(routeSelectionPage.TryChooseRoute(departureStation,destinationStation,date));
        }

        [Test]
        [TestCase("Минск","Брест","30.12.2018")]
        [TestCase("Брест", "Минск","")]
        public void SetRoutePositiveTest(string departureStation, string destinationStation, string date)
        {
            var mainPage = new MainPage();
            var routeSelectionPage = new RouteSelectionPage();
            
            Assert.True(mainPage.TryGoToRoutePage(),
                "The \"Open route selection page\" button on the main page does not work.");
            Assert.True(routeSelectionPage.TryChooseRoute(departureStation,destinationStation,date));
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        public void DefaultDepartureTest(int positionOfButton)
        {
            var mainPage = new MainPage();
            var routeSelectionPage = new RouteSelectionPage();

            Assert.True(mainPage.TryGoToRoutePage(),
                "The \"Open route selection page\" button on the main page does not work.");
            
            var station = routeSelectionPage.BtnDefaultDepartureRouteStation[positionOfButton-1];
            Assert.True(routeSelectionPage.TrySetDefaultStation(station)); 
        }
        
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        public void DefaultDestinationTest(int positionOfButton)
        {
            var mainPage = new MainPage();
            var routeSelectionPage = new RouteSelectionPage();

            Assert.True(mainPage.TryGoToRoutePage(),
                "The \"Open route selection page\" button on the main page does not work.");
            
            var station = routeSelectionPage.BtnDefaultDestinationRouteStation[positionOfButton-1];
            Assert.True(routeSelectionPage.TrySetDefaultStation(station));
        }

        [Test]
        [TestCase(1, 2)]
        [TestCase(20, 23)]
        public void TimeRangeTest(int leftBorder, int rightBorder)
        {            
            var mainPage = new MainPage();
            var routeSelectionPage = new RouteSelectionPage();

            Assert.True(mainPage.TryGoToRoutePage(),
                "The \"Open route selection page\" button on the main page does not work.");
            
            Assert.True(routeSelectionPage.TrySetTimeRange(leftBorder,rightBorder));
        }
    }
}