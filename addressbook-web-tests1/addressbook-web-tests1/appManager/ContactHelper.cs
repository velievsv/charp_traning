using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Text.RegularExpressions;


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

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string Email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string Email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string Email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(lastName, firstName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = Email,
                Email2 = Email2,
                Email3 = Email3
            };
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
                string lastName = cells[1].Text;
                string firstName = cells[2].Text;
                string address = cells[3].Text;
                string allEmail = cells[4].Text;
                string allPhones = cells[5].Text;

            return new ContactData(lastName, firstName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmail = allEmail
            };

        }

       /* public ContactData GetContactInformationFromDetails(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactDetails(0);


        

        } */


        private void InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
        }

        private void InitContactDetails(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
              .FindElements(By.TagName("td"))[6]
              .FindElement(By.TagName("a")).Click();
        }

        public int GetContactCount()
        {
            manager.Navigator.GoToHomePage();
            return driver.FindElements(By.XPath("//tr[@name='entry']")).Count;
        }

        public ContactHelper CreateContact(ContactData contact)
        {
            manager.Navigator.GotoAddNewContactPage();
            FillContactForm(contact);
            ConfirmContactCreate();
            manager.Navigator.BackToHomePage();
            return this;
        }

        private List<ContactData> contactCash = null;

        public List<ContactData> GetContactList()
        {
            if (contactCash == null)
            {
                contactCash = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));
                foreach (IWebElement element in elements)
                {

                    var cells = element.FindElements(By.XPath("./td"));
                    contactCash.Add(new ContactData(cells[1].Text, cells[2].Text) { id = element.FindElement(By.TagName("input")).GetAttribute("value") });
                }
            }
            return new List<ContactData>(contactCash);
        }

        public ContactHelper ClickToHomePageFromForm()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        public ContactHelper ClickUpdateButton()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCash = null;
            return this;
        }

        public ContactHelper UpdateContactForm(ContactData contact)
        {
            type(By.Name("firstname"), contact.Firstname);
            type(By.Name("lastname"), contact.Lastname);
            return this;
        }



        public ContactHelper ChooseContactAndClickEdit()
        {


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
            contactCash = null;
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {

            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);

            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            return this;
        }

        public ContactHelper ChooseContactCheckboxOnHomePage()
        {
            driver.FindElement(By.XPath($"(//input[@type='checkbox'])[1]")).Click();
            contactCash = null;
            return this;
        }

        public ContactHelper SubmitDeleteOnHomePage()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCash = null;
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
