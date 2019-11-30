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
            ContactData contact = new ContactData("FirstName","LastName");
            List<ContactData> OldContacts = app.Contacts.GetContactList();
            ContactData oldContactData = OldContacts[0];
            app.Contacts.EditContact(contact);

            int count = app.Contacts.GetContactCount();
            Assert.AreEqual(OldContacts.Count, count);

            List<ContactData> NewContacts = app.Contacts.GetContactList();
            OldContacts[0].Firstname = contact.Firstname;
            OldContacts[0].Lastname = contact.Lastname;
            OldContacts.Sort();
            NewContacts.Sort();
            Assert.AreEqual(OldContacts, NewContacts);
            foreach (ContactData contact1 in NewContacts) //Нельзя объявить contact в данной локальной области. Как с этим справиться?
            {
                if (contact1.id == oldContactData.id)
                {
                    Assert.AreEqual(oldContactData.Firstname, contact1.Firstname);

                }
            }
        }

        
    }
}
