using System;
using WebAddressbookTest;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
namespace Generate_data_webaddresbook
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            string format = args[2];
            string chooseTest = args[3];

            if (chooseTest == "group") 
            {
                List<GroupData> groups = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(20),
                        Footer = TestBase.GenerateRandomString(20)
                    });
                }
                if (format == "csv")
                {
                    writeGroupsToCsvFile(groups, writer);
                } else if (format == "xml")
                {
                    writeGroupsToXmlFile(groups, writer);
                } else if (format == "json")
                {
                    writeGroupsToJSONFile(groups, writer);
                } else
                {
                    System.Console.Out.Write("Unrecognized format" + format);
                }
                writer.Close();
            } else if (chooseTest == "contact")
            {
                List<ContactData> contacts = new List<ContactData>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(10))
                    {
                        Lastname = TestBase.GenerateRandomString(20),
                        Firstname = TestBase.GenerateRandomString(20)
                    });
                }
                if (format == "csv")
                {
                    writeContactToCsvFile(contacts, writer);
                }
                else if (format == "xml")
                {
                    writeContactToXmlFile(contacts, writer);
                }else if (format == "json")
                {
                    writeontactToJSONFile(contacts, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format" + format);
                }
                writer.Close();
            }
        }
        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(string.Format("${0},${1},${2}",
                group.Name, group.Header, group.Footer));
            }
        }

        static void writeContactToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(string.Format("${0},${1}",
               contact.Firstname,contact.Middlename));
            }
        }

        static void writeContactToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }
        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeGroupsToJSONFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }
        static void writeontactToJSONFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
