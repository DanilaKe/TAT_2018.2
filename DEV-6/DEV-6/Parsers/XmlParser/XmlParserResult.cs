using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEV_6
{
    public class XmlParserResult
    {
        public List<string> XmlResult;
        private Stack<string> OpenObject;
        private int spaceCount;
        
        public XmlParserResult(Stack<string> openObject)
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
                XmlResult.Add($"{Tabs.ToString()}{OpenObject.Peek()} : ");
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
                OpenObject.Pop();
                XmlResult.Add($"{Tabs.ToString()},");
            }
        }

        public void CreateArg(string arg)
        {
            StringBuilder Tabs = new StringBuilder();
            for (var i = 0; i < spaceCount+1; i++)
            {
                Tabs.Append("    ");
            }
            
            if (OpenObject.Count != 0)
            {
                XmlResult.Add($"{Tabs.ToString()}{arg}");
            }
        }

        public void CreateEmptyArg(string arg)
        {
            StringBuilder newArg  = new StringBuilder(arg);
            newArg.Length -= 1;
            var argWithoutValues = new string(newArg.ToString().TakeWhile(x => x != ' ').ToArray());
            arg = argWithoutValues + newArg.Replace(argWithoutValues, String.Empty);
        }
    }
}