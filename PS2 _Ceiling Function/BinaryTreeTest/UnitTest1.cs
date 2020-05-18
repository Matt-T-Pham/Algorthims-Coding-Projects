using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Binary_Tree;

namespace BinaryTreeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Tree Test = new Tree();
            int[] Addenumber = new int[] { 1, 2, 3, 4, 5, 6, };
            Test.StartAdd(Addenumber);

        }
        [TestMethod]
        public void TestMethod2()
        {
            Tree Test = new Tree();
            Tree Test2 = new Tree();
            int[] Addenumber = new int[] { 1,2,3,4,5,6};
            int[] AddenNumber2 = new int[] { 2,3,4,5,6,7};
            Test.StartAdd(Addenumber);
            Test2.StartAdd(AddenNumber2);

            Assert.AreEqual(Test.Compare(Test.roots, Test2.roots),true);         

        }
        [TestMethod]
        public void TestMethod3()
        {
            Tree Test = new Tree();
            Tree Test2 = new Tree();
            int[] Addenumber = new int[] { 2,7,1};
            int[] AddenNumber2 = new int[] {3,1,4 };
            Test.StartAdd(Addenumber);
            Test2.StartAdd(AddenNumber2);

            Assert.AreEqual(Test.Compare(Test.roots, Test2.roots), true);

        }
        [TestMethod]
        public void TestMethod4()
        {
            Tree Test = new Tree();
            Tree Test2 = new Tree();
            int[] Addenumber = new int[] { 1,5,9};
            int[] AddenNumber2 = new int[] { 2,6,5 };
            Test.StartAdd(Addenumber);
            Test2.StartAdd(AddenNumber2);
            Assert.AreEqual(Test.Compare(Test.roots, Test2.roots), false);

        }
    }
}
