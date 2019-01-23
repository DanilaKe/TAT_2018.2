using System;
using DEV_9.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DEV_9
{
    /// <summary>
    /// Class Entry point
    /// Using WebDriver, logs in and displays to the console a list of unread messages from all users.
    /// </summary>
    internal class EntryPoint
    {
        /// <summary>
        /// Method Main
        /// Entry point.
        /// </summary>
        public static void Main()
        {
            try
            {
                IWebDriver driver = new ChromeDriver("./DEV-9");
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://vk.com/");
                
                var pageLogin = new PageLogin(driver);
                pageLogin.Login("login", "password");
                new PageFeed(driver).GoToMessagePage();
                foreach (var message in new PageMessage(driver).GetUnreadMessages())
                {
                    Console.WriteLine(message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}