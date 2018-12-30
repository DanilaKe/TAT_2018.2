using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumTestFramework.Pages
{
    public class MainPage : Page
    {
        /// <summary>
        /// This is an element locator with buttons for authorization on this page.
        /// </summary>
        const string UserBarLocator = "//*[@class=\"logo\"]//*[@class=\"user\"]";
        
        /// <summary>
        /// This is a locator on an item with buttons on this page.
        /// </summary>
        const string ButtonBarLocator = "//*[@class=\"center\"]//*[@class=\"tabs\"]";
        
        /// <summary>
        /// Button to go to tje login page.
        /// </summary>
        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = UserBarLocator)]
        [FindsBy(How = How.XPath, Using = "//*[contains(@onclick,\"login\")]")]
        private IWebElement BtnLogin { get; set; }
        
        /// <summary>
        /// Button to go to the route selection page.
        /// </summary>
        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = ButtonBarLocator)]
        [FindsBy(How = How.XPath, Using = "//*[contains(@href,\"schedule\")]")]
        private IWebElement BtnPageRouteSelection { get; set; }

        public bool TryGoToLoginPage()
        {
            WaitUntil(BtnLogin).Click();
            return Browser.WebDriver.Url.Contains(LoginPage.Url);
        }

        public bool TryGoToRoutePage()
        {
            WaitUntil(BtnPageRouteSelection).Click();
            return Browser.WebDriver.Url.Contains(RouteSelectionPage.Url);
        }

        public MainPage()
        {
            PageFactory.InitElements(Browser.WebDriver, this);
        }
    }
}