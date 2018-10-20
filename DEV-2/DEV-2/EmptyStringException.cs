using System;

namespace DEV_2
{
    public class EmptyStringException : ApplicationException
    {
        public EmptyStringException() { }
        
        public EmptyStringException(string message) : base(message) { }
    }
}