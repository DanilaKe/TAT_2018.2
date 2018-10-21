using System;

namespace Practical_1
{
    /// <summary>
    /// Class EntryPoint
    /// This class checked created Stack class.
    /// </summary>
    internal class EntryClass
    {
        /// <summary>
        /// Method Main
        /// Entry point.
        /// </summary>
        public static void Main()
        {
            try
            {
                Stack<int> integerStack = new Stack<int>(5,12);
                Console.WriteLine(integerStack.Peek());
                for (var i = 0; i < integerStack.Capacity-2; i++)
                {
                    integerStack.Push(i);
                }
                Console.WriteLine(integerStack.Peek());
                Console.WriteLine( );
                while (integerStack.Size > 0)
                {
                    Console.WriteLine(integerStack.Pop());
                }

                integerStack.Pop(); // Trying to get an item from an empty stack.
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error : {e.Message}");
            }
        }
    }
}