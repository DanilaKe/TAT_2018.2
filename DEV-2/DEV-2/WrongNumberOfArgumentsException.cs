using System;

namespace DEV_2
{
    public class WrongNumberOfArgumentsException : ApplicationException
    {
        public WrongNumberOfArgumentsException() { }
        
        public WrongNumberOfArgumentsException(string message) { }
    }
}