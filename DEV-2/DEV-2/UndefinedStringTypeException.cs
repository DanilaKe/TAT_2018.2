using System;

namespace DEV_2
{
    /// <summary>
    /// Class UndefinedStringTypeException
    /// Thrown when unable to find out the type of string.
    /// </summary>
    public class UndefinedStringTypeException : ApplicationException
    {
        public UndefinedStringTypeException() { }

        public UndefinedStringTypeException(string message) : base(message) { }
    }
}