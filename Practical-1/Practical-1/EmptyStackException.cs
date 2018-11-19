using System;

namespace Practical_1
{
    /// <summary>
    /// Class EmptyStackException.
    /// Trying to get an item from an empty stack.
    /// Thrown when refers to an empty stack.
    /// </summary>
    public class EmptyStackException : ApplicationException
    {
        public EmptyStackException() { }
        
        public EmptyStackException(string message) : base(message) { }
    }  
}