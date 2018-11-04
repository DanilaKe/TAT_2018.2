using System;

namespace DEV_4
{
    /// <summary>
    /// Class XmlDeclarationTag
    /// Tag with XML declaration. (<?xml ... ?>)
    /// </summary>
    public class XmlDeclarationTag : IXmlTag
    {
        private FlagsOfTheState flagsOfTheState;
        private string tag;
        
        public XmlDeclarationTag(FlagsOfTheState flagsOfTheState, string tag)
        {
            this.flagsOfTheState = flagsOfTheState;
            this.tag = tag;
        }
        
        public void Implement()
        {
            try
            {
                if (tag.ToLower().Contains("?xml"))
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