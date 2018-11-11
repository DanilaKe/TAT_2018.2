using System;

namespace DEV_6
{
    /// <summary>
    /// Class XmlDeclarationTag
    /// Tag with XML declaration. (<?xml ... ?>)
    /// </summary>
    public class XmlDeclarationTag : AbstractTag
    {
        private FlagsOfTheState flagsOfTheState;
       
        
        public XmlDeclarationTag(FlagsOfTheState flagsOfTheState, string tag)
        {
            this.flagsOfTheState = flagsOfTheState;
            this.actualTag = tag;
        }
        
        public sealed override void Implement()
        {
            try
            {
                if (actualTag.ToLower().Contains("?xml"))
                {
                    flagsOfTheState.XmlFlag = true;
                }
                else
                {
                    throw new Exception("This is not an XML file (there is no XML tag at the beginning)."); 
                }   
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }        
        }
    }
}