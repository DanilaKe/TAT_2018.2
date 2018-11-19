using System;

namespace DEV_4
{
    /// <summary>
    /// Abstract class AbstractTag
    /// Represents the implemented classes are tags.
    /// </summary>
    public abstract class AbstractTag
    {
        public string actualTag;
        public virtual void  Implement()
        {
            throw new NotImplementedException();
        }
    }
}