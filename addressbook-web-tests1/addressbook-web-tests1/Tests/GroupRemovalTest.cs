using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTest
{
    [TestFixture]
    public class GroupRemoval : AuthTestBase
    {
       

        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.GoToGroupePage();
            app.Groups.DeleteGroups();
            app.Navigator.BackToHomePage();
        }
    }
}
