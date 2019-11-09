﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTest
{
    [TestFixture]
    public class ContactTest : TestBase
    {
        [Test]
        public void TheContactTest()
        {
            GoToHomePage();
            Login(new AccountData("admin","secret"));
            GotoAddNewContactPage();
            FillContactForm(new ContactData("Eto","Pobeda"));
            InitNewContact();
            BackToHomePage();
        }
    }
}
