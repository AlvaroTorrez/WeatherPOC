using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WeatherPOC_ShareCode.LoginModule;

namespace WeatherPOC_ShareCode.UnitTest
{
    [TestFixture]
    class TestLoginUser
    {
        [Test]
        public void VerifyLoginUserTrue()
        {
            LoginUser login = new LoginUser(new MockLoginRequests());
            bool expectedResult = login.VerifyLoginUser("a@a.com", "a");
            Assert.AreEqual(expectedResult, true);
        }

        [Test]
        public void VerifyLoginUserFalse()
        {
            LoginUser login = new LoginUser(new MockLoginRequests());
            bool expectedResult = login.VerifyLoginUser("a@a.co", "");
            Assert.AreEqual(expectedResult, false);
        }
    }
}
