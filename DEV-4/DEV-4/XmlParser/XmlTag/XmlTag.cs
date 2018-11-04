using System.Collections.Generic;

namespace DEV_4
{
    /// <summary>
    /// class XmlTag
    /// Default XML tag. (< ... >)
    /// </summary>
    public class XmlTag : IXmlTag
    {
        private Stack<string> StackWithTags;
        private string tag;

        public XmlTag(Stack<string> stackWithTags, string tag)
        {
            StackWithTags = stackWithTags;
            this.tag = tag;
        }
        
        public void Implement()
        {
            if (tag != string.Empty)
            {
                StackWithTags.Push(tag);
            }
        }
    }
}