using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("A");
            group.Header = "B";
            group.Footer = "C";
            
            app.Navigator.GoToGroupPage();
            app.Groups.Create(group);
            app.Navigator.ReturnToGroupsPage();
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Navigator.GoToGroupPage();
            app.Groups
                .InitNewGroupCreation()
                .FillGroupForm(group)
                .SubmitGroupCreation();
            app.Navigator.ReturnToGroupsPage();
        }
    }
}
