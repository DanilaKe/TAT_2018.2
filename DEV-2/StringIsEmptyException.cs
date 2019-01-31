using System;

namespace DEV_2
{
    /// <summary>
    /// Class EmptyStringException
    /// Thrown when string is empty
    /// </summary>
    public class EmptyStringException : ApplicationException
    {
        public EmptyStringException() { }
        
        public EmptyStringException(string message) : base(message) { }
    }
}