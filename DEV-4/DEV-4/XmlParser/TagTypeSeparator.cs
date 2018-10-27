using System;
using System.Text;

namespace DEV_4
{
    public class TagTypeSeparator
    {
        public void GetTypeOfTag(string XmlString,ref FlagsOfTheState flagsOfTheState, ref int index)
        {
            flagsOfTheState.ArgumentFlag = false;
            flagsOfTheState.TagFlag = true;
            // Separates the tag from the closing tag.
            if (XmlString[index + 1] == '/')
            {
                index++;
                flagsOfTheState.EndTagFlag = true;
            }
                    
            // Separates the tag from the comment.
            if ((XmlString[index + 1] == '!') && (XmlString[index + 2] == '-') && (XmlString[index + 3] == '-'))
            {
                index += 3; // Skipping, the character of the start of the comment (<!--).
                flagsOfTheState.CommentFlag = true;
                flagsOfTheState.TagFlag = false;
            }

            index++;
        }

        public void CheckForXmlDeclaration(StringBuilder addString,ref FlagsOfTheState flagsOfTheState)
        {
            if (!flagsOfTheState.XmlFlag)
            {
                if (addString.ToString().Contains("?xml"))
                {
                    flagsOfTheState.TagFlag = false;
                    flagsOfTheState.XmlFlag = true;
                    addString.Clear();
                }
                else
                {
                    throw new Exception("This is not an XML file (there is no XML declaration at the beginning)."); 
                }           
            }
        }
        
    }
}