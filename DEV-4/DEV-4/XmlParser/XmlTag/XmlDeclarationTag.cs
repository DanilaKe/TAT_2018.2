using System;

namespace DEV_4
{
    public class XmlDeclarationTag : IXmlTag
    {
        private FlagsOfTheState flagsOfTheState;
        private string tag;
        
        public XmlDeclarationTag(FlagsOfTheState flagsOfTheState, string tag)
        {
            this.flagsOfTheState = flagsOfTheState;
            this.tag = tag;
        }
        
        public void Implemet()
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