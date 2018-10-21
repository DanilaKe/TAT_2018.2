using System;

namespace P

{
    /// <summary>
    /// Class Stack
    /// New implementation of the data structure Stack.
    /// </summary>
    /// <typeparam name="TClass"></typeparam>
    public class Stack<TClass>
    {
        /// <summary>
        /// Constructor stack without data. 
        /// </summary>
        public Stack()
        {
            // TODO
        }
        
        /// <summary>
        /// Constructor stack with one element.
        /// </summary>
        /// <param name="addedElement">first element in stack.</param>
        public Stack(TClass addedElement)
        {
            // TODO
        }
        
        /// <summary>
        /// Constructor stack with one element and limits the size.
        /// </summary>
        /// <param name="addedElement">first element in stack.</param>
        /// <param name="stackSize">limit size.</param>
        public Stack(TClass addedElement,int stackSize)
        {
            // TODO
        }

        /// <summary>
        /// Change limits the size.
        /// </summary>
        /// <param name="newSize">new stack size</param>
        internal void Resize(int newSize)
        {
            // TODO
        }
        
        /// <summary>
        /// Push new element in stack.
        /// </summary>
        /// <param name="addedElement">new element in stack</param>
        /// <exception cref="StackOverflowException">Stack overflow.</exception>
        internal void Push(TClass addedElement)
        {
            // TODO
        }

        /// <summary>
        /// Return value top of the stack & change link to the top of the stack to the previous item.
        /// </summary>
        /// <returns>value top of the stack.</returns>
        /// <exception cref="EmptyStackException">Empty stack.</exception>
        internal TClass Pop()
        {
            /
        }
        
        /// <summary>
        /// Return value top of the stack.
        /// </summary>
        /// <returns>value top of the stack</returns>
        /// <exception cref="EmptyStackException">Empty stack.</exception>
        internal TClass GetHead()
        {
            try
            {
                if (Head == null)
                {
                    throw new EmptyStackException("Empty stack.");
                }
                TClass returnElement = Head.GetValue();
                return returnElement;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Class Node
    /// One item on the stack.
    /// </summary>
    internal class Node<TClass>
    {
        private TClass Value { get; set; }
        private readonly Node<TClass> _next;

        public Node(TClass addedElement, Node<TClass> nextElement)
        {
            Value = addedElement;
            _next = nextElement;
        }

        public TClass GetValue()
        {
            return Value;
        }
        
        public Node<TClass> GetNext()
        {
            return _next;
        }
    }
}