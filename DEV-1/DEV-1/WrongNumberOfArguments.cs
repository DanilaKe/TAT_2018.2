using System;

namespace DEV_1
{
    /// <summary>
    /// Exception WrongNumberOfArguments
    /// Thrown when the number of arguments is incorrect.
    /// </summary>
    public class WrongNumberOfArguments : ApplicationException
    {
        public WrongNumberOfArguments() { }

        public WrongNumberOfArguments(string message) : base(message) { }
    }
}