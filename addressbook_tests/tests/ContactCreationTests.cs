using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTest : AuthTestBase
    {
        [Test]
        public void ContactCreationTests()
        {
            //  List<ContactData> oldContacts = app.Contacts.GetContactList();
            List<ContactString> oldStrings = app.Contacts.GetContactStrings();
            app.Contacts.AddContact();
            ContactData contact = new ContactData("Ivan", "Ivanovich", "Ivanov", "", "", "", "", "", "", "", "", "", "", "", "","","","","","");
            app.Contacts
                .FillContactForm(contact)
                .SubmitContactCreation();
            app.Navigator.ReturnToHomePage();

            // List<ContactData> newContacts = app.Contacts.GetContactList();
            List<ContactString> newStrings = app.Contacts.GetContactStrings();
           // oldStrings.Add(contact);
            oldStrings.Sort();
            newStrings.Sort();
            Assert.AreEqual(oldStrings, newStrings);
        }
    }
}
