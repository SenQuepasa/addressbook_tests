using NUnit.Framework;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupDeleteTests : TestBase
    {
        [Test]
        public void GroupDeleteTest()
        {
                app.Groups.Remove(1);
        }
    }
}
