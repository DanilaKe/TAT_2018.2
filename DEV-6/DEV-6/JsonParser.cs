using System;
using System.Collections.Generic;
using System.Text;

namespace DEV_6
{
    public class JsonParser : Parser
    {
        private Stack<char> OpenBrackets;
        private Stack<string> OpenObject;
        private Stack<string> JsonArray;
        private int objectCount;
        private int arrayCount;
        private bool stringFlag;
        private bool argFlag;
        private bool arrayFlag;
        private StringBuilder parsingElement;
        private JsonParserResult Result;
        
        public JsonParser(string fileAddress) : base(fileAddress) { }

        public override List<string> Parse()
        {
            OpenBrackets = new Stack<char>();
            OpenObject = new Stack<string>();
            JsonArray = new Stack<string>();
            Result = new JsonParserResult(OpenObject);
            parsingElement = new StringBuilder();
            FileToStringConverter jsonConverter = new FileToStringConverter();
            string json = jsonConverter.Convert(FileAddress);
            
            ParseJsonFile(json);
            return Result.XmlResult;
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
                        if (arrayFlag)
                        {
                            JsonArray.Push(parsingElement.ToString());
                            parsingElement.Clear();
                            continue;
                        }
                        
                        OpenObject.Push(parsingElement.ToString());
                        parsingElement.Clear();
                        if (argFlag)
                        {
                            argFlag = false;
                            Result.CreateArg();
                            Result.CloseTag();
                        }
                    }
                    else
                    {
                        OpenBrackets.Push(JsonString[i]);
                        stringFlag = true;
                    }
                    continue;
                }
                
                if (stringFlag)
                {
                    parsingElement.Append(JsonString[i]);
                }

                if (JsonString[i] == ':' && !stringFlag)
                {
                    if (JsonString[i+1] == '{' || JsonString[i+2] == '{')
                    {
                        continue;
                    }

                    argFlag = true;
                    Result.OpenTag();
                    continue;
                }

                if (JsonString[i] == ',' && !stringFlag)
                {
                    continue;
                }
                 
                if (JsonString[i] == '{' && !stringFlag)
                {
                    OpenBrackets.Push(JsonString[i]);
                    Result.OpenTag();
                    objectCount++;
                    continue;
                }

                if (JsonString[i] == '[' && !stringFlag)
                {
                    OpenBrackets.Push(JsonString[i]);
                    arrayFlag = true;
                    arrayCount++;
                    continue;
                }
                              
                if (JsonString[i] == '}' && !stringFlag)
                {
                    if ((objectCount < 1) || (OpenBrackets.Peek() != '{'))
                    {
                        throw new Exception();
                    }
          
                    Result.CloseTag();
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

                    arrayFlag = false;
                    Result.ExecuteArray(JsonArray);
                    arrayCount--;
                    OpenBrackets.Pop();
                    continue;
                }
            }
        }
        
    }
}