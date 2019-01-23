using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DEV_9.Pages
{
    public abstract class Page
    {
        protected IWebDriver _webDriver;

        protected Page(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
        
        private static readonly TimeSpan DefaultTimeSpan = TimeSpan.FromSeconds(10);

        public IWebElement WaitUntil(IWebElement ExpectedItem)
        {
            // Custom expected condition.
            return new WebDriverWait(_webDriver,DefaultTimeSpan).Until((d) => ExpectedItem.Enabled ? ExpectedItem : null);
        }
    }
}
