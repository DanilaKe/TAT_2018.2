using System.Collections.Generic;
using System.Linq;

namespace DEV_4
{
    public class ArgumentSorter
    {
        private List<string> ReceivedString { get; set; }

        public ArgumentSorter(List<string> receivedList)
        {
            ReceivedString = receivedList;
        }

        public List<string> Sort()
        {
            var sortedList = ReceivedString.OrderBy(x => x).Select(x => x).ToList();
            return sortedList;
        }
    }
}