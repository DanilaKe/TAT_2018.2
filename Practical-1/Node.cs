namespace Practical_1
{
    
    /// <summary>
    /// Class Node
    /// One item on the stack.
    /// </summary>
    internal class Node<TClass>
    {
        private TClass Value { get; set; }
        private readonly Node<TClass> _next;

        /// <summary>
        /// Constructor one node of stack. 
        /// </summary>
        public Node(TClass addedElement, Node<TClass> nextElement)
        {
            Value = addedElement;
            _next = nextElement;
        }

        /// <summary>
        /// Method GetValue
        /// Return value of one node.
        /// </summary>
        public TClass GetValue()
        {
            return Value;
        }
        
        /// <summary>
        /// Method GetNext
        /// Return link to the next node.
        /// </summary>
        public Node<TClass> GetNext()
        {
            return _next;
        }
    }
}