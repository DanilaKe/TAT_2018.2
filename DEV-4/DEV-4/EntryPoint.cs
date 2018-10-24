using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DEV_4
{
    internal class EntryPoint
    {
        public static void Main(string[] args)
        {
            try
            {
                string xml;
                using (FileStream fstream = File.OpenRead("./DEV-4/Test.xml"))
                {
                    byte[] array = new byte[fstream.Length];
                    fstream.Read(array, 0, array.Length);
                    xml = System.Text.Encoding.Default.GetString(array);
                }
                Stack<string> a= new Stack<string>();
                bool tagFlag = false;
                bool endFlag = false;
                bool argumetFlag = false;
                StringBuilder str = new StringBuilder();
                for (var i = 0; i < xml.Length; i++)
                {
                    if ((xml[i] == ' ' && (!tagFlag && !argumetFlag))|| xml[i] == '\n')
                    {
                        continue;
                    }
                    if (xml[i] == '<' && tagFlag)
                    {
                        throw new Exception();
                    }

                    if (xml[i] == '<')
                    {
                        argumetFlag = false;
                        if (str.ToString() != String.Empty)
                        {
                            StringBuilder bu = new StringBuilder();
                            var Buffer = a.ToArray();
                            for (var j = Buffer.Length-1; j >= 0; --j)
                            {
                                bu.Append($"{Buffer[j]} -> ");
                            }

                            bu.Append(str);
                            Console.WriteLine(bu.ToString());
                            str.Clear();
                        }

                        if (xml[i+1] == '/')
                        {
                            i++;
                            endFlag = true;
                        }

                        tagFlag = true;
                        continue;
                    }

                    if (xml[i] == '>')
                    {
                        if (!tagFlag)
                        {
                            throw new Exception();
                        }

                        if (endFlag)
                        {
                            var k = str.ToString();
                            var s = new string(a.Peek().TakeWhile(x => x != ' ').ToArray());
                            if (s != k)
                            {
                                throw new Exception();
                            }

                            tagFlag = false;
                            endFlag = false;
                            a.Pop();
                            str.Clear();
                            continue;
                        }
                        tagFlag = false;
                        a.Push(str.ToString());
                        str.Clear();
                        continue;
                    }

                    if (!tagFlag)
                    {
                        argumetFlag = true;
                    }
                    str.Append(xml[i]);
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