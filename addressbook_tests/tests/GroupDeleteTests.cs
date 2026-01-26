using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupDeleteTests : GroupTestBase
    {
        [Test]
        public void GroupDeleteTest()
        {
            app.Navigator.GoToGroupPage();
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];

            if (app.Groups.ThereisNoGroups())
            {
                GroupData group = new GroupData("ничего не было");
                group.Header = "ничего не было";
                group.Footer = "ничего не было";

                app.Groups.Create(group);

            }
            app.Groups.Remove(toBeRemoved);
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
