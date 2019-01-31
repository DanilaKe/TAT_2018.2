using System.Collections.Generic;
using System.IO;

namespace DEV_6
{
    /// <summary>
    /// Class ResultToFileConverter
    /// Convert result to file.
    /// </summary>
    public class ResultToFileConverter
    {
        public string FileAddress { get; set; }

        public ResultToFileConverter(string fileAddress)
        {
            FileAddress = fileAddress;
        }
        
        public void Convert(List<string> result)
        {
            using(TextWriter textWriter = new StreamWriter(FileAddress))
            {
                foreach (var s in result)
                {
                    textWriter.WriteLine(s);
                }
            }
        }
    }
}