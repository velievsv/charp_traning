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
        protected string baseURL;

        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }

        protected void DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
        }

        protected void SelectGroupCheckbox(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])["+ index +"]")).Click();
        }
        /* protected void ConfirmDeleteContactOnModalwindow()
        {
            acceptNextAlert = true;
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
        } */
        protected void SelectContactCheckboxNumber()
        {
            driver.FindElement(By.Id("12")).Click();
        }
        protected void ClickToHomePageLink()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }
    }

}

