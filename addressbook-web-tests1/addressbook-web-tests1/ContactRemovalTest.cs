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
    [TestFixture]
    public class ContactRemovalTest : TestBase
    {
        [Test]
        public void ContactRemovalTests()
        {
            GoToHomePage();
            driver.FindElement(By.Name("user")).Clear();
            Login(new AccountData("admin","secret"));
            ClickToHomePageLink();
            SelectContactCheckboxNumber();
            ConfirmDeleteContactOnModalwindow();
            BackToHomePage();
        }
    }
}
