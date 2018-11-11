using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEV_6
{
    public class XmlParserResult
    {
        public List<string> XmlResult;
        private readonly Stack<string> OpenObject;
        private int spaceCount = 0;
        private string AddedElement;
        
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
                AddedElement = $"{Tabs}\"{OpenObject.Peek()}\"";
            }
         
        }

        public void CloseTag()
        {
            spaceCount--;
            XmlResult.Add($"{AddedElement},");
        }

        public void CreateArg(string arg)
        {
            if (arg != String.Empty)
            {
                AddedElement = ($"{AddedElement} : \"{arg}\"");
            }
        }

        public void CreateEmptyArg(string arg)
        {
            StringBuilder newArg  = new StringBuilder(arg);
            newArg.Length -= 1;
            var argWithoutValues = new string(newArg.ToString().TakeWhile(x => x != ' ').ToArray());
            XmlResult.Add(argWithoutValues + newArg.Replace(argWithoutValues, String.Empty));
        }
    }
}