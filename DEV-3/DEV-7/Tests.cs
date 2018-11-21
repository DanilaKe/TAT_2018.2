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
        [TestCase(1,2,"1")]
        [TestCase(-1,2,"-1")]
        [TestCase(326443,20,"20G23")]
        [TestCase(int.MaxValue,20,"1DB1F927")]
        [TestCase(int.MaxValue,2,"1111111111111111111111111111111")]
        //[TestCase(int.MinValue,2,"-11111111111111111111111111111111")]
        public void PositiveTest(int Number, int radixOfTheNewNumberSystem, string expectedResult)
        {
            numbersConverter.NumberInDecimal = Number;
            numbersConverter.Radix = radixOfTheNewNumberSystem;
            var actualResult = numbersConverter.ConvertNumberFromDecimal();
            Assert.AreEqual(expectedResult,actualResult);
        }
        
        [Test]
        [ExpectedException(typeof(OverflowException))]
        [TestCase(int.MinValue,2)]
        public void OverflowExceptionTest(int Number, int radixOfTheNewNumberSystem)
        {
            numbersConverter.NumberInDecimal = Number;
            numbersConverter.Radix = radixOfTheNewNumberSystem;
            var actualResult = numbersConverter.ConvertNumberFromDecimal();
        }
        
        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestCase(23,21)]
        public void ArgumentOutOfRangeExceptionTest(int Number, int radixOfTheNewNumberSystem)
        {
            numbersConverter.NumberInDecimal = Number;
            numbersConverter.Radix = radixOfTheNewNumberSystem;
            var actualResult = numbersConverter.ConvertNumberFromDecimal();
        }
    }
}