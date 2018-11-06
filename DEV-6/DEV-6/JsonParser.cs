namespace DEV_6
{
    public class JsonParser : Parser
    {
        public JsonParser(string fileAddress) : base(fileAddress) { }

        public override ParsedResult Parse()
        {
            return new XmlResult();
        }
    }
}