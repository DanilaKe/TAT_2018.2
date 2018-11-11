using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEV_6
{
    /// <summary>
    /// Class XmlParserResult
    /// The result of parsing XML file, in the form of a JSON file.
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
        
        /// <summary>
        /// Method OpenTag
        /// Creating an open tag according to the rules of the JSON file.
        /// </summary>
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

        /// <summary>
        /// Method CloseTag
        /// Creating an close tag according to the rules of the JSON file.
        /// </summary>
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

        /// <summary>
        /// Method CreateArg
        /// Creating a argument according to the rules of the JSON file.
        /// </summary>
        /// <param name="arg">string containing the argument</param>
        public void CreateArg(string arg)
        {
            if (arg != String.Empty)
            {
                AddedElement = ($"{AddedElement} : \"{arg}\"");
            }
        }
        
        /// <summary>
        /// Method CreateEmptyArg
        /// Creating a argument according to the rules of the JSON file.
        /// </summary>
        /// <param name="arg">string containing the argument</param>
        public void CreateEmptyArg(string arg)
        {
            var argWithoutValues = new string(arg.TakeWhile(x => x != ' ').ToArray());
            XmlResult.Add(argWithoutValues + arg.Replace(argWithoutValues, String.Empty));
        }
    }
}