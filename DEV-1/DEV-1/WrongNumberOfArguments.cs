using System;

namespace DEV_1
{
    public class WrongNumberOfArguments : ApplicationException
    {
        public WrongNumberOfArguments() { }

        public WrongNumberOfArguments(string message) : base(message) { }
    }
}