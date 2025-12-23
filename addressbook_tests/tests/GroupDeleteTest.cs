using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupDeleteTests : TestBase
    {
        [Test]
        public void GroupDeleteTest()
        {
            app.Navigator.GoToGroupsPage();
            app.Groups
                .SelectGroup(1)
                .RemoveGroup();
            app.Navigator.ReturnToGroupsPage();
        }
    }
}
