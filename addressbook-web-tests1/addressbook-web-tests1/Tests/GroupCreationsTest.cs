using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

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

  

        [Test, TestCaseSource("RandomGroupDataProvider")]
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
