using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

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

            app.Groups.CreateGroup(group);
            app.Navigator.BackToHomePage();
            app.auth.Logout();
        }
        public void EmptyGroupCreationTests()
        {
            
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Groups.CreateGroup(group);
            app.Navigator.BackToHomePage();
            app.auth.Logout();
        }
    }
}
