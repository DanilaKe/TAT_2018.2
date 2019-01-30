using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace DEV10SeleniumTestFramework
{
    /// <summary>
    /// Class LoginPage.
    /// PageObject.
    /// </summary>
    public class LoginPage : Page
    {
        /// <summary>
        /// This is a locator on an element with content on this page.
        /// </summary>
        const string ContentLocator = "//*[@class=\"content\"]";
        
        /// <summary>
        /// Login string element.
        /// </summary>
        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = ContentLocator)]
        [FindsBy(How = How.XPath, Using = "//*[@name=\"login\"]")]
        private IWebElement TxtLogin { get; set; }
        
        /// <summary>
        /// Password string element.
        /// </summary>
        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = ContentLocator)]
        [FindsBy(How = How.XPath, Using = "//*[@name=\"password\"]")]
        private IWebElement TxtPassword { get; set; }
        
        /// <summary>
        /// The submit button.
        /// </summary>
        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = ContentLocator)]
        [FindsBy(How = How.XPath, Using = "//*[@class=\"btn\"]")]
        private IWebElement BtnLogin { get; set; }
        
        /// <summary>
        /// Url of the this page.
        /// </summary>
        public static readonly string Url = "home/login_main";

        /// <summary>
        /// Method TryLogin
        /// Gets login and password, and try login in site.
        /// </summary>
        /// <param name="login">String with login</param>
        /// <param name="password">String with password.</param>
        /// <returns>Answers whether you managed to enter.</returns>
        public bool TryLogin(string login, string password)
        {
            WaitUntil(TxtLogin).Click();
            TxtLogin.Clear();
            TxtLogin.SendKeys(login);
            
            WaitUntil(TxtPassword).Click();
            TxtPassword.Clear();
            TxtPassword.SendKeys(password);
            
            WaitUntil(BtnLogin).Click();
            return Browser.WebDriver.Url.Contains(BuyTicketPage.Url);
        }
        
        public LoginPage()
        {
            PageFactory.InitElements(Browser.WebDriver, this);
        }
    }
}