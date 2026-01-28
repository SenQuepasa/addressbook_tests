using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    
    public class AddingContactToGroupTests: AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            List<GroupData> groups = GroupData.GetAll();
            List<GroupData> oldList = GroupData.GetAll();
            List<ContactData> contacts = ContactData.GetAll();

            if (app.Groups.ThereisNoGroups())
            {
                GroupData newGroup = new GroupData("test_group");
                app.Groups.Create(newGroup);
                groups = GroupData.GetAll();
            }

            if (app.Contacts.ThereisNoContacts())
            {
                ContactData newContact = new ContactData("Иван", "Иванов");
                app.Contacts.Create(newContact);
                contacts = ContactData.GetAll();
            }

            GroupData targetGroup = null;
            ContactData targetContact = null;

            foreach (GroupData group in groups)
            {
                List<ContactData> contactsInGroup = group.GetContacts();
                var availableContacts = contacts.Except(contactsInGroup).ToList();

                if (availableContacts.Count > 0)
                {
                    targetGroup = group;
                    targetContact = availableContacts.First();
                    break;
                }
            }

            if (targetGroup == null || targetContact == null)
            {
                GroupData newGroup = new GroupData($"test_group_{DateTime.Now:MMddHHmmss}");
                app.Groups.Create(newGroup);
                targetGroup = GroupData.GetAll().First(g => g.Name == newGroup.Name); 

                ContactData newContact = new ContactData($"auto_first_{DateTime.Now:HHmmss}", "auto_last");
                app.Contacts.Create(newContact);
                targetContact = ContactData.GetAll().First(c => c.Firstname == newContact.Firstname);
            }

            List<ContactData> contactsBefore = targetGroup.GetContacts();
            if (contactsBefore.Contains(targetContact))
            {
                Assert.Fail("Контакт уже состоит в группе");
            }

            app.Contacts.AddContactToGroup(targetContact, targetGroup);

            List<ContactData> contactsAfter = targetGroup.GetContacts();

            Assert.IsTrue(
                contactsAfter.Contains(targetContact),
                $"Контакт не был добавлен в группу");
        

            List<GroupData> newList = GroupData.GetAll();

              newList.Sort();
              oldList.Sort();
              Assert.AreEqual(oldList, newList);
        }
    }
}
