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
        public void TestContactInformation()
        {
            
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            ContactData fromView = app.Contacts.GetContactInformationFromViewForm(0);
            ContactData fromFormPlus = app.Contacts.GetContactInformationFromEditFormEdition(0);

          Assert.AreEqual(fromTable, fromForm);
          Assert.AreEqual(fromTable.Address, fromForm.Address);
          Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
          Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
          Assert.AreEqual(fromFormPlus.AllInfo, fromView.AllInfo);
           



        }
    }
}
