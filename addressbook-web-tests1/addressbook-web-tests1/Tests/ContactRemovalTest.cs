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
    public class RemoveContact : TestBase
    {

        [Test]
        public void RemoveContactTest()
        {
            app.Contacts.ChooseContactCheckboxOnHomePage();
            app.Contacts.SubmitDeleteOnHomePage();
            app.Contacts.AcceptDeleteContact();
        }


    }
}
