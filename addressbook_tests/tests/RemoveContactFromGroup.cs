using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests

{
    public class RemoveContactFromGroup : AuthTestBase
    {
        private string contactId;

        [Test]
        public void TestRemoveContactFromGroup()
        {
            // Шаг 1: Получаем все группы и контакты
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

            GroupData targetGroup = groups[0]; // Берём первую группу
            List<ContactData> contactsInGroup = targetGroup.GetContacts();

            ContactData contactToRemove = null;

            // Шаг 2: Ищем контакт, который уже в группе
            if (contactsInGroup.Count > 0)
            {
                contactToRemove = contactsInGroup.First();
            }
            else
            {
                // 2. Если в группе нет контактов — ищем ЛЮБОЙ контакт, которого в ней нет
                List<ContactData> contactsNotInGroup = contacts.Except(contactsInGroup).ToList();

                if (contactsNotInGroup.Count == 0)
                {
                    // Только если вообще нет свободных контактов — создаём новый
                    ContactData newContact = new ContactData($"auto_{DateTime.Now:HHmmss}", "last");
                    app.Contacts.Create(newContact);
                    contactToRemove = newContact;
                }
                else
                {
                    // Берём существующий контакт, который не в группе
                    contactToRemove = contactsNotInGroup.First();
                }

                // Добавляем его в группу
                app.Contacts.AddContactToGroup(contactToRemove, targetGroup);

                // Проверяем, что добавился
                List<ContactData> updatedContactsInGroup = targetGroup.GetContacts();
                if (!updatedContactsInGroup.Contains(contactToRemove))
                {
                    Assert.Fail("Не удалось добавить существующий контакт в группу.");
                }
            }

            // Сохраняем состояние до удаления
            List<ContactData> oldList = targetGroup.GetContacts();
            oldList.Remove(contactToRemove);

            // Удаляем
            app.Contacts.RemoveContactFromGroup(contactToRemove, targetGroup);

            // Проверяем состояние после
            List<ContactData> newList = targetGroup.GetContacts();

            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList, "Список контактов в группе после удаления не совпадает с ожидаемым.");
        }
    }
}
