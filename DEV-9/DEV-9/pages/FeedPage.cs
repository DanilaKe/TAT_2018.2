using OpenQA.Selenium;

namespace DEV_9.pages
{
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
            driver.FindElement(MenuBarLocator).FindElement(By.Id("l_msg")).Click();
        }
    }
}