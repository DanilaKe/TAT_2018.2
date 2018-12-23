using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace DEV_9.Pages
{
    /// <summary>
    /// Class MessagePage
    /// Page with messages.
    /// </summary>
    public class PageMessage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id=\"im_dialogs\"]")] 
        public IWebElement TblDialogs { get; set; }
        
        [FindsByAll]
        [FindsBySequence]
        [FindsBy(How = How.XPath, Using = "//*[@id=\"im_dialogs\"]")] 
        [FindsBy(How = How.ClassName, Using = "nim-dialog_unread")]
        public List<IWebElement> UnreadMessages { get; set; }
    }
}