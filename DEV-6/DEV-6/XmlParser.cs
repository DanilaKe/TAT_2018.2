namespace DEV_6
{
    public class XmlParser : Parser
    {
        public XmlParser(string fileAddress) : base(fileAddress) { }

        public override ParsedResult Parse()
        {
            return new JsonResult();
        }
    }
}