using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTaskAutomation.Helpers
{
    public class ManageDriver
    {
        public static IWebDriver driver;

        public static void InitializeDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.Manage().Window.Maximize();
        }

        public static void QuitDriver()
        {
            driver.Quit();
        }

    }
}
