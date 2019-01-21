using System;
using System.Security.AccessControl;
using NUnit.Framework;
using DEV_3;

namespace DEV_7
{
    [TestFixture]
    public class Dev3Tests
    {
        private NumbersConverter numbersConverter;
        
        [OneTimeSetUp]
        public void SetUpTest()
        {
            numbersConverter = new NumbersConverter();
        }
       
        [Test]
        [TestCase(1, NumbersConverter.MinRadix,ExpectedResult = "1", TestName = "Convert minimum positive number in minimal radix")]
        [TestCase(-1, NumbersConverter.MinRadix,ExpectedResult = "-1", TestName = "Convert maximum negative number in minimal radix")]
        [TestCase(326443, NumbersConverter.MaxRadix,ExpectedResult = "20G23", TestName = "Convert random positive number in maximal radix")]
        [TestCase(-326443, NumbersConverter.MaxRadix,ExpectedResult = "-20G23", TestName = "Convert random negative number in maximal radix")]
        [TestCase(int.MaxValue, NumbersConverter.MinRadix,ExpectedResult = "1111111111111111111111111111111", 
            TestName = "Convert maximum positive number in minimal radix")]
        [TestCase(-int.MaxValue, NumbersConverter.MinRadix,ExpectedResult = "-1111111111111111111111111111111",
            TestName = "Convert minimum negative number in minimal radix")]
        [TestCase(int.MaxValue, NumbersConverter.MaxRadix, ExpectedResult = "1DB1F927",TestName = "Convert maximum positive number in maximal radix")]
        [TestCase(-int.MaxValue, NumbersConverter.MaxRadix, ExpectedResult = "-1DB1F927",TestName = "Convert minimum negative number in maximal radix")]
        [TestCase(0,2,ExpectedResult = "0", TestName = "Convert zero")]
        public string PositiveTest(int number, int radixOfNumberSystem)
        {
            numbersConverter.NumberInDecimal = number;
            numbersConverter.Radix = radixOfNumberSystem;
            var actualResult = numbersConverter.ConvertNumberFromDecimal();
            return actualResult;
        }
        
        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestCase(23,21,TestName = "Exception when radix out of upper range")]
        [TestCase(23,1,TestName = "Exception when radix out of lower range")]
        [TestCase(int.MinValue,2, TestName = "Exception when decimal number out range")]
        public void ArgumentOutOfRangeExceptionTest(int number, int radixOfTheNewNumberSystem)
        {
            numbersConverter.NumberInDecimal = number;
            numbersConverter.Radix = radixOfTheNewNumberSystem;
        }
    }
}