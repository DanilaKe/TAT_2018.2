using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTestFramework
{
    public static class Browser
    {
        public static IWebDriver WebDriver { get; set; }
        public static bool Initialised { get; set; }

        private const string ChromeDriverDirectory = "/home/danila";

        public static void Initialize()
        {
            WebDriver = new ChromeDriver(ChromeDriverDirectory);
            Initialised = true;
        }

        public static void Quit()
        {
            WebDriver.Quit();
            Initialised = false;
        }
    }
}