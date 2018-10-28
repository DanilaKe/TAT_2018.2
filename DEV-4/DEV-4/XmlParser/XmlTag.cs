using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEV_4
{
    /// <summary>
    /// class XmlTag
    /// Implement some methods for interacting with tags.
    /// </summary>
    public class XmlTag
    {
        /// <summary>
        /// Method ImplementEndTag
        /// Implements closing a tag and removes it from the stack.
        /// </summary>
        /// <param name="StackWithTags">A stack containing the current tags.</param>
        /// <param name="flagsOfTheState">The current state of the parser.</param>
        /// <param name="endTag">endTag</param>
        public void ImplementEndTag(Stack<string> StackWithTags,ref FlagsOfTheState flagsOfTheState, StringBuilder endTag)
        {
            // If it is a closing tag, it checks for consistency with the tags in the stack.
            if (flagsOfTheState.EndTagFlag)
            {
                var tagWithoutValues = new string(StackWithTags.Peek().TakeWhile(x => x != ' ').ToArray());
                // Determines if the top of the stack matches the closing tag.
                if (endTag.ToString() != tagWithoutValues)
                {
                    throw new Exception("Incorrectly closed tags.");
                }    

                flagsOfTheState.TagFlag = false;
                flagsOfTheState.EndTagFlag = false;
                // Remove a closed tag from the stack.
                StackWithTags.Pop();
                endTag.Clear();
            }
        }
        
        /// <summary>
        /// Method ImplemetTag
        /// Implements simple tag and adds it from the stack.
        /// </summary>
        /// <param name="StackWithTags">A stack containing the current tags.</param>
        /// <param name="tag">Added tag.</param>
        /// <param name="flagsOfTheState">The current state of the parser.</param>
        public void ImplemetTag(Stack<string> StackWithTags, StringBuilder tag, ref FlagsOfTheState flagsOfTheState)
        {
            flagsOfTheState.TagFlag = false;
            // If the line with the new tag is not empty adds to the stack.
            if (tag.ToString() != string.Empty)
            {
                StackWithTags.Push(tag.ToString());
            }

            tag.Clear();
        }
        
        /// <summary>
        /// Method ImplemetEmptyTag
        /// Implements empty tag and create new argument.
        /// </summary> 
        /// <param name="StackWithTags">A stack containing the current tags.</param>
        /// <param name="EmptyTag">Added tag.</param>
        /// <param name="flagsOfTheState">A stack containing the current tags.</param>
        /// <param name="parsedResult">List with parsed arguments.</param>
        public void ImplemetEmptyTag(Stack<string> StackWithTags, StringBuilder EmptyTag, ref FlagsOfTheState flagsOfTheState, List<string> parsedResult)
        {
            var argument = new ReadyArgument();
            flagsOfTheState.TagFlag = false;
            // Remove character '/' from addString.
            EmptyTag.Length = EmptyTag.Length - 1;
            argument.CreateArgument(EmptyTag,StackWithTags, parsedResult,ref flagsOfTheState);
        }
        
        /// <summary>
        /// Method SkipComment
        /// Moves the index of the character being processed to the end of the comment.
        /// </summary>
        /// <param name="XmlString">XML file is translated into a string.</param>
        /// <param name="flagsOfTheState">The current state of the parser.</param>
        /// <param name="index">The index of the character being processed.</param>
        public void SkipComment(string XmlString, ref FlagsOfTheState flagsOfTheState, ref int index)
        {
            while (flagsOfTheState.CommentFlag)
            {
                if (index+2 > XmlString.Length)
                {
                    new Exception("Comment is not closed.");
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
    }
}