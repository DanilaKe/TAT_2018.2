using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace DEV10SeleniumTestFramework
{
    public class RouteSelectionPage : Page
    {
        /// <summary>
        /// This is a locator on an element with itinerary on this page.
        /// </summary>
        private const string ItineraryBoxLocator = "//*[@class=\"block_blue\"]";

        /// <summary>
        /// This is a locator on an element with date.
        /// </summary>
        private const string DateBoxLocator = "//*[@class=\"block\"]";

        /// <summary>
        /// This is a locator on an element with users buttons.
        /// </summary>
        private const string ButtonBar = "//*[@class=\"btn\"]";
        
        /// <summary>
        /// Departure station string element.
        /// </summary>
        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = ItineraryBoxLocator)]
        [FindsBy(How = How.XPath, Using = "//*[contains(@name,\"textDepStat\")]")]
        public IWebElement TxtDepartureStation { get; set; }
        
        /// <summary>
        /// Destination station string element.
        /// </summary>
        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = ItineraryBoxLocator)]
        [FindsBy(How = How.XPath, Using = "//*[contains(@name,\"textArrStat\")]")]
        public IWebElement TxtDestinationStation { get; set; }
        
        /// <summary>
        /// The search route button.
        /// </summary>
        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = ButtonBar)]
        [FindsBy(How = How.XPath, Using = "//*[contains(@id, \"buttonSearch\")]")]
        public IWebElement BtnSearch { get; set; }
        
        /// <summary>
        /// Date string element.
        /// </summary>
        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = DateBoxLocator)]
        [FindsBy(How = How.XPath, Using = "//*[contains(@class, \"hasDatepicker\")]")]
        public IWebElement TxtDate { get; set; }
        
        /// <summary>
        /// Buttons to select a time range.
        /// </summary>
        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = DateBoxLocator)]
        [FindsBy(How = How.XPath, Using = "//a[contains(@href, \"btChange\")]")]
        private IList<IWebElement> BtnTimeRange { get; set;  }

        /// <summary>
        /// Buttons a select default station.
        /// </summary>
        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = ItineraryBoxLocator)]
        [FindsBy(How = How.XPath, Using = "//*[contains(@onclick,\"textDepStat\")]")]
        public IList<IWebElement> BtnDefaultDepartureRouteStation { get; set; }
        
        /// <summary>
        /// Buttons a select default station.
        /// </summary>
        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = ItineraryBoxLocator)]
        [FindsBy(How = How.XPath, Using = "//*[contains(@onclick,\"textArrStat\")]")]
        public IList<IWebElement> BtnDefaultDestinationRouteStation { get; set; }
        
        /// <summary>
        /// Url of this page.
        /// </summary>
        public static readonly string Url = "/rp/schedule";
        
        /// <summary>
        /// Method TryChooseRoute
        /// Retrieves the necessary stations for the route and tries to find such a route.
        /// </summary>
        /// <param name="departureStation">String with departure station.</param>
        /// <param name="destinationStation">String with destination station.</param>
        /// <param name="date">String wit date.</param>
        /// <returns>Answers if you could find such a route.</returns>
        public bool TryChooseRoute(string departureStation,string destinationStation, string date)
        {
            WaitUntil(TxtDepartureStation).Click();
            TxtDepartureStation.SendKeys(departureStation);
            TxtDepartureStation.SendKeys(Keys.Escape);
            
            WaitUntil(TxtDestinationStation).Click();
            TxtDestinationStation.SendKeys(destinationStation);
            TxtDestinationStation.SendKeys(Keys.Escape);
            
            WaitUntil(TxtDate).Click();
            TxtDate.Clear();
            TxtDate.SendKeys(date);
            TxtDate.SendKeys(Keys.Escape);
            
            WaitUntil(BtnSearch).Click();

            return Browser.WebDriver
                       .FindElements(By.XPath("//div[contains(@id,\"359b\") and contains(@class,\"tabsl2_ch\")]"))
                       .Count == 1;
        }
        
        /// <summary>
        /// Method TrySetDefaultStation.
        /// Tries to establish a popular route.
        /// </summary>
        /// <returns>Answers whether it was possible to establish such a route.</returns>
        public bool TrySetDefaultStation(IWebElement defaultStation)
        {
            var expectedStation = defaultStation.Text;
            WaitUntil(defaultStation).Click();
            WaitUntil(BtnSearch).Click();

            return Page.WaitUntil(TxtDepartureStation).GetAttribute("value") == expectedStation ||
                   Page.WaitUntil(TxtDestinationStation).GetAttribute("value") == expectedStation;
        }

        /// <summary>
        /// Method TrySetTimeRange.
        /// Tries to set the desired time range.
        /// </summary>
        /// <returns>Answers whether it was possible to establish such a time range.</returns>
        public bool TrySetTimeRange(int leftBorder, int rightBorder)
        {
            if (leftBorder > rightBorder || leftBorder < 0 || rightBorder > 23)
                return false;
            WaitUntil(BtnTimeRange[0]).Click();
            WaitUntil(BtnTimeRange[leftBorder]).Click();
            WaitUntil(BtnTimeRange[rightBorder]).Click();

            return Browser.WebDriver.FindElements(By.XPath("//*[@class = \"block\"]//*[contains(@class,\"time_ch\")]"))
                       .Count == 23 - (rightBorder - leftBorder);
        }
        
        public RouteSelectionPage()
        {
            PageFactory.InitElements(Browser.WebDriver,this);
        }
    }
}