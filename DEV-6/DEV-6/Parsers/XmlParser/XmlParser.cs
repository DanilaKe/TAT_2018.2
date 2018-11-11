using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEV_6
{
    /// <summary>
    /// Class XmlParser
    /// Parse XML string.
    /// </summary>
    public class XmlParser : Parser
    {
        private FlagsOfTheState flagsOfTheState;  
        private List<string> ParsedResult;
        
        private string XmlString { get; set; }
        // Stack of open tags.
        private Stack<string> StackWithTags { get; }
        private StringBuilder parsingElement { get; }
        private XmlParserResult Result;
        
        public XmlParser(string fileAddress) : base(fileAddress)
        {
            flagsOfTheState = new FlagsOfTheState();
            parsingElement = new StringBuilder();
            StackWithTags = new Stack<string>();
            Result = new XmlParserResult(StackWithTags);
        }

        /// <summary>
        /// Method Parsing
        /// Gets the address of the XML file and starts ParsingXML method.
        /// </summary> 
        /// <returns>Parsed list of strings.</returns>
        public override List<string> Parse()
        {
            if (FileAddress == null)
            {
                throw new Exception("Empty address.");
            }
            // Convert the file to a string.
            var XmlToStringConverter = new FileToStringConverter();
            XmlString = XmlToStringConverter.Convert(FileAddress);
            ParsingXml();
            
            return Result.XmlResult;
        }
        
        /// <summary>
        /// Method ParsingXml
        /// Parsing a string, if the XML file is compiled
        /// correctly, returns the result of the parsing.
        /// </summary>
        private void ParsingXml()
        {   
            for (var i = 0; i < XmlString.Length; i++)
            {
                SkipComment(ref i);

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
                    if (parsingElement.ToString() != string.Empty)
                    {
                        Result.CreateArg(parsingElement.ToString());
                    }
                    parsingElement.Clear();
                    GetTypeOfTag(XmlString, flagsOfTheState, ref i);
                    
                    continue;
                }


                if (XmlString[i] == '>')
                {
                    // Check for closing only open tag.
                    if (!flagsOfTheState.TagFlag)
                    {
                        throw new Exception("Incorrect brackets.");
                    }
                    
                    SkipDoctype();
                    
                    // Check for XML declaration at the beginning.
                    if (!flagsOfTheState.XmlFlag)
                    {
                        ImplementDeclarationTag();
                        flagsOfTheState.DisableParsingTag();
                        continue;
                    }
                    
                    // If it is a closing tag, it checks for consistency with the tags in the stack.
                    if (flagsOfTheState.ClosingTagFlag)
                    {
                        ImplementedClosingTag();
                        
                        flagsOfTheState.DisableParsingTag();
                        continue;
                    }
                    
                    // If this is an empty tag. (< ... />)
                    if (XmlString[i - 1] == '/')
                    {
                        Result.CreateEmptyArg(parsingElement.ToString());
                        parsingElement.Clear();
                        flagsOfTheState.DisableParsingTag();
                        continue;
                    }
                    
                    StackWithTags.Push(parsingElement.ToString());
                    Result.OpenTag();
                    parsingElement.Clear();
                    flagsOfTheState.DisableParsingTag();
                    
                    continue;
                }

                if (!flagsOfTheState.TagFlag)
                {
                    flagsOfTheState.ArgumentFlag = true;
                }

                parsingElement.Append(XmlString[i]);
            }

        /*    if (StackWithTags.Count != 0)
            {
                throw new Exception("Incorrectly closed tags.");
            }*/

        }
        
        /// <summary>
        /// Method GetTypeOfTag
        /// Gives type tag.
        /// </summary>
        /// <param name="XmlString">XML file is translated into a string.</param>
        /// <param name="flagsOfTheState">The current state of the parser.</param>
        /// <param name="index">The index of the character being processed.</param>
        public void GetTypeOfTag(string XmlString,FlagsOfTheState flagsOfTheState, ref int index)
        {
            flagsOfTheState.TagFlag = true;
            // Separates the tag from the closing tag.
            if (XmlString[index + 1] == '/')
            {
                index++;
                flagsOfTheState.ClosingTagFlag = true;
            }
                    
            // Separates the tag from the comment.
            if ((XmlString[index + 1] == '!') && (XmlString[index + 2] == '-') && (XmlString[index + 3] == '-'))
            {
                index += 3; // Skipping, the character of the start of the comment (<!--).
                flagsOfTheState.CommentFlag = true;
                flagsOfTheState.TagFlag = false;
            }
        }
        
        /// <summary>
        /// Method SkipComment
        /// Moves the index of the character being processed to the end of the comment.
        /// </summary>
        /// <param name="index">The index of the character being processed.</param>
        private void SkipComment(ref int index)
        {
            while (flagsOfTheState.CommentFlag)
            {
                if (index+2 > XmlString.Length)
                {
                    throw new Exception("Comment is not closed.");
                }
                    
                // Search end of comment
                if ((XmlString[index] == '-') && (XmlString[index+1] == '-') && (XmlString[index+2] == '>'))
                {
                    index += 2; // Skipping, the character of the end of the comment(-->).
                    flagsOfTheState.CommentFlag = false;
                }

                index++;
            }
        }
        
        /// <summary>
        /// Method SkipDoctype
        /// Skip doctype XML tag. (<!DOCTYPE ... >)
        /// </summary>
        private void SkipDoctype()
        {
            if (parsingElement.ToString().Contains("!DOCTYPE"))
            {
                parsingElement.Clear();
                flagsOfTheState.DisableParsingTag();
            }
        }

        private void ImplementedClosingTag()
        {
            var tagWithoutValues = new string(StackWithTags.Peek().TakeWhile(x => x != ' ').ToArray());
            // Determines if the top of the stack matches the closing tag.
            if (parsingElement.ToString() != tagWithoutValues)
            {
                throw new Exception("Incorrectly closed tags.");
            } 
            Result.CloseTag();
            parsingElement.Clear();
            // Remove a closed tag from the stack.
            StackWithTags.Pop();
        }

        private void ImplementDeclarationTag()
        {
            try
            {
                if (parsingElement.ToString().ToLower().Contains("?xml"))
                {
                    flagsOfTheState.XmlFlag = true;
                    parsingElement.Clear();
                }
                else
                {
                    throw new Exception("This is not an XML file (there is no XML tag at the beginning)."); 
                }   
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }  
        }
    }
}