using System.IO;

namespace DEV_4
{
    /// <summary>
    /// Class FileToStringConverter
    /// Convert file to string.
    /// </summary>
    public class FileToStringConverter
    {
        public string ReturnedString { get; private set; }

        public FileToStringConverter(string AddressToTheFile)
        {
            FileStream fileStream = File.OpenRead(AddressToTheFile);
            byte[] fileIntoArray = new byte[fileStream.Length];
            fileStream.Read(fileIntoArray, 0, fileIntoArray.Length);
            ReturnedString = System.Text.Encoding.Default.GetString(fileIntoArray);
        }
    }
}