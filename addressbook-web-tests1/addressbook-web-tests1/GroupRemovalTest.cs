using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTest
{
    [TestFixture]
    public class GroupRemoval : TestBase
    {
       

        [Test]
        public void GroupRemovalTest()
        {
            GoToHomePage();
            Login(new AccountData("admin","secret"));
            GoToGroupePage();
            SelectGroupCheckbox(1);
            DeleteGroup();
            BackToHomePage();
        }
    }
}
