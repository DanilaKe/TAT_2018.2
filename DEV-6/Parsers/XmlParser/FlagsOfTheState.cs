namespace DEV_6
{
    /// <summary>
    /// struct FlagsOfTheState
    /// A structure consisting of flags that mark the current state of parsing.
    /// </summary>
    public class FlagsOfTheState
    {
        // Notes if this is a XML file.
        public bool XmlFlag { get; set; }
        // Notes that the tag is being parsed.
        public bool TagFlag { get; set; }
        // Notes that the closing tag is being parsed.
        public bool ClosingTagFlag { get; set; }
        // Notes that the argument is being parsed.
        public bool ArgumentFlag { get; set; }
        // Notes that the comment is being parsed.
        public bool CommentFlag { get; set; }

        public FlagsOfTheState()
        {
            XmlFlag = false;
            TagFlag = false;
            ClosingTagFlag = false;
            ArgumentFlag = false;
            CommentFlag = false;
        }
        
        public void DisableParsingTag()
        {
            TagFlag = false;
            ClosingTagFlag = false;
            ArgumentFlag = false;
        }
            
    }
}