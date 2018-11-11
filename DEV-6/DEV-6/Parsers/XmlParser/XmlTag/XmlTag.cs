using System.Collections.Generic;

namespace DEV_6
{
    /// <summary>
    /// class XmlTag
    /// Default XML tag. (< ... >)
    /// </summary>
    public class XmlTag : AbstractTag
    {
        private Stack<string> StackWithTags;
        

        public XmlTag(Stack<string> stackWithTags, string tag)
        {
            StackWithTags = stackWithTags;
            this.actualTag = tag;
        }
        
        public sealed override void Implement()
        {
            if (actualTag != string.Empty)
            {
                StackWithTags.Push(actualTag);
            }
        }
    }
}