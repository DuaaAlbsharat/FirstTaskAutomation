using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTaskAutomation.POM
{
    public class PaymentPage
    {
        public IWebDriver driver;

        public PaymentPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnterCardDetails(string name, string cardNumber, string cvv, string expiry)
        {
            driver.FindElement(By.XPath("//div/input[@name='cardholderame']")).SendKeys(name);
            driver.FindElement(By.XPath("//div/input[@name='cardNumber']")).SendKeys(cardNumber);
            driver.FindElement(By.XPath("//div/input[@name='cvv']")).SendKeys(cvv);
            driver.FindElement(By.XPath("//input[@name='expire']")).SendKeys(expiry);
        }

        public void CompletePayment()
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }
        //public string GetErrorMessage()
        //{
        //    return "An error has occurred. Please check your inputs and try again."; // Fixed error message
        //}


    }
}
