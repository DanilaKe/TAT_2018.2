using System;
using System.Collections.Generic;
using System.Text;

namespace DEV_6
{
    /// <summary>
    /// Class JsonParser
    /// Parsing a Json string in a XML string.
    /// </summary>
    public class JsonParser : Parser
    {
        private Stack<char> OpenBrackets;
        private Stack<string> OpenObject;
        private int objectCount;
        private int arrayCount;
        
        private bool stringFlag;
        private bool argFlag;
        private bool arrayFlag;
        private StringBuilder parsingElement;
        private JsonParserResult Result;

        public JsonParser(string fileAddress) : base(fileAddress)
        {
            OpenBrackets = new Stack<char>();
            OpenObject = new Stack<string>();
            parsingElement = new StringBuilder();
            Result = new JsonParserResult(OpenObject);
        }
        
        /// <summary>
        /// Method Parse
        /// Gets the address of the Json file and starts ParseJsonFile method.
        /// </summary> 
        /// <returns>Parsed list of strings.</returns>
        public override List<string> Parse()
        {
            FileToStringConverter jsonConverter = new FileToStringConverter();
            string json = jsonConverter.Convert(FileAddress);
            
            ParseJsonFile(json);
            return Result.XmlResult;
        }
        
        /// <summary>
        /// Method ParseJsonFile
        /// Parsing a string, if the Json string is compiled
        /// correctly, returns the result of the parsing.
        /// </summary>
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
                    parseJsonString(JsonString[i]);
                    
                    continue;
                }
                
                
                if (stringFlag || argFlag)
                {
                    parsingElement.Append(JsonString[i]);
                }

                if (JsonString[i] == ':' && !stringFlag)
                {
                    if (JsonString[i+1] == '{' || JsonString[i+2] == '{' ||
                        JsonString[i+1] == '[' || JsonString[i+2] == '[' )
                    {
                        continue;
                    }

                    argFlag = true;
                    Result.OpenTag();
                    continue;
                }

                if (JsonString[i] == ',' && !stringFlag)
                {
                    if (parsingElement.ToString() != string.Empty)
                    {
                        parsingElement.Replace(',', '\0');
                        parsingElement.Replace('}', '\0');
                        parsingElement.Replace(']', '\0');
                        
                        CreateArgument();
                    }
                    continue;
                }
                 
                if (JsonString[i] == '{' && !stringFlag && !arrayFlag)
                {
                    OpenBrackets.Push(JsonString[i]);
                    Result.OpenTag();
                    objectCount++;
                    continue;
                }

                if (JsonString[i] == '[' && !stringFlag)
                {
                    arrayFlag = true;
                    OpenBrackets.Push(JsonString[i]);
                    Result.OpenTag();
                    arrayCount++;
                    continue;
                }
                              
                if (JsonString[i] == '}' && !stringFlag && !arrayFlag)
                {
                    if ((objectCount < 1) || (OpenBrackets.Peek() != '{'))
                    {
                        throw new Exception();
                    }
          
                    objectCount--;
                    
                    Result.CloseTag();
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
                    arrayCount--;

                    Result.CloseTag();
                    OpenBrackets.Pop();
                    continue;
                }
            }

            if (OpenBrackets.Count > 0)
            {
                throw new Exception();
            }
        }
        
        
        /// <summary>
        /// Method parseJsonString
        /// Implements the logic associated with JSON string.
        /// </summary>
        void parseJsonString(char separator)
        {
            if (stringFlag)
            {
                if (OpenBrackets.Peek() != separator)
                {
                    throw new Exception();
                }
                        
                stringFlag = false;
                OpenBrackets.Pop();        
                CreateArgument();
            }
            else
            {
                OpenBrackets.Push(separator);
                stringFlag = true;
            }
        }
        
        /// <summary>
        /// Method CreateArgument
        /// Implements the logic associated with JSON argument.
        /// </summary>
        void CreateArgument()
        {
            OpenObject.Push(parsingElement.ToString());
            parsingElement.Clear();
            if (argFlag)
            {
                argFlag = false;
                Result.CreateArg();
                Result.CloseTag();
            }
        }
    }
}