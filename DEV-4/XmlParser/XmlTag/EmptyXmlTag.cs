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
            ActualTag = emptyTag;
            Argument = argument;
        }
        
        public sealed override void Implement()
        {
            // Remove character '/' from addString.
            ActualTag = DeleteLastSymbol();
            Argument.CreateArgument(ActualTag);
        }

        public string DeleteLastSymbol()
        {
            StringBuilder newString =new StringBuilder(ActualTag);
            return newString.Remove(ActualTag.Length-1,1).ToString();
        }
    }
}