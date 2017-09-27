using System;
using System.Collections.Generic;
using System.Text;

public class CF_854A
{
    public string solve(int sum)
    {
        var l = sum / 2;
        var ra = 0; var rb = 0;
        for (int i = 1; i <= l; i++)
        {
            var a = i; var b = sum - a;
            if (are_coprime(a, b))
            {
                ra = a; rb = b;
            }
        }
        return ra + " " + rb;
    }

    public static int gcd(int a, int b)
    {
        while (b != 0)
        {
            var t = a % b;
            a = b;
            b = t;
        }
        return a;
    }

    public static bool are_coprime(int a, int b)
    {
        if (((a | b) & 1) == 0)
            return false;
        return 1 == gcd(a, b);
    }

    public static void Main(string[] args)
    {
        int sum = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(new CF_854A().solve(sum));
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test_CF_854A
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual("1 2", new CF_854A().solve(3));
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual("1 3", new CF_854A().solve(4));
        }

        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual("5 7", new CF_854A().solve(12));
        }

        [TestMethod]
        public void Test4()
        {
            Assert.AreEqual("499 501", new CF_854A().solve(1000));
        }
    }
}
#endif