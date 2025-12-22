using OpenQA.Selenium;
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
    public class GroupHelper : HelperBase
    {
        public GroupHelper(IWebDriver driver)
            : base(driver)
        {

        }
        public void SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }
        public void InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
        }
        public void RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
        }
        public void SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
        }
    }
}
