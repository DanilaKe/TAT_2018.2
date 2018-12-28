using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTestFramework.Pages
{
    public abstract class Page
    {
        private static readonly TimeSpan DefaultTimeSpan = TimeSpan.FromSeconds(10);

        public static IWebElement WaitUntil(IWebElement ExpectedItem)
        {
            return new WebDriverWait(Browser.WebDriver,DefaultTimeSpan).Until((d) => ExpectedItem.Enabled ? ExpectedItem : null);
        }
    }
}
