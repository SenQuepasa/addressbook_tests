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
            app.Groups.Modify(1, newData);

        }
    }
}
