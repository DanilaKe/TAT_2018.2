using OpenQA.Selenium;

namespace DEV_9.pages
{
    /// <summary>
    /// Class FeedPage
    /// Class with feed.
    /// </summary>
    public class FeedPage
    {
        By MenuBarLocator = By.XPath("//*[@id=\"side_bar_inner\"]");
        private IWebDriver driver;
        
        public FeedPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void OpenMessagePage()
        {
            driver.FindElement(By.XPath("//*[@id=\"l_msg\"]/a/span/span[3]")).Click();
        }
    }
}