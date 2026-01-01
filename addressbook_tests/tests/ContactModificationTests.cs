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
        [Test]
        public void ContactModificationTest()
        {
            
            if (app.Contacts.ThereisNoContacts())
            {
                ContactData newData = new ContactData("Семен", "Семенович", "Семенов", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                ContactData newestData = new ContactData("Агния", "Барто", "Семенова", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                app.Contacts.Create(newData);
                app.Contacts.Modify(1, newestData);
            }
            else
            {
                ContactData newData = new ContactData("Игорь", "Игоревич", "Игорев", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                app.Contacts.Modify(1, newData);
            }
        }
    }
}


