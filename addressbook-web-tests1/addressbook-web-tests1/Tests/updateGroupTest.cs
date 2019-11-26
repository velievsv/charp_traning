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

             foreach (GroupData group in NewGroups) // а здесь я не могу использовать group. Причина в том, что я по другому реализовал app.Groups.UpdateGroup(group); ??
            {
                if (group.id == oldData.id)
                {
                    Assert.AreEqual(group.Name, OldGroups[0].Name);
                } 
            }
        }
    }
}
