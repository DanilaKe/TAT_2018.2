﻿using System.Collections.Generic;
using System.Text;

namespace DEV_6
{
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

    }
    
    
}