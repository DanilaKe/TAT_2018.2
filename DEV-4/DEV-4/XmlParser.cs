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
            var parsedResult = new List<string>(); 
            // Notes if this is a XML file.
            var xmlFlag = false;
            // Notes that the tag is being parsed.
            var tagFlag = false;
            // Notes that the closing tag is being parsed.
            var endTagFlag = false;
            // Notes that the argument is being parsed.
            var argumentFlag = false;
            // Notes that the comment is being parsed.
            var commentFlag = false;
            
            // Stack of open tags.
            var StackWithTags = new Stack<string>();
            var addString = new StringBuilder();
            for (var i = 0; i < XmlString.Length; i++)
            {
                // Skip character if this is a comment.
                if (commentFlag)
                {
                    if (i+2 > XmlString.Length)
                    {
                        new Exception("comment is not closed");
                    }
                    
                    // Search end of comment
                    if ((XmlString[i] == '-') && (XmlString[i+1] == '-') && (XmlString[i+2] == '>'))
                    {
                        i += 2; // Skipping, the character of the end of the comment(-->).
                        commentFlag = false;
                    }    
                    
                    continue;
                }
                
                // Skip character if it is a space or a line break.
                if (((XmlString[i] == ' ') && (!tagFlag && !argumentFlag)) || (XmlString[i] == '\n'))
                {
                    continue;
                }
                
                if ((XmlString[i] == '<') && tagFlag)
                {
                    throw new Exception("Incorrect brackets.");
                }

                if (XmlString[i] == '<')
                {
                    argumentFlag = false;
                    // If there is a ready argument, then write it down.
                    if (addString.ToString() != String.Empty)
                    {
                        var parsedArgument = new StringBuilder();
                        var TagSetForArgument = StackWithTags.ToArray();
                        for (var j = TagSetForArgument.Length - 1; j >= 0; --j)
                        {
                            parsedArgument.Append($"{TagSetForArgument[j]} -> ");
                        }

                        parsedArgument.Append(addString.ToString());
                        parsedResult.Add(parsedArgument.ToString());
                        addString.Clear();
                    }
                    
                    // Separates the tag from the closing tag.
                    if (XmlString[i + 1] == '/')
                    {
                        i++;
                        endTagFlag = true;
                    }
                    
                    // Separates the tag from the comment.
                    if (XmlString[i + 1] == '!' && XmlString[i + 2] == '-' && XmlString[i + 3] == '-')
                    {
                        i += 3; // Skipping, the character of the start of the comment(<!--).
                        commentFlag = true;
                        continue;
                    }

                    tagFlag = true;
                    continue;
                }

                if (XmlString[i] == '>')
                {
                    if (!tagFlag)
                    {
                        throw new Exception("Incorrect brackets.");
                    }
                    
                    // Check for XML declaration at the beginning.
                    if (!xmlFlag)
                    {
                        if (addString.ToString().Contains("xml "))
                        {
                            tagFlag = false;
                            xmlFlag = true;
                            addString.Clear();
                            continue;
                        }
                            
                        throw new Exception("This is not an XML file (there is no XML declaration at the beginning)."); 
                    }
                    
                    // If this is an empty tag.
                    if (XmlString[i - 1] == '/')
                    {
                        tagFlag = false;
                        // Remove character '/' from addString.
                        addString.Length = addString.Length - 1;
                        continue;
                    }
                    
                    // If it is a closing tag, it checks for consistency with the tags in the stack.
                    if (endTagFlag)
                    {
                        var tagWithoutValues = new string(StackWithTags.Peek().TakeWhile(x => x != ' ').ToArray());
                        if (addString.ToString() != tagWithoutValues)
                        {
                            throw new Exception("Incorrectly closed tags.");
                        }    

                        tagFlag = false;
                        endTagFlag = false;
                        // Remove a closed tag from the stack.
                        StackWithTags.Pop();
                        addString.Clear();
                        continue;
                    }
                    
                    tagFlag = false;
                    // If the line with the new tag is not empty adds to the stack.
                    if (addString.ToString() != string.Empty)
                    {
                        StackWithTags.Push(addString.ToString());
                    }

                    addString.Clear();
                    continue;
                }

                if (!tagFlag)
                {
                    argumentFlag = true;
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