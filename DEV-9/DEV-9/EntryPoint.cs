using System;
using System.Threading;
using DEV_9.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

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
                if (pageLogin.TryLogin("", ""))
                {
                    new PageFeed(driver).TryGoToMessagePage();
                    foreach (var message in new PageMessage(driver).GetUnreadMessages())
                    {
                        Console.WriteLine(message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid login/password.");
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}