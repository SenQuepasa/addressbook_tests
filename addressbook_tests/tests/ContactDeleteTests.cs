using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests.tests
{
    [TestFixture]
    public class ContactDeleteTests : TestBase
    {
        [Test]
        public void ContactDeleteTest()
        {
            app.Contacts.Remove(1);
        }
    }
}
