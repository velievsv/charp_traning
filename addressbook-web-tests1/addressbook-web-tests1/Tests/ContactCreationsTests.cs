
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace WebAddressbookTest
{
    [TestFixture]
    public class ContactCreate : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30)));
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromCsvFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(",");
                contacts.Add(new ContactData(parts[0])
                {
                    Lastname = parts[1],
                    Firstname = parts[2]
                });
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>) new XmlSerializer(typeof(List<ContactData>)).Deserialize(new StreamReader(@"contact.xml"));

        }

        public static IEnumerable<ContactData> ContactDataFromJSONFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText(@"contact.json"));

        }

        [Test,TestCaseSource("ContactDataFromJSONFile")]
        public void ContactCreatingTest(ContactData contact)
        {
            List<ContactData> OldContacts = app.Contacts.GetContactList();
            app.Contacts.CreateContact(contact);
            

            int Count = app.Contacts.GetContactCount();
            Assert.AreEqual(OldContacts.Count + 1, Count);
            
            List<ContactData> NewContacts = app.Contacts.GetContactList();
            OldContacts.Add(contact);
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
