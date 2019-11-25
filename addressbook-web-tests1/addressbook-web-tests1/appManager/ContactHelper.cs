﻿using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Text.RegularExpressions;
using System.Linq;

namespace WebAddressbookTest
{ 
public class ContactHelper : HelperBase
    { 
        public ContactHelper(ApplicationManager manager) : base(manager)
        {

        }

        public ContactHelper EditContact(ContactData contact)

        {
            manager.Navigator.GoToHomePage();
            ChooseContactAndClickEdit();
            UpdateContactForm(contact);
            ClickUpdateButton();
            GoToHomePage();
            return this;
        }

        public ContactHelper CreateContact(ContactData contact)
        {
            manager.Navigator.GotoAddNewContactPage();
            FillContactForm(contact);
            ConfirmContactCreate();
            manager.Navigator.BackToHomePage();
            return this;
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr.entry"));
            foreach (IWebElement element in elements)
            {
                element.FindElements(By.CssSelector("td.center"));
                contacts.Add(new ContactData(element.Text, element.Text,element.Text)); ;
            }
            return contacts;
        }

        public ContactHelper ClickToHomePageFromForm()
    {
        driver.FindElement(By.LinkText("home page")).Click();
            return this;
    }

        public ContactHelper ClickUpdateButton()
    {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper UpdateContactForm(ContactData contact)
        {
            type(By.Name("firstname"), contact.Firstname);
            type(By.Name("middlename"), contact.Middlename);
            return this;
        }

        

        public ContactHelper ChooseContactAndClickEdit()
        {
            if (!CheckCheckBoxAvailable())
            {
                ContactData contact = new ContactData("Lol","Lal","Lil");
                manager.Contacts.CreateContact(contact);
            }
            // driver.FindElement(By.XPath($"//table[@id='maintable']/а[.edit.php?id='{indexIdLink}']")).Click();
            // driver.FindElement(By.XPath($"//table[@id='maintable']/tbody/tr['{indexIdLink}']/td[8]/a/img")).Click();
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[2]/td[8]")).Click();

            return this;
        }

        public bool CheckCheckBoxAvailable()
        {
            return IsElementPresent(By.XPath("//table[@id='maintable']/tbody/tr[2]/td[8]"));
        }


        public ContactHelper GoToHomePage()
    {
        driver.FindElement(By.LinkText("home")).Click();
            return this;
        }

        public ContactHelper ConfirmContactCreate()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
           
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
            return this;
        }

         public ContactHelper ChooseContactCheckboxOnHomePage()
        {
            if (!CheckCheckBoxAvailable())
            {
                ContactData contact = new ContactData("Lol", "Lal","Lil");
                manager.Contacts.CreateContact(contact);
            }
            driver.FindElement(By.XPath($"(//input[@type='checkbox'])[1]")).Click();
            return this;
        }

        public ContactHelper SubmitDeleteOnHomePage()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }
        public ContactHelper AcceptDeleteContact()
        {
            acceptNextAlert = true;
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            return this;
        }
    }
}