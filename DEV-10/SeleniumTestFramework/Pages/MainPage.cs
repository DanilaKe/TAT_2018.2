using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumTestFramework.Pages
{
    public class MainPage : Page
    {
        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//*[@id=\"top\"]/div/div")]
        [FindsBy(How = How.ClassName, Using = "status")]
        [FindsBy(How = How.TagName, Using = "nobr")]
        public IWebElement BtnLogin { get; set; }
        
        [FindsBySequence]
        [FindsBy(How = How.ClassName, Using = "tabs")]
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[2]/div[1]/div[1]/div/div/a")]
        public IWebElement BtnPageRouteSelection { get; set; }
        
        public MainPage(IWebDriver driver, TimeSpan defaultTimeSpan) : base(driver, defaultTimeSpan)
        {
        }
    }
}