using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace DEV_9.pages
{
    public class MessagePage
    { 
        By DialogLocator = By.XPath("//*[@id=\"im_dialogs\"]");
        private IWebDriver driver;

        private List<IWebElement> UnreadMessages; 

        public MessagePage(IWebDriver driver)
        {
            UnreadMessages = new List<IWebElement>();
            this.driver = driver;
        }

        private void FindUnreadMessages()
        {
            var unread = 
                driver.FindElement(DialogLocator).FindElements(By.ClassName("nim-dialog_unread"));
            foreach (var x in unread)
            {
                UnreadMessages.Add(x);
            }
        }

        public List<string> GetUnreadMessages()
        {
            try
            {
                FindUnreadMessages();
                foreach (var x in UnreadMessages)
                {
                    Console.WriteLine(x.Text);
                }
                return null;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}