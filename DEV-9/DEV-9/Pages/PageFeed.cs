using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace DEV_9.Pages
{
    /// <summary>
    /// Class FeedPage
    /// Class with feed.
    /// </summary>
    public class PageFeed : Page
    {
        public static readonly string Url = "https://vk.com/feed";
        
        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//*[@id=\"side_bar_inner\"]")]
        [FindsBy(How = How.CssSelector, Using = "#l_msg > a > span > span.left_label.inl_bl")]
        public IWebElement BtnMessage { get; set; }

        public PageFeed(IWebDriver webDriver) : base(webDriver)
        {
            // Using PageFactory.
            PageFactory.InitElements(webDriver, this);
        }

        public void GoToMessagePage()
        {
            WaitUntil(BtnMessage).Click();
        }
    }
}