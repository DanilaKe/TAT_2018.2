using System.Collections.Generic;

namespace DEV_6
{
    public abstract class Parser
    {
        public string FileAddress { get; set; }

        public Parser(string fileAddress)
        {
            FileAddress = fileAddress;
        }
        
        public abstract List<string> Parse();
    }
}