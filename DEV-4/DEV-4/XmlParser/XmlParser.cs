using System;
using System.Collections.Generic;
using System.Text;

namespace DEV_4
{
    /// <summary>
    /// Class XmlParser
    /// Parse XML string.
    /// </summary>
    public class XmlParser
    {
        private string XmlString { get; set; }
        private List<string> parsedResult;

        private FlagsOfTheState flagsOfTheState;
        private XmlTag XmlTag;
        private ReadyArgument argument;
        private TagTypeSeparator Separator;

        private StringBuilder addString;
        // Stack of open tags.
        private Stack<string> StackWithTags;
        
        public XmlParser(string receivedString)
        {
            XmlString = receivedString;
            flagsOfTheState = new FlagsOfTheState();
            XmlTag = new XmlTag();
            argument = new ReadyArgument();
            Separator = new TagTypeSeparator(); 
            addString = new StringBuilder();
            StackWithTags = new Stack<string>();
            parsedResult = new List<string>();
        }
        
        /// <summary>
        /// Method Parsing
        /// Parsing a string, if the XML file is compiled
        /// correctly, returns the result of the parsing.
        /// </summary>
        /// <returns>Parsed list of strings.</returns>
        public List<string> Parsing()
        {   
            for (var i = 0; i < XmlString.Length; i++)
            {
                // Skip XML comment.
                XmlTag.SkipComment(XmlString, ref flagsOfTheState, ref i);

                // Skip character if it is a space or a line break.
                if (((XmlString[i] == ' ') && (!flagsOfTheState.TagFlag && !flagsOfTheState.ArgumentFlag)) || (XmlString[i] == '\n'))
                {
                    continue;
                }

                if (XmlString[i] == '<')
                {
                    // Check for opening tag one more time.
                    if (flagsOfTheState.TagFlag)
                    {
                        throw new Exception("Incorrect brackets.");
                    }

                    // If there is a ready argument, then write it down.
                    argument.CreateArgument(addString, StackWithTags, parsedResult, ref flagsOfTheState);

                    Separator.GetTypeOfTag(XmlString, ref flagsOfTheState, ref i);
                    if (flagsOfTheState.CommentFlag)
                    {
                        continue;
                    }
                }


                if (XmlString[i] == '>')
                {
                    // Check for closing only open tag.
                    if (!flagsOfTheState.TagFlag)
                    {
                        throw new Exception("Incorrect brackets.");
                    }
                    
                    // Check for XML declaration at the beginning.
                    if (!flagsOfTheState.XmlFlag)
                    {
                        Separator.CheckForXmlDeclaration(addString,ref flagsOfTheState);
                    }
                    
                    // If it is a closing tag, it checks for consistency with the tags in the stack.
                    if (flagsOfTheState.EndTagFlag)
                    {
                        XmlTag.ImplementEndTag(StackWithTags, ref flagsOfTheState, addString);
                    }
                    
                    // If this is an empty tag. (< ... />)
                    if (XmlString[i - 1] == '/')
                    {
                        XmlTag.ImplemetEmptyTag(StackWithTags, addString, ref flagsOfTheState, parsedResult);
                    }
                    
                    XmlTag.ImplemetTag(StackWithTags,addString,ref flagsOfTheState);
                    
                    continue;
                }

                if (!flagsOfTheState.TagFlag)
                {
                    flagsOfTheState.ArgumentFlag = true;
                }

                addString.Append(XmlString[i]);
            }

            if (StackWithTags.Count != 0)
            {
                throw new Exception("Incorrectly closed tags.");
            }
            
            return parsedResult;
        }
    }
}