using System.Text;

namespace DEV_4
{
    /// <summary>
    /// Class EmptyXmlTag
    /// Self-closing tag. (< ... />)
    /// </summary>
    public class EmptyXmlTag : AbstractTag
    {
       
       private Argument Argument;
        
        public EmptyXmlTag(Argument argument, string emptyTag)
        {
            actualTag = emptyTag;
            Argument = argument;
        }
        
        public sealed override void Implement()
        {
            // Remove character '/' from addString.
            actualTag = DeleteLastSymbol();
            Argument.CreateArgument(actualTag);
        }

        public string DeleteLastSymbol()
        {
            StringBuilder newString =new StringBuilder(actualTag);
            return newString.Remove(actualTag.Length-1,1).ToString();
        }
    }
}