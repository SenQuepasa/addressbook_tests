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
            
            if (app.Contacts.ThereisNoContacts())
            {
                ContactData newData1 = new ContactData("Семен", "Семенович", "Семенов", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                app.Contacts.Create(newData1);
            }
            ContactData newData2 = new ContactData("Игорь", "Игоревич", "Игорев", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            app.Contacts.Modify(1, newData2);

        }
    }
}


