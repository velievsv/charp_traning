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
    public class UpdateContactTests : AuthTestBase
    {
       
        [Test]
        public void EditContact()
        {
            ContactData contact = new ContactData();
            contact.Middlename = "Update1";
            contact.Lastname = "Update2";
            contact.Firstname = "Update3";
            app.Contacts.EditContact(contact);
        }

        
    }
}
