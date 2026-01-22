using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }
        public ContactHelper Modify(int v, ContactData newData)
        {
            manager.Navigator.ReturnToHomePage();
            InitContactModification(0);
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
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
            .FindElements(By.TagName("td"))[7]
            .FindElement(By.TagName("a")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[19]")).Click();
            contactCache = null;
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
            Type(By.Name("home"), contact.HomePhone);
            Type(By.Name("mobile"), contact.MobilePhone);
            Type(By.Name("work"), contact.WorkPhone);
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
            manager.Navigator.ReturnToHomePage();
            SelectContact(v);
            RemoveContact();
            manager.Navigator.ReturnToHomePage();
            contactCache = null;
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
        private List<ContactData> contactCache = null;
        private string firstName;
        private string lastName;
        private string middleName;


        public List<ContactData> GetContactStrings()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.ReturnToHomePage();
                ICollection<IWebElement> strings = driver.FindElements(By.XPath("//tr[@name='entry']"));
                foreach (IWebElement element in strings)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    string firstname = cells[2].Text;
                    string lastname = cells[1].Text;
                    contactCache.Add(new ContactData(cells[2].Text, cells[1].Text));
                }
            }
            
            return new List<ContactData>(contactCache);

        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text + "\r\n";
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails

            };


        }
        public ContactData GetContactInformationFromViewForm(int index)
        {
            manager.Navigator.OpenHomePage();
            driver.FindElements(By.XPath("//img[@alt='Details']"))[index].Click();
            string allInfo = driver.FindElement(By.Id("content")).Text;

            return new ContactData(firstName, lastName)
            {
                AllInfo = CleanUp(allInfo) + "\r\n"
            };

        }
        public string CleanUp(string info)
        {
            return Regex.Replace(info, "[-()]", "");

        }
        public string CleanUpPhone(string info)
        {
            return Regex.Replace(info, "[-()]", "");

        }


        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            InitContactModification(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value");

            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");

            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = CleanUp(driver.FindElement(By.Name("home")).GetAttribute("value"));
            string mobilePhone = CleanUp(driver.FindElement(By.Name("mobile")).GetAttribute("value"));
            string workPhone = CleanUp(driver.FindElement(By.Name("work")).GetAttribute("value"));

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            

            return new ContactData(firstName, lastName)
              {
                Firstname = firstName,
              Lastname = lastName,
            Middlename = middlename,
            Address = address,
                Nickname = nickname,
                  Company = company,
                  Title = title,
                  HomePhone = homePhone,
                  MobilePhone = mobilePhone,
                 WorkPhone = workPhone,
                  Email = email,
                 Email2 = email2,
                 Email3 = email3
              
             };
        }

        public ContactData GetContactInformationFromEditFormEdition(int index)
        {

            manager.Navigator.OpenHomePage();
            InitContactModification(0);
          string fullname = driver.FindElement(By.Name("firstname")).GetAttribute("value") + " " + driver.FindElement(By.Name("middlename")).GetAttribute("value") + " " + driver.FindElement(By.Name("lastname")).GetAttribute("value");
           string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value") + "\r\n";
           string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value") + "\r\n";
            if (!string.IsNullOrEmpty(company))
            {
                company = driver.FindElement(By.Name("company")).GetAttribute("value");
            }
            else company = "";
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");

            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            if (!string.IsNullOrEmpty(address))
            {
                address = driver.FindElement(By.Name("address")).GetAttribute("value") + "\r\n";
            }
            else address = "";
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            if (!string.IsNullOrEmpty(homePhone))
            {
                homePhone = "H: " + " " + CleanUp(driver.FindElement(By.Name("home")).GetAttribute("value").Trim() + " " + "\r\n");
            }
            else homePhone = "";
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");

            if (!string.IsNullOrEmpty(mobilePhone))
            {
                mobilePhone = "M: " + " " + CleanUp(driver.FindElement(By.Name("mobile")).GetAttribute("value").Trim() + " " + "\r\n");
            }
            else mobilePhone = "";
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            if (!string.IsNullOrEmpty(workPhone))
            {
                workPhone = "W: "  + CleanUp(driver.FindElement(By.Name("work")).GetAttribute("value").Trim() + " " + "\r\n");
            }
            else workPhone = "";

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            if (!string.IsNullOrEmpty(email))
            {
                email = "\r\n" + driver.FindElement(By.Name("email")).GetAttribute("value");
            }
            else email = "";
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            if (!string.IsNullOrEmpty(email2))
            {
                email2 = "\r\n" + driver.FindElement(By.Name("email2")).GetAttribute("value");
            }
            else email2 = "";
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            if (!string.IsNullOrEmpty(email3))
            {
                email3 = "\r\n" + driver.FindElement(By.Name("email3")).GetAttribute("value");
            }
            else email3 = "";



            return new ContactData(firstName, lastName, middleName)
            {
          //      Firstname = firstName,
              //  Middlename = middleName,
              //  Lastname = lastName,
              FullName = fullname,
                Address = address,
                Nickname = nickname,
                Company = company,
                Title = title,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3

            };
        }
    }
    }
