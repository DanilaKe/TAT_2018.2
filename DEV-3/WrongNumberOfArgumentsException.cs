using System;

namespace DEV_3
{
    /// <summary>
    /// Class WrongNumberOfArgumentsException
    /// Thrown when the number of arguments is incorrect.
    /// </summary>
    public class WrongNumberOfArgumentsException : ApplicationException
    {
        public WrongNumberOfArgumentsException() { }
        
        public WrongNumberOfArgumentsException(string message) : base(message) { }
    }
}
