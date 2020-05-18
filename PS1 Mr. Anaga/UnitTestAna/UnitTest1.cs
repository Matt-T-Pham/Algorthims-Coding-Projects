using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anagram;
using Ran;

namespace UnitTestAna
{ 
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Ana a = new Ana();
            List<string> test = new List<string>() { "em", "me", "to" };
            int finalCount = a.anagrams(test);
            Assert.AreEqual(1, finalCount);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Ana a = new Ana();
            List<string> test = new List<string>() {"tape","rate","seat","pate","east","pest"};
            int finalCount = a.anagrams(test);
            Assert.AreEqual(2, finalCount);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Ana a = new Ana();
            Rando r = new Rando();
            int x = r.RandomNumLengthofArray(100);
            int y = r.RandomNumLengthofWords(10);
            int z = r.RandomNumOfAnagrams(40);

            int fin = x - z;
            int finalCount = a.anagrams(r.randomGen(x, y, z));
            Assert.AreEqual(finalCount, fin);
        }
        [TestMethod]
        public void TestMethod4()
        {
            Ana a = new Ana();
            Rando r = new Rando();
            int x = r.RandomNumLengthofArray(1000);
            int y = r.RandomNumLengthofWords(100);
            int z = r.RandomNumOfAnagrams(400);

            int fin = x - z;
            int finalCount = a.anagrams(r.randomGen(x, y, z));
            Assert.AreEqual(finalCount, fin);
        }
        [TestMethod]
        public void TestMetho5()
        {
            Ana a = new Ana();
            Rando r = new Rando();
            int x = r.RandomNumLengthofArray(10000);
            int y = r.RandomNumLengthofWords(1000);
            int z = r.RandomNumOfAnagrams(4000);

            int fin = x - z;
            int finalCount = a.anagrams(r.randomGen(x, y, z));
            Assert.AreEqual(finalCount, fin);
        }
        [TestMethod]
        public void TestMetho6()
        {
            Ana a = new Ana();
            Rando r = new Rando();
            int x = r.RandomNumLengthofArray(100000);
            int y = r.RandomNumLengthofWords(10000);
            int z = r.RandomNumOfAnagrams(40000);

            int fin = x - z;
            int finalCount = a.anagrams(r.randomGen(x, y, z));
            Assert.AreEqual(finalCount, fin);
        }
    }
}
