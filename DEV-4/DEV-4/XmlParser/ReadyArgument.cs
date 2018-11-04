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
        private Stack<string> StackWithTags;
        private List<string> ParsedResult;
        private FlagsOfTheState flagsOfTheState;
        
        /// <param name="stackWithTags">Stack with the corresponding tags.</param>
        /// <param name="parsedResult">List with parsed arguments.</param>
        /// <param name="flagsOfTheState">The current state of the parser.</param>
        public ReadyArgument(Stack<string> stackWithTags, List<string> parsedResult, FlagsOfTheState flagsOfTheState)
        {
            StackWithTags = stackWithTags;
            ParsedResult = parsedResult;
            this.flagsOfTheState = flagsOfTheState;
        }
        
        /// <summary>
        /// Method CreateArgument.
        /// Takes an argument and stack with the corresponding tags and generates a result.
        /// </summary>
        /// <param name="addString">New argument.</param>
        public void CreateArgument(string addString)
        {
            if (addString != string.Empty)
            {
                var parsedArgument = new StringBuilder();
                var tagSetForArgument = StackWithTags.ToArray();
                for (var j = tagSetForArgument.Length - 1; j >= 0; --j)
                {
                    parsedArgument.Append($"{tagSetForArgument[j]} -> ");
                }

                parsedArgument.Append(addString);
                ParsedResult.Add(parsedArgument.ToString());
                addString = string.Empty;
            }
            
            // Note that the parser has finished processing the argument.
            flagsOfTheState.ArgumentFlag = false;
        }
    }
}