using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherPOC_ShareCode.UnitTest
{
    [TestFixture]
    class TestFieldsValidator
    {
        [Test]
        public void VeryfyIsValidEmailTrue()
        {
            bool expectedResult = FieldsValidator.IsValidEmail("a@a.com");
            Assert.AreEqual(expectedResult, true);
        }

        [Test]
        public void VeryfyIsValidEmailFalseWithoutPoint()
        {
            bool expectedResult = FieldsValidator.IsValidEmail("a@a");
            Assert.AreEqual(expectedResult, false);
        }

        [Test]
        public void VeryfyIsValidEmailFalseOnlyText()
        {
            bool expectedResult = FieldsValidator.IsValidEmail("user");
            Assert.AreEqual(expectedResult, false);
        }
    }
}
