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
    public class RemoveContact : AuthTestBase
    {

        [Test]
        public void RemoveContactTest()
        {
            List<ContactData> OldContacts = app.Contacts.GetContactList();
            app.Contacts.ChooseContactCheckboxOnHomePage();
            app.Contacts.SubmitDeleteOnHomePage();
            app.Contacts.AcceptDeleteContact();

            int count = app.Contacts.GetContactCount();
            Assert.AreEqual(OldContacts.Count - 1, count);



            List<ContactData> NewContacts = app.Contacts.GetContactList();
            ContactData tobeRemoved = OldContacts[0];
            OldContacts.RemoveAt(0);
            OldContacts.Sort();
            NewContacts.Sort();
            Assert.AreEqual(OldContacts, NewContacts);
            
            foreach (ContactData contact in NewContacts)
            {
                Assert.AreNotEqual(contact.id, tobeRemoved.id);
            }
        }


    }
}
