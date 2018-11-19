using System.Collections.Generic;
using System.Linq;

namespace DEV_4
{
    /// <summary>
    /// class ArgumentSorter
    /// Sort list of string by arguments.
    /// </summary>
    public class ArgumentSorter
    {
        private List<string> ReceivedString { get; set; }

        public ArgumentSorter(List<string> receivedList)
        {
            ReceivedString = receivedList;
        }
        
        // Sort using LINQ query.
        public List<string> Sort()
        {
            var sortedList = ReceivedString.OrderBy(x => x).ToList();
            return sortedList;
        }
    }
}