using System;
using System.Text;

namespace DEV_4
{
    /// <summary>
    /// class TagTypeSeparator
    /// Engaged in the separation of tags into different types.
    /// </summary>
    public class TagTypeSeparator
    {
        /// <summary>
        /// Method GetTypeOfTag
        /// Gives type tag.
        /// </summary>
        /// <param name="XmlString">XML file is translated into a string.</param>
        /// <param name="flagsOfTheState">The current state of the parser.</param>
        /// <param name="index">The index of the character being processed.</param>
        public void GetTypeOfTag(string XmlString,ref FlagsOfTheState flagsOfTheState, ref int index)
        {
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

        /// <summary>
        /// Method CheckForXmlDeclaration
        /// Check for XML declaration at the beginning.
        /// </summary>
        /// <param name="checkedTag">The string is checked for the presence of XML declaration.</param>
        /// <param name="flagsOfTheState">The current state of the parser.</param>
        public void CheckForXmlDeclaration(StringBuilder checkedTag,ref FlagsOfTheState flagsOfTheState)
        {
            if (!flagsOfTheState.XmlFlag)
            {
                if (checkedTag.ToString().Contains("?xml"))
                {
                    flagsOfTheState.TagFlag = false;
                    flagsOfTheState.XmlFlag = true;
                    checkedTag.Clear();
                }
                else
                {
                    throw new Exception("This is not an XML file (there is no XML checkedTag at the beginning)."); 
                }           
            }
        }
        
        public void ChecKDoctype(StringBuilder checkedTag,ref FlagsOfTheState flagsOfTheState)
        {
            if (checkedTag.ToString().Contains("!DOCTYPE"))
            {
                flagsOfTheState.TagFlag = false;
                checkedTag.Clear();
            }
        }
        
    }
}