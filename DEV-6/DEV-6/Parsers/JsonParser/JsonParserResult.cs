using System.Collections.Generic;
using System.Text;

namespace DEV_6
{
    /// <summary>
    /// Class XmlParserResult
    /// The result of parsing XML file, in the form of a JSON file.
    /// </summary>
    public class JsonParserResult
    {
        public List<string> XmlResult;
        private Stack<string> OpenObject;
        private int spaceCount;
        
        public JsonParserResult(Stack<string> openObject)
        {
            OpenObject = openObject;
            XmlResult = new List<string>();
        }
        
        /// <summary>
        /// Method OpenTag
        /// Creating an open tag according to the rules of the XML file.
        /// </summary>
        public void OpenTag()
        {
            StringBuilder Tabs = new StringBuilder();
            for (var i = 0; i < spaceCount; i++)
            {
                Tabs.Append("    ");
            }
            
            if (OpenObject.Count != 0)
            {
                spaceCount++;
                XmlResult.Add($"{Tabs.ToString()}<{OpenObject.Peek()}>");
            }
         
        }
        
        /// <summary>
        /// Method CloseTag
        /// Creating an close tag according to the rules of the XML file.
        /// </summary>
        public void CloseTag()
        {
            spaceCount--;
            StringBuilder Tabs = new StringBuilder();
            for (var i = 0; i < spaceCount; i++)
            {
                Tabs.Append("    ");
            }
            
            if (OpenObject.Count != 0)
            {
                XmlResult.Add($"{Tabs.ToString()}</{OpenObject.Pop()}>");
            }
        }
        
        /// <summary>
        /// Method CreateArg
        /// Creating a argument according to the rules of the XML file.
        /// </summary>
        public void CreateArg()
        {
            StringBuilder Tabs = new StringBuilder();
            for (var i = 0; i < spaceCount+1; i++)
            {
                Tabs.Append("    ");
            }
            
            if (OpenObject.Count != 0)
            {
                XmlResult.Add($"{Tabs.ToString()}{OpenObject.Pop()}");
            }
        }

    }
    
    
}