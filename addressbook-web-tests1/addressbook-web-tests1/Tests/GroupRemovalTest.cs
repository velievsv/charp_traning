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
            app.Navigator.GoToHomePage();
            app.auth.Login(new AccountData("admin","secret"));
            app.Navigator.GoToGroupePage();
            SelectGroupCheckbox(1);
            DeleteGroup();
            app.Navigator.BackToHomePage();
        }
    }
}
