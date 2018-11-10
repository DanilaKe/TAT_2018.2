using System;
using System.Collections.Generic;
using System.Text;

namespace DEV_6
{
    public class JsonParser : Parser
    {
        private Stack<char> OpenBrackets;
        private Stack<string> OpenObject;
        private int objectCount;
        private int arrayCount;
        private bool stringFlag;
        private StringBuilder parsingElement;
        
        public JsonParser(string fileAddress) : base(fileAddress) { }

        public override ParsedResult Parse()
        {
            OpenBrackets = new Stack<char>();
            OpenObject = new Stack<string>();
            parsingElement = new StringBuilder();
            FileToStringConverter jsonConverter = new FileToStringConverter();
            string json = jsonConverter.Convert(FileAddress);
            
            ParseJsonFile(json);
            return new XmlResult();
        }

        private void ParseJsonFile(string JsonString)
        {
            for (var i = 0; i < JsonString.Length; i++)
            {
                // Skip character if it is a space or a line break.
                if (((JsonString[i] == ' ') && !stringFlag) || (JsonString[i] == '\n'))
                {
                    continue;
                }
                
                if (JsonString[i] == '"')
                {
                    if (stringFlag)
                    {
                        if (OpenBrackets.Peek() != JsonString[i])
                        {
                            throw new Exception();
                        }

                        stringFlag = false;
                        OpenBrackets.Pop();
                        Console.WriteLine(parsingElement.ToString());
                        parsingElement.Clear();
                    }
                    else
                    {
                        OpenBrackets.Push(JsonString[i]);
                        stringFlag = true;
                    }
                    continue;
                }

                if (JsonString[i] == ':')
                {
                    continue;
                }

                if (JsonString[i] == ',')
                {
                    continue;
                }
                
                if (JsonString[i] == '{' && !stringFlag)
                {
                    OpenObject.Push(parsingElement.ToString());
                    parsingElement.Clear();
                    OpenBrackets.Push(JsonString[i]);
                    objectCount++;
                    continue;
                }

                if (JsonString[i] == '[' && !stringFlag)
                {
                    OpenObject.Push(parsingElement.ToString());
                    parsingElement.Clear();
                    OpenBrackets.Push(JsonString[i]);
                    arrayCount++;
                    continue;
                }
                              
                if (JsonString[i] == '}' && !stringFlag)
                {
                    if ((objectCount < 1) || (OpenBrackets.Peek() != '{'))
                    {
                        throw new Exception();
                    }

                    objectCount--;
                    OpenBrackets.Pop();
                    continue;
                }

                if (JsonString[i] == ']' && !stringFlag)
                {
                    if ((arrayCount < 1) || (OpenBrackets.Peek() != '['))
                    {
                        throw new Exception();
                    }

                    arrayCount--;
                    OpenBrackets.Pop();
                    continue;
                }
                
                parsingElement.Append(JsonString[i]);
            }
            Console.Write(parsingElement);
        }
        
    }
}