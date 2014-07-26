using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PathSplit;

namespace PathSplitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SplitPathTest_1()
        {
            string path = @"org/proj/taxonomy/node";
            string[] names = Splitter.SplitPath(path);

            Assert.AreEqual(4, names.Length);
            Assert.AreEqual(names[0], "org");
            Assert.AreEqual(names[1], "proj");
            Assert.AreEqual(names[2], "taxonomy");
            Assert.AreEqual(names[3], "node");
        }

        [TestMethod]
        public void SplitPathTest_2()
        {
            string path = @"/org/proj/taxonomy/node";
            string[] names = Splitter.SplitPath(path);

            Assert.AreEqual(4, names.Length);
            Assert.AreEqual(names[0], "org");
            Assert.AreEqual(names[1], "proj");
            Assert.AreEqual(names[2], "taxonomy");
            Assert.AreEqual(names[3], "node");
        }

        [TestMethod]
        public void SplitPathTest_2_1()
        {
            string path = @"/org/proj/taxonomy/";
            string[] names = Splitter.SplitPath(path);

            Assert.AreEqual(3, names.Length);
            Assert.AreEqual(names[0], "org");
            Assert.AreEqual(names[1], "proj");
            Assert.AreEqual(names[2], "taxonomy");
        }

        [TestMethod]
        public void SplitPathTest_3()
        {
            string path = @"org/proj/taxonomy/node/";
            string[] names = Splitter.SplitPath(path);

            Assert.AreEqual(4, names.Length);
            Assert.AreEqual(names[0], "org");
            Assert.AreEqual(names[1], "proj");
            Assert.AreEqual(names[2], "taxonomy");
            Assert.AreEqual(names[3], "node");
        }

        [TestMethod]
        public void SplitPathTest_4()
        {
            string path = @"a\\/b";
            string[] names = Splitter.SplitPath(path);

            Assert.AreEqual(2, names.Length);
            Assert.AreEqual(names[0], @"a\");
            Assert.AreEqual(names[1], "b");
        }

        [TestMethod]
        public void SplitPathTest_5()
        {
            string path = @"a\/b";
            string[] names = Splitter.SplitPath(path);

            Assert.AreEqual(1, names.Length);
            Assert.AreEqual(names[0], "a/b");
        }


        [TestMethod]
        public void SplitPathTest_6()
        {
            string path = @"\\/b";
            string[] names = Splitter.SplitPath(path);

            Assert.AreEqual(2, names.Length);
            Assert.AreEqual(names[0], @"\");
            Assert.AreEqual(names[1], "b");
        }

        [TestMethod]
        public void SplitPathTest_7()
        {
            string path = @"a\\\\\/b";
            string[] names = Splitter.SplitPath(path);

            Assert.AreEqual(1, names.Length);
            Assert.AreEqual(names[0], @"a\\/b");
        }

        [TestMethod]
        public void SplitPathTest_8()
        {
            string path = @"a\//b/c\\";
            string[] names = Splitter.SplitPath(path);

            Assert.AreEqual(3, names.Length);
            Assert.AreEqual(names[0], @"a/");
            Assert.AreEqual(names[1], "b");
            Assert.AreEqual(names[2], @"c\");
        }

        [TestMethod]
        public void SplitPathTest_9()
        {
            string path = @"\\/\\\/";
            string[] names = Splitter.SplitPath(path);

            Assert.AreEqual(2, names.Length);
            Assert.AreEqual(names[0], @"\");
            Assert.AreEqual(names[1], @"\/");
        }

        [TestMethod]
        public void SplitPathTest_10()
        {
            string path = @"\\/\\/";
            string[] names = Splitter.SplitPath(path);

            Assert.AreEqual(2, names.Length);
            Assert.AreEqual(names[0], @"\");
            Assert.AreEqual(names[1], @"\");
        }

        [TestMethod]
        public void SplitPathTest_15()
        {
            string path = @"\\/\\\/";
            string[] names = Splitter.SplitPath(path);

            Assert.AreEqual(2, names.Length);
            Assert.AreEqual(names[0], @"\");
            Assert.AreEqual(names[1], @"\/");
        }

        [TestMethod]
        public void SplitPathTest_11()
        {
            string path = @"\\/";
            string[] names = Splitter.SplitPath(path);

            Assert.AreEqual(1, names.Length);
            Assert.AreEqual(names[0], @"\");
        }

        [TestMethod]
        public void SplitPathTest_12()
        {
            string path = @"\//";
            string[] names = Splitter.SplitPath(path);

            Assert.AreEqual(names[0], @"/");
        }

        [TestMethod]
        public void SplitPathTest_13()
        {
            string path = @"/\/";
            string[] names = Splitter.SplitPath(path);

            Assert.AreEqual(names[0], @"/");
        }

        [TestMethod]
        public void SplitPathTest_14()
        {
            string path = @"/\\";
            string[] names = Splitter.SplitPath(path);

            Assert.AreEqual(names[0], @"\");
        }

        [TestMethod]
        public void SplitPathTest_Repeat_01()
        {
            var sb = new StringBuilder();

            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 255; j++)
                {
                    sb.Append(@"a/");
                }
            }
            var namse = Splitter.SplitPath(sb.ToString());
            foreach (var name in namse)
            {
                Assert.AreEqual(name, "a");
            }

        }
    }
}
