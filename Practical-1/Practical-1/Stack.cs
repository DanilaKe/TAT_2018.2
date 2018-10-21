using System;

namespace Practical_1
{
    /// <summary>
    /// Class Stack
    /// New implementation of the data structure Stack.
    /// </summary>
    /// <typeparam name="TClass"></typeparam>
    public class Stack<TClass>
    {
        private Node<TClass> Head; // Link to the top of the stack.
        public int Capacity { get; set; }
        public int Size { get; set; }

        /// <summary>
        /// Constructor stack without data. 
        /// </summary>
        public Stack()
        {
            Head = null;
            Capacity = 0;
            Size = 0;
        }
        
        /// <summary>
        /// Constructor stack with one element.
        /// </summary>
        /// <param name="addedElement">first element in stack.</param>
        public Stack(TClass addedElement)
        {
            var NewElement = new Node<TClass>(addedElement,null);
            Head = NewElement;
            Capacity = 1;
            Size++;
        }
        
        /// <summary>
        /// Constructor stack with one element and limits the size.
        /// </summary>
        /// <param name="addedElement">first element in stack.</param>
        /// <param name="stackSize">limit size.</param>
        public Stack(TClass addedElement,int stackSize)
        {
            var NewElement = new Node<TClass>(addedElement,null);
            Head = NewElement;
            Capacity = stackSize;
            Size++;
        }

        /// <summary>
        /// Change limits the size.
        /// </summary>
        /// <param name="newSize">new stack size</param>
        internal void Resize(int newSize)
        {
            Capacity = newSize;
        }
    }
}