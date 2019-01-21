using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace DEV_9.Pages
{
    /// <summary>
    /// Class FeedPage
    /// Class with feed.
    /// </summary>
    public class PageFeed
    {
        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//*[@id=\"side_bar_inner\"]")]
        [FindsBy(How = How.CssSelector, Using = "#l_msg > a > span > span.left_label.inl_bl")]
        public IWebElement BtnMessage { get; set; }

        public PageFeed(IWebDriver webDriver)
        {
            // Using PageFactory.
            PageFactory.InitElements(webDriver, this);
            var wait = new WebDriverWait(webDriver,TimeSpan.FromSeconds(60));
            // Custom expected condition.
            wait.Until((d) => BtnMessage.Displayed ? BtnMessage : null);
        }
    }
}