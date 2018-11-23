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
        [TestCase(1,2,ExpectedResult = "1",TestName = "Minimum positive number in 2 number system")]
        [TestCase(-1,2,ExpectedResult = "-1",TestName = "Maximum negative number in 2 number system")]
        [TestCase(326443,20,ExpectedResult = "20G23", TestName = "Random positive number in 20 number system")]
        [TestCase(-326443,20,ExpectedResult = "-20G23", TestName = "Random negative number in 20 number system")]
        [TestCase(int.MaxValue,2,ExpectedResult = "1111111111111111111111111111111", TestName = "Maximum positive number in 2 number system")]
        [TestCase(-int.MaxValue,2,ExpectedResult = "-1111111111111111111111111111111",TestName = "Minimum negative number in 2 number system")]
        [TestCase(int.MaxValue,20,ExpectedResult = "1DB1F927",TestName = "Maximum positive number in 20 number system")]
        [TestCase(-int.MaxValue,20,ExpectedResult = "-1DB1F927",TestName = "Minimum negative number in 20 number system")]
        [TestCase(0,2,ExpectedResult = "0", TestName = "Zero test")]
        public string PositiveTest(int number, int radixOfTheNewNumberSystem)
        {
            numbersConverter.NumberInDecimal = number;
            numbersConverter.Radix = radixOfTheNewNumberSystem;
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