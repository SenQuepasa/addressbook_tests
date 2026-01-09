using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }
        public ContactHelper Modify(int v, ContactData newData)
        {
            InitContactModification();
            FillContactForm(newData);
            SubmitContactModification();
            manager.Navigator.ReturnToHomePage();
            
            return this;
        }
        public ContactHelper Create(ContactData newData)
        {
            AddContact();
            FillContactForm(newData);
            SubmitContactCreation();
            manager.Navigator.ReturnToHomePage();

            return this;
        }
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[19]")).Click();
            return this;
        }
        public ContactHelper AddContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;

        }
        public bool ThereisNoContacts()
        {
            return IsElementNotPresent(By.CssSelector("input[name=\"selected[]\"]"));
        }
        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("work"), contact.Work);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText("1");
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("October");
            driver.FindElement(By.Name("byear")).Click();
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys("1990");
            driver.FindElement(By.Name("aday")).Click();
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText("18");
            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText("October");
            driver.FindElement(By.Name("ayear")).Click();
            driver.FindElement(By.Name("ayear")).Clear();
            driver.FindElement(By.Name("ayear")).SendKeys("2010");
            return this;

        }
        public ContactHelper Remove(int v)
        {
            SelectContact(v);
            RemoveContact();
            manager.Navigator.ReturnToHomePage();
            return this;
        }
        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//input[@type='checkbox']")).Click();
            return this;

        }
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;

        }
        public List<ContactString> GetContactStrings()
        {
            manager.Navigator.ReturnToHomePage();
            List<ContactString> contactStrings = new List<ContactString>();
            ICollection<IWebElement> strings = driver.FindElements(By.XPath("//tr[@name='entry']"));
            foreach (IWebElement element in strings)
            {
                contactStrings.Add(new ContactString(element.Text, element.Text));
            }
            return contactStrings;
        }
        public List<ContactData> GetContactList()
        {
            manager.Navigator.ReturnToHomePage();
            List<ContactData> contacts = new List<ContactData>();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("input[name=\"selected[]\"]"));
            foreach (IWebElement element in elements)
            {
                contacts.Add(new ContactData(element.Text, element.Text, element.Text, element.Text, element.Text, element.Text, element.Text, element.Text, element.Text, element.Text, element.Text, element.Text, element.Text, element.Text, element.Text, element.Text, element.Text, element.Text, element.Text, element.Text));
            }
            return contacts;
        }
    }
}
