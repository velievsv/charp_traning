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
            ContactData contact = new ContactData("FirstName", "MiddleName", "LastName");

            List<ContactData> OldContacts = app.Contacts.GetContactList();
            app.Contacts.CreateContact(contact);
            

            int Count = app.Contacts.GetContactCount();
            Assert.AreEqual(OldContacts.Count + 1, Count);
            
            List<ContactData> NewContacts = app.Contacts.GetContactList();
           // OldContacts.Add(contact);
            OldContacts.Sort();
            NewContacts.Sort();
            Assert.AreEqual(OldContacts, NewContacts);
        }
        /*[Test]
        public void BadNameContactCreatingTest()
        {
            ContactData contact = new ContactData("a'a","DontHaveLastName","FirstName");


            List<ContactData> OldContacts = app.Contacts.GetContactList();
            app.Contacts.CreateContact(contact);

            List<ContactData> NewContacts = app.Contacts.GetContactList();
            Assert.AreEqual(OldContacts.Count + 1, NewContacts.Count);
        } */
    }
}
