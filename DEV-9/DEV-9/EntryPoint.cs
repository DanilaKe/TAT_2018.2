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
                
                var pageLogin = new PageLogin();
                PageFactory.InitElements(driver, pageLogin);
                pageLogin.TxtEmail.Click();
                pageLogin.TxtEmail.SendKeys("login");
                pageLogin.TxtPassword.Click();
                pageLogin.TxtPassword.SendKeys("password");
                pageLogin.BtnLogin.Click();
                
                var pageFeed = new PageFeed(driver);
                pageFeed.BtnMessage.Click();
                
                var pageMessage = new PageMessage(driver);
                foreach (var message in pageMessage.UnreadMessages)
                {
                    Console.WriteLine(message.Text);
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}