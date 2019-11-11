using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTest
{
   public class TestBase
    {
        protected IWebDriver driver;
        protected ApplicationManager app;
        private StringBuilder verificationErrors;
        protected bool acceptNextAlert = true;
        

        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();
            app.Navigator.GoToHomePage();
            app.auth.Login(new AccountData("admin", "secret"));
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
            Assert.AreEqual("", verificationErrors.ToString());
        }

    }

}

