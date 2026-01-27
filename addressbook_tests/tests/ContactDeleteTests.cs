using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests.tests
{
    [TestFixture]
    public class ContactDeleteTests : AuthTestBase
    {
        private string contactId;

        [Test]
        public void ContactDeleteTest()
        {
            List<ContactData> oldStrings = ContactData.GetAll();
            if (app.Contacts.ThereisNoContacts())
            {
                ContactData newData = new ContactData("Семен", "Семенович", "Семенов", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                app.Contacts.Create(newData);
            }
                app.Contacts.Remove(contactId);
            List<ContactData> newStrings = ContactData.GetAll();
            oldStrings.RemoveAt(0);
            oldStrings.Sort();
            newStrings.Sort();
            Assert.AreEqual(oldStrings, newStrings);

  
        }
    }
}
