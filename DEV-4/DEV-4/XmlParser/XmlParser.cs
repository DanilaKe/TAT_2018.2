using System;
using System.Collections.Generic;
using System.Linq;
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
        FlagsOfTheState flagsOfTheState = new FlagsOfTheState();
        XmlComment comment = new XmlComment();
        ReadyArgument argument = new ReadyArgument();
        TagTypeSeparator Separator = new TagTypeSeparator(); 
        StringBuilder addString = new StringBuilder();
        // Stack of open tags.
        Stack<string> StackWithTags = new Stack<string>();
        List<string> parsedResult = new List<string>();
        
        public XmlParser(string receivedString)
        {
            XmlString = receivedString;
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
                comment.SkipComment(XmlString, ref flagsOfTheState, ref i);

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
                    argument.CreateArgument(addString, StackWithTags, parsedResult);

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
                    
                    // If this is an empty tag. (< ... />)
                    if (XmlString[i - 1] == '/')
                    {
                        flagsOfTheState.TagFlag = false;
                        // Remove character '/' from addString.
                        addString.Length = addString.Length - 1;
                        continue;
                    }
                    
                    // If it is a closing tag, it checks for consistency with the tags in the stack.
                    if (flagsOfTheState.EndTagFlag)
                    {
                        var tagWithoutValues = new string(StackWithTags.Peek().TakeWhile(x => x != ' ').ToArray());
                        if (addString.ToString() != tagWithoutValues)
                        {
                            throw new Exception("Incorrectly closed tags.");
                        }    

                        flagsOfTheState.TagFlag = false;
                        flagsOfTheState.EndTagFlag = false;
                        // Remove a closed tag from the stack.
                        StackWithTags.Pop();
                        addString.Clear();
                        continue;
                    }
                    
                    flagsOfTheState.TagFlag = false;
                    // If the line with the new tag is not empty adds to the stack.
                    if (addString.ToString() != string.Empty)
                    {
                        StackWithTags.Push(addString.ToString());
                    }

                    addString.Clear();
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