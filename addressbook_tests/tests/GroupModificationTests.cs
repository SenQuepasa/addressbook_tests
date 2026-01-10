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
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
    {
            app.Navigator.GoToGroupPage();
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldData = oldGroups[0];


            if (app.Groups.ThereisNoGroups())
            {
                GroupData group = new GroupData("ничего не было");
                group.Header = "ничего не было";
                group.Footer = "ничего не было";

                app.Groups.Create(group);

                GroupData group1 = new GroupData("стало новое значение");
                group.Header = "стало новое значение";
                group.Footer = "стало новое значение";
            }
            
            GroupData newData = new GroupData("345");
            newData.Header = "EEE";
            newData.Footer = "FFF";
            app.Groups.Modify(0, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
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