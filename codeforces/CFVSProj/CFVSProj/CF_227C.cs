using System;
using System.Collections.Generic;
using System.Text;

class CF_227C
{
    public long solve(long n, long m)
    {
        long[] powerof3 = new long[32];
        long k = 1;
        long power = 3 % m;
        for (int i = 0; i < 32; i++)
        {
            for (int pm = (int)Math.Pow(2, i); pm < (int)Math.Pow(2, i + 1); pm++)
            {
                k = (k * power) % m;
            }
            powerof3[i] = k; 
        }

        k = 1;
        for (int i = 0; i < 32; i++)
        {
            if ((n & (1 << i)) != 0)
            {
                k *= powerof3[i]; k %= m;
            }
        }
        return k - 1;
    }

    public static void Main(string[] args)
    {
        string[] lines = Console.ReadLine().Split();
        long n = Convert.ToInt64(lines[0]);
        long m = Convert.ToInt64(lines[1]);
        Console.WriteLine(new CF_227C().solve(n, m));
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test_CF_227C
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual(2, new CF_227C().solve(1, 10));
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(2, new CF_227C().solve(3, 8));
        }

        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual(80, new CF_227C().solve(4, 84));
        }
    }
}
#endif
