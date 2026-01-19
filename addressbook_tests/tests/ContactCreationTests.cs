using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Serialization;

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
        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>)).Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText(@"contacts.json"));
        }
        [Test, TestCaseSource("ContactDataFromXmlFile")]
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
