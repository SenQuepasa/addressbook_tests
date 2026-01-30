using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests.tests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation(ContactData oldData)
        {
            List<ContactData> contacts = ContactData.GetAll();
            ContactData firstContact = contacts[0];
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(firstContact);
            ContactData fromView = app.Contacts.GetContactInformationFromViewForm(0);
            ContactData fromFormPlus = app.Contacts.GetContactInformationFromEditFormEdition(firstContact);

          Assert.AreEqual(fromTable, fromForm);
          Assert.AreEqual(fromTable.Address, fromForm.Address);
          Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
          Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
          Assert.AreEqual(fromFormPlus.AllInfo, fromView.AllInfo);
           
        }
    }
}
