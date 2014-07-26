using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PathSplit
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Split(@"a\\/b");
            Split(@"a\/b");
            Split(@"\\/b");
            Split(@"a\\\\\/b");
            Split(@"a\//b/c\\");
            Split(@"\/b/\\c");
            Split(@"a/b/");
            Split(@"\\/\\\/");
            Split(@"\\/\\/");
            Split(@"\\/");
            Split(@"\//");

            Repeat(@"\\/");
            Repeat(@"\\/");
            Repeat(@"a\/d/");
            Repeat(@"a\\d/");
            */

            string[] s =
            {
                @"a\\/b",@"a\/b",@"\\/b",@"\\/b",@"a\\\\\/b",@"a\//b/c\\",@"\/b/\\c",@"a/b/"
                ,@"\\/\\\/",@"\\/\\\/",@"\\/\\/",@"\\/",@"\//" ,"/org/proj/tax/sa\\\\/","/org/proj/tax/"
            };
            Split(s);

            Split(@"1,2,3\\,4", ',');
            Split(@"Node3?%>*:<>+#\/?\\?/?%>*:<>+#\/?\\");

            //string[] r = { @"\\/", @"\\/", @"a\/d/", @"a\\d/" };
            //Repeat(r);

            Console.ReadKey();
        }

        private static void Repeat(IEnumerable<string> repeatPart, int count = 255)
        {
            foreach (var str in repeatPart)
            {
                Repeat(str);
            }
        }

        private static void Repeat(string repeatPart, int count = 255)
        {
            var sb = new StringBuilder();
            count = count > 0 ? count : 255;
            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < count; j++)
                {
                    sb.Append(repeatPart);
                }
            }
            Split(sb.ToString());
        }

        private static void Split(IEnumerable<string> strs)
        {
            foreach (var str in strs)
            {
                Split(str);
            }
        }

        private static void Split(string nodePath, char splitChar = '/')
        {
            var sw = new Stopwatch();
            sw.Start();
            string[] names = Splitter.SplitPath(nodePath, splitChar);
            sw.Stop();

            if (nodePath.Length > 50)
            {
                Console.WriteLine(names[0]);
                Console.WriteLine("The string Length is {0}", nodePath.Length);
            }
            else
            {
                Console.WriteLine("Origin: {0}", nodePath);
                foreach (var name in names)
                {
                    Console.WriteLine(name);
                }
            }
            Console.WriteLine("Elapsed Milliseconds: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine("Elapsed: {0}", sw.Elapsed);
            Console.WriteLine();
            Console.WriteLine("**********************************");
            Console.WriteLine();
        }
    }
}
