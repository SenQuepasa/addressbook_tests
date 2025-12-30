using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            //prepare
            app.Auth.Logout();

            //action
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(new AccountData("admin", "secret"));

            //verification
            Assert.IsTrue(app.Auth.isLoggedIn(account));

        }
        [Test]
        public void LoginWithInvalidCredentials()
        {
            //prepare
            app.Auth.Logout();

            //action
            AccountData account = new AccountData("admin", "123312");
            app.Auth.Login(account);

            //verification
            Assert.IsFalse(app.Auth.isLoggedIn(account));

        }
    }
}
