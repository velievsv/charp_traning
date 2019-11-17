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
    public class ContactCreate : TestBase
    {
        
        [Test]
        public void ContactCreatingTest()
        {
            ContactData contact = new ContactData();
            contact.Middlename = "Veliev";
            contact.Lastname = "DontHaveLastName";
            contact.Firstname = "FirstName";
            app.Contacts.CreateContact(contact);
            
        }

    }
}
