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
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
    {
        GroupData newData = new GroupData("DDD");
        newData.Header = "EEE";
        newData.Footer = "FFF";

        app.Groups.Modify(1, newData);
    }
    }
}
