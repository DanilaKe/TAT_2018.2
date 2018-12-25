using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTestFramework.Pages
{
    public abstract class Page
    {
        protected  IWebDriver Driver;
        protected  TimeSpan DefaultTimeSpan;

        public Page(IWebDriver driver, TimeSpan defaultTimeSpan)
        {
            Driver = driver;
            DefaultTimeSpan = defaultTimeSpan;
        }

        public IWebElement WaitUntil(IWebElement ExpectedItem)
        {
            return new WebDriverWait(Driver, DefaultTimeSpan).Until((d) => ExpectedItem.Enabled ? ExpectedItem : null);
        }
    }
}