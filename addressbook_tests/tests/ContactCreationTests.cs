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
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 3; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30), GenerateRandomString(30))
                {
                    Firstname = GenerateRandomString(100),
                    Lastname = GenerateRandomString(100),
                    Middlename = GenerateRandomString(100)

                });
            }
            return contacts;
        }
        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTests()
        {
            List<ContactData> oldStrings = app.Contacts.GetContactStrings();
            app.Contacts.AddContact();
            ContactData contact = new ContactData("Ivan", "Ivanovich", "Ivanov", "", "", "", "", "", "", "", "", "", "", "", "","","","","","");
            app.Contacts
                .FillContactForm(contact)
                .SubmitContactCreation();
            app.Navigator.ReturnToHomePage();

            List<ContactData> newStrings = app.Contacts.GetContactStrings();
            oldStrings.Add(contact);
            oldStrings.Sort();
            newStrings.Sort();
            Assert.AreEqual(oldStrings, newStrings);
        }
    }
}
