using System.IO;

namespace DEV_4
{
    public class FileToStringConverter
    {
        public string ReturnedString { get; private set; }

        public FileToStringConverter(string AddressToTheFile)
        {
            FileStream fstream = File.OpenRead(AddressToTheFile);
            byte[] array = new byte[fstream.Length];
            fstream.Read(array, 0, array.Length);
            ReturnedString = System.Text.Encoding.Default.GetString(array);
        }
    }
}