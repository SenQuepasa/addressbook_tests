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
            if (app.Contacts.ThereisNoContacts())
            {
                ContactData newData1 = new ContactData("Семен", "Семенович", "Семенов", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                app.Contacts.Create(newData1);
            }
            List<ContactData> oldStrings = ContactData.GetAll();
            ContactData contactToModify = oldStrings[0];
            ContactData newData2 = new ContactData("Игорь", "Игоревич", "Игорев", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            newData2.Id = contactToModify.Id;
            app.Contacts.Modify(contactToModify, newData2);
            List<ContactData> newStrings = ContactData.GetAll();
            ContactData modifiedOld = oldStrings.Find(c => c.Id == contactToModify.Id);
            modifiedOld.Firstname = newData2.Firstname;
            modifiedOld.Lastname = newData2.Lastname;
            modifiedOld.Middlename = newData2.Middlename;
            oldStrings.Sort();
            newStrings.Sort();
            Assert.AreEqual(oldStrings, newStrings);
        }
    }
}


