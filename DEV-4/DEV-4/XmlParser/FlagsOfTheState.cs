namespace DEV_4
{
    public struct FlagsOfTheState
    {
        public bool XmlFlag { get; set; }
        // Notes that the tag is being parsed.
        public bool TagFlag { get; set; }
        // Notes that the closing tag is being parsed.
        public bool EndTagFlag { get; set; }
        // Notes that the argument is being parsed.
        public bool ArgumentFlag { get; set; }
        // Notes that the comment is being parsed.
        public bool CommentFlag { get; set; }
    }
}