using System;

namespace DEV_4
{
    public class XmlComment
    {
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