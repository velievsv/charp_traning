using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTest
{
    [TestFixture]
    public class UpdateGroupTest : TestBase
    {
        [Test]
        public void updateGroup()
        {
            GroupData group = new GroupData("UpdateName");
            group.Header = null;
            group.Footer = null;

            app.Groups.UpdateGroup(group);
        }





       


    }
}
