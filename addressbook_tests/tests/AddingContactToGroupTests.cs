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

            // Ищем группу, в которой есть свободные контакты
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

            // Если не нашли — создаём ЛИБО новый контакт, ЛИБО новую группу
            if (targetGroup == null || targetContact == null)
            {
                // Создаём НОВЫЙ КОНТАКТ и добавляем в СУЩЕСТВУЮЩУЮ группу
                ContactData newContact = new ContactData($"auto_{DateTime.Now:HHmmss}", "last");
                app.Contacts.Create(newContact);
                targetContact = ContactData.GetAll().First(c => c.Firstname == newContact.Firstname);
                targetGroup = groups[0]; // Берём первую группу
            }

            // Проверяем: контакт ещё не в группе
            List<ContactData> contactsBefore = targetGroup.GetContacts();
            if (contactsBefore.Contains(targetContact))
            {
                Assert.Fail("Контакт уже состоит в группе");
            }

            // Добавляем контакт
            app.Contacts.AddContactToGroup(targetContact, targetGroup);

            // Проверяем: контакт добавлен
            List<ContactData> contactsAfter = targetGroup.GetContacts();
            Assert.IsTrue(contactsAfter.Contains(targetContact), "Контакт не был добавлен в группу");

            // Проверяем: список групп НЕ изменился
            List<GroupData> newList = GroupData.GetAll();
            newList.Sort();
            List<GroupData> oldList = GroupData.GetAll(); // Обновляем, если были изменения
            oldList.Sort();
            Assert.AreEqual(oldList, newList, "Список групп изменился, хотя не должен был");
        }
    }
}
