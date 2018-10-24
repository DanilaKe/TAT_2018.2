using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEV_4
{
    public class XmlParser
    {
        private string XmlString { get; set; }

        public XmlParser(string receivedString)
        {
            XmlString = receivedString;
        }

        public List<string> Parsing()
        {
            var parsedResult = new List<string>(); 
            var tagFlag = false;
            var endTagFlag = false;
            var argumentFlag = false;

            var StackWithTags = new Stack<string>();
            var addString = new StringBuilder();
            for (var i = 0; i < XmlString.Length; i++)
            {
                if (((XmlString[i] == ' ') && (!tagFlag && !argumentFlag)) || (XmlString[i] == '\n'))
                {
                    continue;
                }

                if ((XmlString[i] == '<') && tagFlag)
                {
                    throw new Exception();
                }

                if (XmlString[i] == '<')
                {
                    argumentFlag = false;
                    if (addString.ToString() != String.Empty)
                    {
                        var parsedArgument = new StringBuilder();
                        var TagSetForArgument = StackWithTags.ToArray();
                        for (var j = TagSetForArgument.Length - 1; j >= 0; --j)
                        {
                            parsedArgument.Append($"{TagSetForArgument[j]} -> ");
                        }

                        parsedArgument.Append(addString.ToString());
                        parsedResult.Add(parsedArgument.ToString());
                        addString.Clear();
                    }

                    if (XmlString[i + 1] == '/')
                    {
                        i++;
                        endTagFlag = true;
                    }

                    tagFlag = true;
                    continue;
                }

                if (XmlString[i] == '>')
                {
                    if (!tagFlag)
                    {
                        throw new Exception();
                    }

                    if (endTagFlag)
                    {
                        var tagWithoutValues = new string(StackWithTags.Peek().TakeWhile(x => x != ' ').ToArray());
                        if (addString.ToString() != tagWithoutValues)
                        {
                            throw new Exception();
                        }

                        tagFlag = false;
                        endTagFlag = false;
                        StackWithTags.Pop();
                        addString.Clear();
                        continue;
                    }

                    tagFlag = false;
                    StackWithTags.Push(addString.ToString());
                    addString.Clear();
                    continue;
                }

                if (!tagFlag)
                {
                    argumentFlag = true;
                }

                addString.Append(XmlString[i]);
            }

            return parsedResult;
        }
    }
}

/*              Stack<string> a= new Stack<string>();
                bool tagFlag = false;
                bool endFlag = false;
                bool argumetFlag = false;
                StringBuilder str = new StringBuilder();
                for (var i = 0; i < xml.Length; i++)
                {
                    if ((xml[i] == ' ' && (!tagFlag && !argumetFlag))|| xml[i] == '\n')
                    {
                        continue;
                    }
                    if (xml[i] == '<' && tagFlag)
                    {
                        throw new Exception();
                    }

                    if (xml[i] == '<')
                    {
                        argumetFlag = false;
                        if (str.ToString() != String.Empty)
                        {
                            StringBuilder bu = new StringBuilder();
                            var Buffer = a.ToArray();
                            for (var j = Buffer.Length-1; j >= 0; --j)
                            {
                                bu.Append($"{Buffer[j]} -> ");
                            }

                            bu.Append(str);
                            Console.WriteLine(bu.ToString());
                            str.Clear();
                        }

                        if (xml[i+1] == '/')
                        {
                            i++;
                            endFlag = true;
                        }

                        tagFlag = true;
                        continue;
                    }

                    if (xml[i] == '>')
                    {
                        if (!tagFlag)
                        {
                            throw new Exception();
                        }

                        if (endFlag)
                        {
                            var k = str.ToString();
                            var s = new string(a.Peek().TakeWhile(x => x != ' ').ToArray());
                            if (s != k)
                            {
                                throw new Exception();
                            }

                            tagFlag = false;
                            endFlag = false;
                            a.Pop();
                            str.Clear();
                            continue;
                        }
                        tagFlag = false;
                        a.Push(str.ToString());
                        str.Clear();
                        continue;
                    }

                    if (!tagFlag)
                    {
                        argumetFlag = true;
                    }
                    str.Append(xml[i]);
                }
                foreach (var i in a.ToArray())
                {
                    Console.WriteLine(i);    
                }*/