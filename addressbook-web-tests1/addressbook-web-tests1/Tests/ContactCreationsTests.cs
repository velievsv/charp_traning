using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTest
{
    [TestFixture]
    public class ContactTest : TestBase
    {
        [Test]
        public void TheContactTest()
        {
            app.Contacts.CreateContact();
            app.Navigator.BackToHomePage();
        }
    }
}
