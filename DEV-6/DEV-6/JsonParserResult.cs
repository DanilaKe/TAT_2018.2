using System.Collections.Generic;
using System.Text;

namespace DEV_6
{
    public class JsonParserResult : ParsedResult
    {
        public List<string> XmlResult;
        private Stack<string> OpenObject;
        private int spaceCount;
        
        public JsonParserResult(Stack<string> openObject)
        {
            OpenObject = openObject;
            XmlResult = new List<string>();
        }

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
        
        public void ExecuteArray(Queue<string> jsonArray)
        {
            spaceCount--;
            XmlResult.RemoveAt(XmlResult.Count-1);
            StringBuilder Tabs = new StringBuilder();
            for (var i = 0; i < spaceCount; i++)
            {
                Tabs.Append("    ");
            }

            string tag;
            if (OpenObject.Count > 0)
            {
                tag = OpenObject.Pop();
            }
            else
            {
                tag = "SomeArray";
            }
                
            while (jsonArray.Count > 0)
            {
                XmlResult.Add($"{Tabs}<{tag}>");
                XmlResult.Add($"{Tabs}    {jsonArray.Dequeue()}");
                XmlResult.Add($"{Tabs}</{tag}>");
            }
        }

    }
    
    
}