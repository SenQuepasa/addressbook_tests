using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTest : TestBase
    {
        [Test]
        public void ContactCreationTests()
        {
            app.Contacts.AddContact();
            ContactData contact = new ContactData("Ivan", "Ivanovich", "Ivanov", "", "", "", "", "", "", "", "", "", "", "", "","","","","","");
            app.Contacts
                .FillContactForm(contact)
                .SubmitContactCreation();
            app.Navigator.ReturnToHomePage();
        }
    }
}
