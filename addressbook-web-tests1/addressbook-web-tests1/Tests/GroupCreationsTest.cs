using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTest
{
    [TestFixture]
    public class GroupCreationTest : TestBase
    {
        [Test]
        public void GroupCreationTests()
        {
            app.Navigator.GoToHomePage();
            app.auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupePage();
            app.Groups.InitNewGroupCreation();
            GroupData group = new GroupData("TestGroupCreate0911");
            group.Header = "NameOfHeader";
            group.Footer = "NameOfFotter";
            app.Groups.FillGroupField(group);
            app.Groups.SubmitGroupCreation();
            app.Navigator.BackToHomePage();
            app.auth.Logout();
        }
    }
}
