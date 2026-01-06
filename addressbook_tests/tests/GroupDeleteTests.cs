using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupDeleteTests : AuthTestBase
    {
        [Test]
        public void GroupDeleteTest()
        {
            app.Navigator.GoToGroupPage();
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            if (app.Groups.ThereisNoGroups())
            {
                GroupData group = new GroupData("ничего не было");
                group.Header = "ничего не было";
                group.Footer = "ничего не было";

                app.Groups.Create(group);

            }
                app.Groups.Remove(0);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
