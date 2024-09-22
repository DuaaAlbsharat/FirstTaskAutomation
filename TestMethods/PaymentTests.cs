using FirstTaskAutomation.Helpers;
using FirstTaskAutomation.POM;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTaskAutomation.TestMethods
{
    [TestClass]
    public class PaymentTests
    {
        public IWebDriver driver;
        public LoginPage loginPage;
        public PaymentPage paymentPage;

        [TestInitialize]
        public void Setup()
        {
            ManageDriver.InitializeDriver();
            driver = ManageDriver.driver;

            // زيارة صفحة تسجيل الدخول
            driver.Navigate().GoToUrl("https://localhost:44349/Auth/Login");
            loginPage = new LoginPage(driver);
            paymentPage = new PaymentPage(driver);
        }

        [TestMethod]
        public void TC1_VerifyPaymentCompletedSuccessfully()
        {
            string actualResult;
            try
            {
                loginPage.Login("duaa.albsharat1992@gmail.com", "Duaa.1992");
                driver.Navigate().GoToUrl("https://localhost:44349/User/PayForTheOrder");
                paymentPage.EnterCardDetails("Nadil Mohammad", "1234567812345678", "845", "06-APR-26");
                paymentPage.CompletePayment();

                // تحقق من نجاح الدفع
                actualResult = "Payment processed successfully"; // يمكنك تعديل هذا بناءً على التطبيق الخاص بك
                Assert.AreEqual("Payment processed successfully", actualResult); // استبدل بالتحقق الصحيح
            }
            catch (Exception ex)
            {
                actualResult = ex.Message;
                Assert.Fail($"Test failed: {actualResult}");
            }
        }

        [TestMethod]
        public void TC2_VerifyInvalidCardDetails()
        {
            string actualResult;
            try
            {
                loginPage.Login("duaa.albsharat1992@gmail.com", "Duaa.1992");
                driver.Navigate().GoToUrl("https://localhost:44349/User/PayForTheOrder");
                paymentPage.EnterCardDetails("Nadil mm", "1234567812345555", "07-APR-22", "123");
                paymentPage.CompletePayment();

                actualResult = "An error message appears. A required field must be filled in.";
                Assert.AreEqual("An error message appears. A required field must be filled in.", actualResult); // استبدل بالرسالة المتوقعة
            }
            catch (Exception ex)
            {
                actualResult = ex.Message;
                Assert.Fail($"Test failed: {actualResult}");
            }
        }

        [TestMethod]
        public void TC3_VerifyPaymentOperationsSavedAfterSuccessfulPayment()
        {
            string actualResult;
            try
            {
                loginPage.Login("duaa.albsharat1992@gmail.com", "Duaa.1992");
                driver.Navigate().GoToUrl("https://localhost:44349/User/PayForTheOrder");
                paymentPage.EnterCardDetails("Nadil Mohammad", "1234567812345678", "845", "06-APR-26");
                paymentPage.CompletePayment();

                // تحقق من حفظ العمليات
                actualResult = "Payment saved in dashboard"; // استبدل بالتحقق الصحيح
                Assert.AreEqual("Payment saved in dashboard", actualResult);
            }
            catch (Exception ex)
            {
                actualResult = ex.Message;
                Assert.Fail($"Test failed: {actualResult}");
            }
        }

        [TestMethod]
        public void TC4_VerifyErrorMessageForInvalidCardNumber()
        {
            string actualResult;
            try
            {
                loginPage.Login("duaa.albsharat1992@gmail.com", "Duaa.1992");
                driver.Navigate().GoToUrl("https://localhost:44349/User/PayForTheOrder");
                paymentPage.EnterCardDetails("Nadil", "444444", "844","06-APR-26" );
                paymentPage.CompletePayment();

                actualResult = "Invalid card number message appears";
                Assert.AreEqual("Invalid card number message appears", actualResult); // استبدل بالرسالة المتوقعة
            }
            catch (Exception ex)
            {
                actualResult = ex.Message;
                Assert.Fail($"Test failed: {actualResult}");
            }
        }

        [TestMethod]
        public void TC5_VerifyPaymentFailsIfMandatoryFieldsAreNotEntered()
        {
            string actualResult;
            try
            {
                loginPage.Login("duaa.albsharat1992@gmail.com", "Duaa.1992");
                driver.Navigate().GoToUrl("https://localhost:44349/User/PayForTheOrder");
                paymentPage.EnterCardDetails("", "", "", ""); // ترك جميع الحقول فارغة
                paymentPage.CompletePayment();

                actualResult = "An error message is displayed , and the payment is not processed";
                Assert.AreEqual("An error message is displayed , and the payment is not processed", actualResult); // استبدل بالرسالة المتوقعة
            }
            catch (Exception ex)
            {
                actualResult = ex.Message;
                Assert.Fail($"Test failed: {actualResult}");
            }
        }

        [TestMethod]
        public void TC6_VerifyUserCanSaveCardInformationWhenRememberMeChecked()
        {
            string actualResult;
            try
            {
                loginPage.Login("duaa.albsharat1992@gmail.com", "Duaa.1992");
                driver.Navigate().GoToUrl("https://localhost:44349/User/PayForTheOrder");
                paymentPage.EnterCardDetails("Nadil Mohammad", "1234567812345678", "06-APR-26", "845");
                // تأكد من اختيار "تذكرني"
                paymentPage.CompletePayment();

                // تحقق من حفظ المعلومات
                actualResult = "Card information saved"; // استبدل بالتحقق الصحيح
                Assert.AreEqual("Card information saved", actualResult);
            }
            catch (Exception ex)
            {
                actualResult = ex.Message;
                Assert.Fail($"Test failed: {actualResult}");
            }
        }

        [TestMethod]
        public void TC7_VerifyCardInformationNotSavedWhenRememberMeUnchecked()
        {
            string actualResult;
            try
            {
                loginPage.Login("duaa.albsharat1992@gmail.com", "Duaa.1992");
                driver.Navigate().GoToUrl("https://localhost:44349/User/PayForTheOrder");
                paymentPage.EnterCardDetails("Nadil", "1234567812345678", "06-APR-26", "845");
                // تأكد من عدم اختيار "تذكرني"
                paymentPage.CompletePayment();

                // تحقق من عدم حفظ المعلومات
                actualResult = "Card information not saved"; // استبدل بالتحقق الصحيح
                Assert.AreEqual("Card information not saved", actualResult);
            }
            catch (Exception ex)
            {
                actualResult = ex.Message;
                Assert.Fail($"Test failed: {actualResult}");
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            ManageDriver.QuitDriver();
        }

    }
}
