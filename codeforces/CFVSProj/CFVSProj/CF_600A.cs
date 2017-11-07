using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class CF_600A
{
    public string solve(string input)
    {
        string[] words = input.Split(new char[] { ',', ';'});
        StringBuilder sbNums = new StringBuilder();
        StringBuilder sbWords = new StringBuilder();
        foreach (var word in words)
        {
                var match = Regex.Match(word, "([1-9]+[0-9]*)|0");
            if (match.Success && match.Length == word.Length)
            {
                sbNums.Append(word); sbNums.Append(",");
            }
            else
            {
                sbWords.Append(word); sbWords.Append(",");
            }
        }
        if (sbNums.Length > 0)
        {
            sbNums.Remove(sbNums.Length - 1, 1);
            sbNums.Insert(0, "\""); sbNums.Append("\"");
        } else
        {
            sbNums.Append('-');
        }
        if (sbWords.Length > 0)
        {
            sbWords.Remove(sbWords.Length - 1, 1);
            sbWords.Insert(0, "\""); sbWords.Append("\"");
        } else
        {
            sbWords.Append('-');
        }
        string result = sbNums.ToString() + "\n" + sbWords.ToString();
        return result;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(new CF_600A().solve(Console.ReadLine()));
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test_CF_600A
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual("\"123,0\"\n\"aba,1a\"", new CF_600A().solve("aba,123;1a;0"));
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual("\"1\"\n\",01,a0,\"", new CF_600A().solve("1;;01,a0,"));
        }

        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual("\"1\"\n-", new CF_600A().solve("1"));
        }

        [TestMethod]
        public void Test4()
        {
            Assert.AreEqual("-\n\"a\"", new CF_600A().solve("a"));
        }

        [TestMethod]
        public void Test5()
        {
            Assert.AreEqual("-\n\",,\"", new CF_600A().solve(";;"));
        }
    }
}
#endif