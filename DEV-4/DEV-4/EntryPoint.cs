using System;
using System.Collections.Generic;
using System.Text;

namespace DEV_4
{
    internal class EntryPoint
    {
        public static void Main(string[] args)
        {
            try
            {
                string xml = "<a>" +
                             "dssfds" +
                             "<b>" +
                             "adasd" +
                             "</b>" +
                             "das" +
                             "</a>";
                Stack<string> a= new Stack<string>();
                bool tagFlag =false;
                StringBuilder str = new StringBuilder();
                for (var i = 0; i < xml.Length; i++)
                {
                    if (i == '<' && tagFlag)
                    {
                        throw new Exception();
                    }

                    if (i == '<')
                    {
                        if (str.ToString() != String.Empty)
                        {
                            // ToDo
                            str.Clear();
                        }

                        if (xml[Array.IndexOf(xml.ToCharArray(), i) + 1] == '/')
                        {
                            a.Pop();
                        }

                        tagFlag = true;
                        continue;
                    }

                    if (i == '>')
                    {
                        if (!tagFlag)
                        {
                            throw new Exception();
                        }

                        tagFlag = false;
                        a.Push(str.ToString());
                        str.Clear();
                        continue;
                    }

                    str.Append(i);
                }
               

                foreach (var i in a.ToArray())
                {
                    Console.WriteLine(i);    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}