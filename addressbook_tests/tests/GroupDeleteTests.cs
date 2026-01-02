using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupDeleteTests : AuthTestBase
    {
        [Test]
        public void GroupDeleteTest()
        {
            app.Navigator.GoToGroupPage();
            if (app.Groups.ThereisNoGroups())
            {
                GroupData group = new GroupData("ничего не было");
                group.Header = "ничего не было";
                group.Footer = "ничего не было";

                app.Groups.Create(group);

            }
                app.Groups.Remove(1);
        }
    }
}
