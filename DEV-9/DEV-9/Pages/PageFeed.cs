using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace DEV_9.Pages
{
    /// <summary>
    /// Class FeedPage
    /// Class with feed.
    /// </summary>
    public class PageFeed
    {
        [FindsBy(How = How.XPath, Using = "//*[@id=\"side_bar_inner\"]")]
        public IWebElement MenuBar { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"l_msg\"]")]
        public IWebElement BtnMessage { get; set; }
    }
}