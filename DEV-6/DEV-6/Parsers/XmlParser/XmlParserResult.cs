using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEV_6
{
    /// <summary>
    /// 
    /// </summary>
    public class XmlParserResult
    {
        public List<string> XmlResult;
        private readonly Stack<string> OpenObject;
        private int spaceCount = 1;
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
            
            var TagWithoutValues = new string(OpenObject.Peek().TakeWhile(x => x != ' ').ToArray());
            if (OpenObject.Count != 0)
            {
                AddedElement = $"{Tabs}\"{TagWithoutValues}\"";
            }
         
        }

        public void CloseTag()
        {
            StringBuilder Tabs = new StringBuilder();
            for (var i = 0; i < spaceCount; i++)
            {
                Tabs.Append("    ");
            }
            
            XmlResult.Add($"{AddedElement},");
            var argumets = OpenObject.Peek().Split(' ');
            if (argumets.Length > 1)
            {
                XmlResult.Add($"{Tabs}{{");
                for (int i = 1; i < argumets.Length; i++)
                {
                    XmlResult.Add($"{Tabs}    {argumets[i].Replace('=',':')},");
                }
                XmlResult.Add($"{Tabs}}}");
            }
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
            var argWithoutValues = new string(arg.TakeWhile(x => x != ' ').ToArray());
            XmlResult.Add(argWithoutValues + arg.Replace(argWithoutValues, String.Empty));
        }
    }
}