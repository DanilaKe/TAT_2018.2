using System;

namespace DEV_4.Stack
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
        /// Method Resize
        /// Change limits the size.
        /// </summary>
        /// <param name="newSize">new stack size</param>
        internal void Resize(int newSize)
        {
            Capacity = newSize;
        }
        
        /// <summary>
        /// Method Push
        /// Push new element in stack.
        /// </summary>
        /// <param name="addedElement">new element in stack</param>
        /// <exception cref="StackOverflowException">Stack overflow.</exception>
        internal void Push(TClass addedElement)
        {
            if (Size + 1 > Capacity)
            {
                throw new StackOverflowException("Stack overflow.");
            }
            
            var newElement = new Node<TClass>(addedElement,Head);
            Head = newElement;
            ++Size;
        }
        
        /// <summary>
        /// Method Pop
        /// Return value top of the stack & change link to the top of the stack to the previous item.
        /// </summary>
        /// <returns>value top of the stack.</returns>
        /// <exception cref="EmptyStackException">Empty stack.</exception>
        internal TClass Pop()
        {
            if (Head == null)
            {
                throw new EmptyStackException("Empty stack.");
            }
            
            TClass returnElement = Head.GetValue();
            --Size;
            Head = Head.GetNext();
            
            return returnElement;
        }
         /// <summary>
        /// Method Peek
        /// Return value top of the stack.
        /// </summary>
        /// <returns>value top of the stack</returns>
        /// <exception cref="EmptyStackException">Empty stack.</exception>
        internal TClass Peek()
        {
            if (Head == null)
            {
                throw new EmptyStackException("Empty stack.");
            }
            
            TClass returnElement = Head.GetValue();
            
            return returnElement;  
        }
    }
}