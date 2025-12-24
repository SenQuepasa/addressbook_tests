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
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
          
        {
            this.baseURL = baseURL;
        }
        public NavigationHelper OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
            return this;
        }
        public NavigationHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;

        }
        public NavigationHelper GoToGroupPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;

        }
        public NavigationHelper GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;

        }
        public NavigationHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }


    }
}
