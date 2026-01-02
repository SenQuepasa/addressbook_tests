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
    public class ContactDeleteTests : AuthTestBase
    {
        [Test]
        public void ContactDeleteTest()
        {
            if (app.Contacts.ThereisNoContacts())
            {
                ContactData newData = new ContactData("Семен", "Семенович", "Семенов", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                app.Contacts.Create(newData);
            }
                app.Contacts.Remove(1);
        }
    }
}
