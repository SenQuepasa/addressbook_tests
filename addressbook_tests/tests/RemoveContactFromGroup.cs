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
                // Шаг 3: Если в группе нет контактов — создаём и добавляем
                ContactData newContact = new ContactData($"auto_first_{DateTime.Now:HHmmss}", "auto_last");
                app.Contacts.Create(newContact);
                
                // Добавляем в группу
                app.Contacts.AddContactToGroup(newContact, targetGroup);

                // Обновляем список контактов в группе
                contactsInGroup = targetGroup.GetContacts();

                // Убеждаемся, что контакт добавился
                if (contactsInGroup.Count == 0)
                {
                    Assert.Fail("Не удалось добавить контакт в группу для теста удаления.");
                }

                contactToRemove = contactsInGroup.First();
            }

            // К этому моменту contactToRemove точно существует и входит в группу

            // Шаг 4: Сохраняем состояние ДО удаления
            List<ContactData> oldList = new List<ContactData>(contactsInGroup);

            // Удаляем контакт из группы
            app.Contacts.RemoveContactFromGroup(contactToRemove, targetGroup);

            // Шаг 5: Получаем состояние ПОСЛЕ удаления
            List<ContactData> newList = targetGroup.GetContacts();

            // Шаг 6: Проверяем результат
            oldList.Remove(contactToRemove);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList, "Список контактов в группе после удаления не совпадает с ожидаемым.");
        }
    }
}
