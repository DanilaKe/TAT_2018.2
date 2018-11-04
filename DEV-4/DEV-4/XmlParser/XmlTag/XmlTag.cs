using System.Collections.Generic;

namespace DEV_4
{
    public class XmlTag : IXmlTag
    {
        private Stack<string> StackWithTags;
        private string tag;

        public XmlTag(Stack<string> stackWithTags, string tag)
        {
            StackWithTags = stackWithTags;
            this.tag = tag;
        }
        
        public void Implemet()
        {
            if (tag != string.Empty)
            {
                StackWithTags.Push(tag);
            }
        }
    }
}