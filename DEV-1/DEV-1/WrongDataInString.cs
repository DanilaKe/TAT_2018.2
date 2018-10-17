using System;

namespace DEV_1
{
    public class WrongDataInString : ApplicationException
    {
        public WrongDataInString() { }

        public WrongDataInString(string message) : base(message) { }
    }
}
