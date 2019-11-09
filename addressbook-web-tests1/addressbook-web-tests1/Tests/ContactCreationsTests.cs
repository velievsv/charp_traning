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
            app.Navigator.GoToHomePage();
            app.auth.Login(new AccountData("admin","secret"));
            app.Navigator.GotoAddNewContactPage();
            app.Contact.FillContactForm(new ContactData("Eto","Pobeda"));
            app.Contact.InitNewContact();
            app.Navigator.BackToHomePage();
        }
    }
}
