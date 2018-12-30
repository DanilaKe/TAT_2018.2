using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumTestFramework.Pages
{
    public class RouteSelectionPage : Page
    {
        private const string ItineraryBoxLocator = "//*[@class=\"block_blue\"]";

        private const string DateBoxLocator = "//*[@class=\"block\"]";

        private const string ButtonBar = "//*[@class=\"btn\"]";
        
        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = ItineraryBoxLocator)]
        [FindsBy(How = How.XPath, Using = "//*[contains(@name,\"textDepStat\")]")]
        public IWebElement TxtDepartureStation { get; set; }
        
        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = ItineraryBoxLocator)]
        [FindsBy(How = How.XPath, Using = "//*[contains(@name,\"textArrStat\")]")]
        public IWebElement TxtDestinationStation { get; set; }
        
        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = ButtonBar)]
        [FindsBy(How = How.XPath, Using = "//*[contains(@id, \"buttonSearch\")]")]
        public IWebElement BtnSearch { get; set; }

        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = DateBoxLocator)]
        [FindsBy(How = How.XPath, Using = "//*[contains(@class, \"hasDatepicker\")]")]
        public IWebElement TxtDate { get; set; }

        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = DateBoxLocator)]
        [FindsBy(How = How.XPath, Using = "//a[contains(@href, \"btChange\")]")]
        private IList<IWebElement> BtnTimeRange { get; set;  }

        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = ItineraryBoxLocator)]
        [FindsBy(How = How.XPath, Using = "//*[contains(@onclick,\"textDepStat\")]")]
        public IList<IWebElement> BtnDefaultDepartureRouteStation { get; set; }
        
        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = ItineraryBoxLocator)]
        [FindsBy(How = How.XPath, Using = "//*[contains(@onclick,\"textArrStat\")]")]
        public IList<IWebElement> BtnDefaultDestinationRouteStation { get; set; }

        public static readonly string Url = "/rp/schedule";

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

        public void SetDefaultStation(IWebElement defaultStation)
        {
            WaitUntil(defaultStation).Click();
        }
        
        public RouteSelectionPage()
        {
            PageFactory.InitElements(Browser.WebDriver,this);
        }
    }
}