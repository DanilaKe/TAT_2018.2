using System;
using DEV_9.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

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
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://vk.com/");
                
                var pageLogin = new PageLogin();
                PageFactory.InitElements(driver, pageLogin);
                pageLogin.TxtEmail.Click();
                pageLogin.TxtEmail.SendKeys("login");
                pageLogin.TxtPassword.Click();
                pageLogin.TxtPassword.SendKeys("password");
                pageLogin.BtnLogin.Click();
                
                var pageFeed = new PageFeed();
                PageFactory.InitElements(driver, pageFeed);
                pageFeed.BtnMessage.Click();
                
                var pageMessage = new PageMessage();
                PageFactory.InitElements(driver, pageMessage);

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