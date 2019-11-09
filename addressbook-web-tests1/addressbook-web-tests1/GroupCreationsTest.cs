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
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToTheGroupPage();
            InitNewGroupCreation();
            GroupData group = new GroupData("TestGroupCreate0911");
            group.Header = "NameOfHeader";
            group.Footer = "NameOfFotter";
            FillGroupField(group);
            SubmitGroupCreation();
            BackToHomePage();
            Logout();
        }
    }
}
