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
    public class ContactModificationTests : AuthTestBase
    {
        private ContactData newData;

        [Test]
        public void ContactModificationTest()
        {
            app.Navigator.ReturnToHomePage();
            List<ContactData> oldStrings = ContactData.GetAll();
            if (app.Contacts.ThereisNoContacts())
            {
                ContactData newData1 = new ContactData("Семен", "Семенович", "Семенов", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                app.Contacts.Create(newData1);
            }
            ContactData newData2 = new ContactData("Игорь", "Игоревич", "Игорев", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            app.Contacts.Modify(0, newData2);
            List<ContactData> newStrings = ContactData.GetAll();
            oldStrings[0].Firstname = newData2.Firstname;
            oldStrings[0].Lastname = newData2.Lastname;
            oldStrings.Sort();
            newStrings.Sort();
            Assert.AreEqual(oldStrings, newStrings);
        }
    }
}


