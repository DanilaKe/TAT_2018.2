using System;
using NUnit.Framework;
using DEV_3;

namespace DEV_7
{
    [TestFixture]
    public class Tests
    {
        private NumbersConverter numbersConverter;
        
        [OneTimeSetUp]
        public void SetUpTest()
        {
            numbersConverter = new NumbersConverter();
        }
       
        [Test]
        [TestCase(1,2,ExpectedResult = "1")]
        [TestCase(-1,2,ExpectedResult = "-1")]
        [TestCase(326443,20,ExpectedResult = "20G23")]
        [TestCase(-326443,20,ExpectedResult = "-20G23")]
        [TestCase(int.MaxValue,2,ExpectedResult = "1111111111111111111111111111111")]
        [TestCase(-int.MaxValue,2,ExpectedResult = "-1111111111111111111111111111111")]
        [TestCase(int.MaxValue,20,ExpectedResult = "1DB1F927")]
        [TestCase(-int.MaxValue,20,ExpectedResult = "-1DB1F927")]
        [TestCase(0,2,ExpectedResult = "0")]
        public string PositiveTest(int number, int radixOfTheNewNumberSystem)
        {
            numbersConverter.NumberInDecimal = number;
            numbersConverter.Radix = radixOfTheNewNumberSystem;
            var actualResult = numbersConverter.ConvertNumberFromDecimal();
            return actualResult;
        }
        
        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestCase(23,21)]
        [TestCase(23,1)]
        [TestCase(int.MinValue,2)]
        public void ArgumentOutOfRangeExceptionTest(int number, int radixOfTheNewNumberSystem)
        {
            numbersConverter.NumberInDecimal = number;
            numbersConverter.Radix = radixOfTheNewNumberSystem;
            numbersConverter.ConvertNumberFromDecimal();
        }
    }
}