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
        [Test]
        public void GroupCreationTests()
        {
            
            GroupData group = new GroupData("TestGroupCreate0911");
            group.Header = "NameOfHeader";
            group.Footer = "NameOfFotter";

            List<GroupData> OldGroups = app.Groups.GetGroupList();

            app.Groups.CreateGroup(group);
            List<GroupData> NewGroups = app.Groups.GetGroupList();
            Assert.AreEqual(OldGroups.Count + 1, NewGroups.Count);
            app.Navigator.BackToHomePage();
            app.auth.Logout();

            
        }
         [Test]
         public void BadNameGroupCreationTests()
         {

             GroupData group = new GroupData("a'a");
             group.Header = "";
             group.Footer = "";

             List<GroupData> OldGroups = app.Groups.GetGroupList();

             app.Groups.CreateGroup(group);
             List<GroupData> NewGroups = app.Groups.GetGroupList();
             Assert.AreEqual(OldGroups.Count + 1, NewGroups.Count);
             app.Navigator.BackToHomePage();
             app.auth.Logout();


         } 
        public void EmptyGroupCreationTests()
        {
            
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> OldGroups = app.Groups.GetGroupList();

            app.Groups.CreateGroup(group);
            List<GroupData> NewGroups = app.Groups.GetGroupList();
            Assert.AreEqual(OldGroups.Count + 1, NewGroups.Count);
            app.Navigator.BackToHomePage();
            app.auth.Logout();
        }
    }
}
