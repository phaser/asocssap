using System;
using System.Collections.Generic;
using System.Text;

class CF_600C
{
    public string solve(string s)
    {
        int[] numLetters = new int[26];
        foreach (var c in s)
        {
            numLetters[c - 'a']++;
        }
        while (GetOddNumLetters(numLetters) > 1)
        {
            for (int i = numLetters.Length - 1; i >= 0; i--)
            {
                if (numLetters[i] % 2 != 0)
                {
                    for (int k = 0; k < numLetters.Length; k++)
                    {
                        if (numLetters[k] % 2 != 0)
                        {
                            numLetters[k] += numLetters[i];
                            numLetters[i] = 0;
                            break;
                        }
                    }
                    break;
                }
            }
        }

        return "";
    }

    public int GetOddNumLetters(int[] numLetters)
    {
        int res = 0;
        for (int i = 0; i < numLetters.Length; i++)
        {
            if (numLetters[i] % 2 != 0)
            {
                res++;
            }
        }
        return res;
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test_CF_600C
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual("abba", new CF_600C().solve("aabc"));
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual("abcba", new CF_600C().solve("aabcd"));
        }
    }
}
#endif