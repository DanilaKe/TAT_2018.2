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

        public MainPage(IWebDriver driver, TimeSpan defaultTimeSpan) : base(driver, defaultTimeSpan)
        {
        }
    }
}