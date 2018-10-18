using System;

namespace DEV_1
{
    /// <summary>
    /// Exception WrongDataInString
    /// Thrown when the data is incorrect.
    /// </summary>
    public class WrongDataInString : ApplicationException
    {
        public WrongDataInString() { }

        public WrongDataInString(string message) : base(message) { }
    }
}
