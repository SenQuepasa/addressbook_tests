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
            app.Groups.Remove(1);
        }
    }
}
