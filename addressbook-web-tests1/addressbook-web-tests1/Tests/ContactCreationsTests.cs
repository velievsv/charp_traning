using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace WebAddressbookTest
{
    [TestFixture]
    public class ContactCreate : AuthTestBase
    {
        
        [Test]
        public void ContactCreatingTest()
        {
            ContactData contact = new ContactData();
            contact.Middlename = "Veliev";
            contact.Lastname = "DontHaveLastName";
            contact.Firstname = "FirstName";

            List<ContactData> OldContacts = app.Contacts.GetContactList();
            app.Contacts.CreateContact(contact);

            List<ContactData> NewContacts = app.Contacts.GetContactList();
            Assert.AreEqual(OldContacts.Count + 1, NewContacts.Count);
        }
        [Test]
        public void BadNameContactCreatingTest()
        {
            ContactData contact = new ContactData();
            contact.Middlename = "a'a";
            contact.Lastname = "DontHaveLastName";
            contact.Firstname = "FirstName";

            List<ContactData> OldContacts = app.Contacts.GetContactList();
            app.Contacts.CreateContact(contact);

            List<ContactData> NewContacts = app.Contacts.GetContactList();
            Assert.AreEqual(OldContacts.Count + 1, NewContacts.Count);
        }
    }
}
