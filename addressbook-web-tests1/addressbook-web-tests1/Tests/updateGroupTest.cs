using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace WebAddressbookTest
{
    [TestFixture]
    public class UpdateGroupTest : AuthTestBase
    {
        [Test]
        public void updateGroup()
        {
            if (!app.Groups.CheckBoxAvailable())
            {

                GroupData group1 = new GroupData("New_Group");
                group1.Header = "New_Head";
                group1.Footer = "New_Foot";

                app.Groups.CreateGroup(group1);
            }
            GroupData group = new GroupData("UpdateName");
            group.Header = null;
            group.Footer = null;

            List<GroupData> OldGroups = app.Groups.GetGroupList();
            GroupData oldData = OldGroups[0];

            app.Groups.UpdateGroup(group);

            int count = app.Groups.GetGroupCount();
            Assert.AreEqual(OldGroups.Count, count);
            List<GroupData> NewGroups = app.Groups.GetGroupList();

            OldGroups[0].Name = group.Name;
            OldGroups.Sort();
            NewGroups.Sort();
            Assert.AreEqual(OldGroups, NewGroups);

           foreach (GroupData group1 in NewGroups) // //Нельзя объявить group в данной локальной области. Как с этим справиться?
            {
                if (group1.id == oldData.id)
                {
                    Assert.AreEqual(oldData.Name, group1.Name);
                } 
            }
        }
    }
}
