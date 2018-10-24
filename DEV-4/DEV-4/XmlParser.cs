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