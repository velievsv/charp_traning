﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTest
{
    [TestFixture]
    public class GroupRemoval : AuthTestBase
    {
       

        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.DeleteGroups();

            app.Navigator.GoToGroupePage();
            int count = app.Groups.GetGroupCount();
            Assert.AreEqual(oldGroups.Count - 1, count);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            GroupData tobeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.id, tobeRemoved.id);

            }
        }
    }
}
