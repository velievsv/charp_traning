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
    public class UpdateContact : TestBase
    {
       
        [Test]
        public void EditContact()
        {
            app.Contacts.EditContact();
        }

        
    }
}
