using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAddressbookTest
{
    [TestFixture]
   public class LoginTest : AuthTestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {      
            AccountData account = new AccountData("admin","secret");
            app.auth.Login(account);
            Assert.IsTrue(app.auth.IsLoggedIn(account));
            app.auth.Logout();
        }
        [Test]
        public void LoginWithInValidCredentials()
        {
            app.auth.Logout();
            AccountData account = new AccountData("admin", "123");
            app.auth.Login(account);
            Assert.IsFalse(app.auth.IsLoggedIn(account));
        }
    }
}
