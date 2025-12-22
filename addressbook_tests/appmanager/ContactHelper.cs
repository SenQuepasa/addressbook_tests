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
        public ContactHelper(IWebDriver driver) : base(driver)
        {
        }
        public void SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[19]")).Click();
        }
        public void AddContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
    }
}
