using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEV_4
{
    public class ClosingXmlTag : IXmlTag
    {
        private Stack<string> StackWithTags;
        private string tag;
        
        public ClosingXmlTag(Stack<string> stackWithTags, string tag)
        {
            StackWithTags = stackWithTags;
            this.tag = tag;
        }
        
        public void Implemet()
        {
            var tagWithoutValues = new string(StackWithTags.Peek().TakeWhile(x => x != ' ').ToArray());
            // Determines if the top of the stack matches the closing tag.
            if (tag != tagWithoutValues)
            {
                throw new Exception("Incorrectly closed tags.");
            } 
            // Remove a closed tag from the stack.
            StackWithTags.Pop();
        }
    }
}