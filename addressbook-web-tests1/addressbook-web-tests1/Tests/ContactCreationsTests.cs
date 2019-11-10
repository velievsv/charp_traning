﻿using System;
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
            ContactData contact = new ContactData("Svyatoslav");
            contact.Middlename = "Veliev";
            contact.Lastname = "DontHaveLastName";
            app.Contacts.CreateContact(contact);
            
        }

    }
}
