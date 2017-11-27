using System;
using System.Collections.Generic;
using System.Text;

class CF_27A
{
    internal int solve(int[] v)
    {
        var existingMins = new HashSet<int>();
        int min = int.MaxValue;
        int max = int.MinValue;
        foreach (var n in v)
        {
            existingMins.Add(n);
            if (n > max)
            {
                max = n;
            }
        }
        for (int i = 1; i <= max + 1; i++)
        {
            if (!existingMins.Contains(i))
            {
                min = i;
                break;
            }
        }
        return min;
    }

    public static void Main(string[] args)
    {
        var n = Convert.ToInt32(Console.ReadLine());
        int[] v = new int[n];
        var lines = Console.ReadLine().Split();
        for (int i = 0; i < n; i++)
        {
            v[i] = Convert.ToInt32(lines[i]);
        }
        Console.WriteLine(new CF_27A().solve(v));
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test_CF_27A
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual(3, new CF_27A().solve(new int[] { 1, 7, 2 }));
            Assert.AreEqual(3, new CF_27A().solve(new int[] { 2, 7, 1 }));
            Assert.AreEqual(3, new CF_27A().solve(new int[] { 7, 1, 2 }));
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(1, new CF_27A().solve(new int[] { 6, 4, 3, 5 }));
        }
    }
}
#endif