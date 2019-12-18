using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace WebAddressbookTest
{
    [TestFixture]
    public class GroupCreationTest : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
                
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
           string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(",");
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }
        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return (List<GroupData>) new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader(@"groups.xml"));
            
        }

        public static IEnumerable<GroupData> GroupDataFromJSONFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText(@"groups.json"));
        }


        [Test, TestCaseSource("GroupDataFromJSONFile")]
        public void GroupCreationTests(GroupData group)
        {
           

            List<GroupData> OldGroups = app.Groups.GetGroupList();

            app.Groups.CreateGroup(group);

            int count = app.Groups.GetGroupCount();
            Assert.AreEqual(OldGroups.Count + 1, count);

            List<GroupData> NewGroups = app.Groups.GetGroupList();
            OldGroups.Add(group);
            OldGroups.Sort();
            NewGroups.Sort();
            Assert.AreEqual(OldGroups, NewGroups);
            app.Navigator.BackToHomePage();
            app.auth.Logout();

            
        }
        /*        [Test]
                public void BadNameGroupCreationTests()
                {

                    GroupData group = new GroupData("a'a");
                    group.Header = "";
                    group.Footer = "";

                    List<GroupData> OldGroups = app.Groups.GetGroupList();

                    app.Groups.CreateGroup(group);
                   List<GroupData> NewGroups = app.Groups.GetGroupList();
                   OldGroups.Add(group);
                   OldGroups.Sort();
                   NewGroups.Sort();
                   Assert.AreEqual(OldGroups, NewGroups);
                   app.Navigator.BackToHomePage();
                   app.auth.Logout();
               }  */
    }
}
