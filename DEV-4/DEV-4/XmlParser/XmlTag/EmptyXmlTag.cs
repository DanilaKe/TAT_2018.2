using System.Text;

namespace DEV_4
{
    /// <summary>
    /// Class EmptyXmlTag
    /// Self-closing tag. (< ... />)
    /// </summary>
    public class EmptyXmlTag : IXmlTag
    {
        private StringBuilder tag = new StringBuilder();
        private ReadyArgument Argument;
        
        public EmptyXmlTag(ReadyArgument argument, string emptyTag)
        {
            tag.Append(emptyTag);
            Argument = argument;
        }
        
        public void Implement()
        {
            // Remove character '/' from addString.
            tag.Length = tag.Length - 1;
            Argument.CreateArgument(tag.ToString());
        }
    }
}