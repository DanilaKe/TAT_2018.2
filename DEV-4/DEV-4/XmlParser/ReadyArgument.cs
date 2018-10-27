using System;
using System.Collections.Generic;
using System.Text;

namespace DEV_4
{
    /// <summary>
    /// Class ReadyArgument
    /// The class that creates the finished parsed argument for the output
    /// and adds it to the parsed list.
    /// </summary>
    public class ReadyArgument
    {
        /// <summary>
        /// Method CreateArgument.
        /// Takes an argument and stack with the corresponding tags and generates a result.
        /// </summary>
        /// <param name="addString">New argument.</param>
        /// <param name="StackWithTags">Stack with the corresponding tags.</param>
        /// <param name="parsedResult">List with parsed arguments.</param>
        /// <param name="flagsOfTheState">The current state of the parser.</param>
        public void CreateArgument(StringBuilder addString, Stack<string> StackWithTags, List<string> parsedResult, ref FlagsOfTheState flagsOfTheState)
        {
            if (addString.ToString() != String.Empty)
            {
                var parsedArgument = new StringBuilder();
                var TagSetForArgument = StackWithTags.ToArray();
                for (var j = TagSetForArgument.Length - 1; j >= 0; --j)
                {
                    parsedArgument.Append($"{TagSetForArgument[j]} -> ");
                }

                parsedArgument.Append(addString);
                parsedResult.Add(parsedArgument.ToString());
                addString.Clear();
            }
            
            // Note that the parser has finished processing the argument.
            flagsOfTheState.ArgumentFlag = false;
        }
    }
}