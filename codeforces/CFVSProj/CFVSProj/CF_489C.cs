using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

public class CF_489C
{
    public string solve(int m, int s)
    {
        if (s == 0)
        {
            if (m == 1)
            {
                return "0 0";
            } else
            {
                return "-1 -1";
            }
        }

        int md = s / m + s % m;
        if (md > 9)
        {
            return "-1 -1";
        }


        return "";
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    [TestClass]
    public class Test_CF_489C
    {
        [TestMethod]
        public void SpecialCase1()
        {
            Assert.AreEqual("0 0", new CF_489C().solve(1, 0));
        }

        [TestMethod]
        public void SpecialCase2()
        {
            Assert.AreEqual("-1 -1", new CF_489C().solve(2, 0));
            Assert.AreEqual("-1 -1", new CF_489C().solve(3, 0));
        }

        [TestMethod]
        public void NoSolution()
        {
            Assert.AreEqual("-1 -1", new CF_489C().solve(3, 29));
            Assert.AreEqual("-1 -1", new CF_489C().solve(2, 19));
        }

        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual("69 69", new CF_489C().solve(2, 15));
        }
    }
}
#endif