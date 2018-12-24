using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace DEV_9.Pages
{
    /// <summary>
    /// Class MessagePage
    /// Page with messages.
    /// </summary>
    public class PageMessage
    {
        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//*[@id=\"im_dialogs\"]")] 
        [FindsBy(How = How.ClassName, Using = "nim-dialog_unread")]
        public IList<IWebElement> UnreadMessages { get; set; }
        
        /// <summary>
        /// End of the table of dialogs.
        /// It is necessary for the event signaling that the table with messages has loaded.
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//*[@id=\"content\"]/div/div[1]/div[3]")]
        public IWebElement EndTblMessage { get; set; }

        public PageMessage(IWebDriver webDriver)
        {
            // Using PageFactory.
            PageFactory.InitElements(webDriver, this);
            var wait = new WebDriverWait(webDriver,TimeSpan.FromSeconds(60));
            // Custom expected condition.
            wait.Until((d) => EndTblMessage.Enabled ? EndTblMessage : null);
        }
    }
}