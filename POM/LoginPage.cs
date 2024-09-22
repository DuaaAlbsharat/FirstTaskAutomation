using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTaskAutomation.POM
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Login(string email, string password)
        {
            driver.FindElement(By.XPath("//div/input[@id='Email']")).SendKeys(email);
            driver.FindElement(By.XPath("//div/input[@id='myPass1']")).SendKeys(password);
            driver.FindElement(By.XPath("/html/body/section/div/div/div[2]/form/div[6]/button")).Click();
        }
    }
}
