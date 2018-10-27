using System;
using System.Collections.Generic;
using System.Text;

namespace DEV_4
{
    public class ReadyArgument
    {
        public void CreateArgument(StringBuilder addString, Stack<string> StackWithTags, List<String> parsedResult)
        {
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
        }
    }
}