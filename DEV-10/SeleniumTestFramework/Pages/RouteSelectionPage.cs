using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumTestFramework.Pages
{
    public class RouteSelectionPage : Page
    {
        [FindsBySequence]
        [FindsBy(How = How.ClassName, Using = "fields")]
        [FindsBy(How = How.XPath, Using = "tbody/tr[1]/td[1]/input")]
        public IWebElement TxtDepartureStation { get; set; }
        
        [FindsBySequence]
        [FindsBy(How = How.ClassName, Using = "fields")]
        [FindsBy(How = How.XPath, Using = "tbody/tr[3]/td[1]/input")]
        public IWebElement TxtDestinationStation { get; set; }
        
        [FindsBySequence]
        [FindsBy(How = How.ClassName, Using = "fields")]
        [FindsBy(How = How.ClassName, Using = "btn")]
        [FindsBy(How = How.XPath, Using = "input")]
        public IWebElement BtnSearch { get; set; }

        [FindsBySequence]
        [FindsBy(How = How.Id, Using = "dateInfo")]
        [FindsBy(How = How.XPath, Using = "tbody/tr[1]/td/input")]
        public IWebElement TxtDate { get; set; }

        [FindsBySequence]
        [FindsBy(How = How.ClassName, Using = "fields")]
        [FindsBy(How = How.CssSelector, Using = "tbody > tr:nth-child(1) > td:nth-child(5)")]
        public IList<IWebElement> BtnDefaultDepartureRouteStantion { get; set; }

        public static readonly string Url = "/rp/schedule";

        public RouteSelectionPage(IWebDriver driver, TimeSpan defaultTimeSpan) : base(driver, defaultTimeSpan) { }
    }
}