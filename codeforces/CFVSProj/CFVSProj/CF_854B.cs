using System;
using System.Collections.Generic;
using System.Text;

class CF_854B
{
    public string solve(int n, int k)
    {
        int min = 0;
        int max = 0;
        if (k == n || k == 0)
        {
            min = 0; max = 0;
            return min + " " + max;
        }

        max = Math.Min(2 * k, n - k);
        min = 1;
        return min + " " + max;
    }

    public static void Main(string[] args)
    {
        string[] lines = Console.ReadLine().Split();
        int n = Convert.ToInt32(lines[0]);
        int k = Convert.ToInt32(lines[1]);
        Console.WriteLine(new CF_854B().solve(n, k));
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test_CF_854B
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual("1 3", new CF_854B().solve(6, 3));
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual("0 0", new CF_854B().solve(6, 6));
            Assert.AreEqual("0 0", new CF_854B().solve(6, 0));
        }

        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual("1 2", new CF_854B().solve(6, 1));
            Assert.AreEqual("1 4", new CF_854B().solve(6, 2));
            Assert.AreEqual("1 3", new CF_854B().solve(6, 3));
            Assert.AreEqual("1 2", new CF_854B().solve(6, 4));
            Assert.AreEqual("1 1", new CF_854B().solve(6, 5));
        }

        [TestMethod]
        public void Test4()
        {
        }
    }
}
#endif