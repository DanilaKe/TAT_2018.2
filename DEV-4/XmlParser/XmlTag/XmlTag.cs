using System.Collections.Generic;

namespace DEV_4
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
            this.ActualTag = tag;
        }
        
        public sealed override void Implement()
        {
            if (ActualTag != string.Empty)
            {
                StackWithTags.Push(ActualTag);
            }
        }
    }
}