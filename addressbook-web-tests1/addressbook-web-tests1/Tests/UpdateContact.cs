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
    public class UpdateContactTests : AuthTestBase
    {
       
        [Test]
        public void EditContact()
        {
            ContactData contact = new ContactData("FirstName", "MiddleName", "LastName");
            List<ContactData> OldContacts = app.Contacts.GetContactList();
            app.Contacts.EditContact(contact);

            int count = app.Contacts.GetContactCount();
            Assert.AreEqual(OldContacts.Count, count);

            List<ContactData> NewContacts = app.Contacts.GetContactList();
            OldContacts[0].Firstname = contact.Firstname;
            OldContacts[0].Lastname = contact.Lastname;
            OldContacts.Sort();
            NewContacts.Sort();
            Assert.AreEqual(OldContacts, NewContacts);
        }

        
    }
}
