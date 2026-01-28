using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests { 

    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
    {
            app.Navigator.GoToGroupPage();
            if (app.Groups.ThereisNoGroups())
            {
                GroupData group = new GroupData("ничего не было");
                group.Header = "ничего не было";
                group.Footer = "ничего не было";

                app.Groups.Create(group);
            }

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];
            GroupData groupToModify = oldGroups[0];
            GroupData newData = new GroupData("345");
            newData.Header = "EEE";
            newData.Footer = "FFF";
            app.Groups.Modify(groupToModify, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            GroupData modifiedGroup = oldGroups.Find(g => g.Id == groupToModify.Id);
            if (modifiedGroup == null)
            {
                Assert.Fail($"Группа с Id={groupToModify.Id} не найдена в старом списке.");
            }
            modifiedGroup.Name = newData.Name;
            modifiedGroup.Header = newData.Header;
            modifiedGroup.Footer = newData.Footer;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);

                }
            }
        }
    }
}