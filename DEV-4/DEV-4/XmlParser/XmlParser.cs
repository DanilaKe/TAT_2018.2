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
        private FlagsOfTheState flagsOfTheState;  
        private string XmlString { get; set; }
        private string XmlAddress { get; }
        private List<string> ParsedResult { get; }
        private XmlTag XmlTag { get; }
        private ReadyArgument Argument { get; }
        private TagTypeSeparator Separator { get; }
        private StringBuilder AddString { get; }
        // Stack of open tags.
        private Stack<string> StackWithTags { get; }
        
        public XmlParser(string receivedString)
        {
            XmlAddress = receivedString;
            flagsOfTheState = new FlagsOfTheState();
            XmlTag = new XmlTag();
            Argument = new ReadyArgument();
            Separator = new TagTypeSeparator(); 
            AddString = new StringBuilder();
            StackWithTags = new Stack<string>();
            ParsedResult = new List<string>();
        }

        public List<string> Parsing()
        {
            if (XmlAddress == null)
            {
                throw new Exception("Empty address.");
            }
            else
            {
                // Convert the file to a string.
                var XmlToStringConverter = new FileToStringConverter(XmlAddress);
                XmlString = XmlToStringConverter.ReturnedString;
                ParsingXml();
            }

            return ParsedResult;
        }
        
        /// <summary>
        /// Method Parsing
        /// Parsing a string, if the XML file is compiled
        /// correctly, returns the result of the parsing.
        /// </summary>
        /// <returns>Parsed list of strings.</returns>
        private void ParsingXml()
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
                    Argument.CreateArgument(AddString, StackWithTags, ParsedResult, ref flagsOfTheState);

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
                        Separator.CheckForXmlDeclaration(AddString,ref flagsOfTheState);
                    }
                    
                    // If it is a closing tag, it checks for consistency with the tags in the stack.
                    if (flagsOfTheState.EndTagFlag)
                    {
                        XmlTag.ImplementEndTag(StackWithTags, ref flagsOfTheState, AddString);
                    }
                    
                    // If this is an empty tag. (< ... />)
                    if (XmlString[i - 1] == '/')
                    {
                        XmlTag.ImplemetEmptyTag(StackWithTags, AddString, ref flagsOfTheState, ParsedResult);
                    }
                    
                    Separator.ChecKDoctype(AddString, ref flagsOfTheState);
                    XmlTag.ImplemetTag(StackWithTags,AddString,ref flagsOfTheState);
                    
                    continue;
                }

                if (!flagsOfTheState.TagFlag)
                {
                    flagsOfTheState.ArgumentFlag = true;
                }

                AddString.Append(XmlString[i]);
            }

            if (StackWithTags.Count != 0)
            {
                throw new Exception("Incorrectly closed tags.");
            }
        }
    }
}