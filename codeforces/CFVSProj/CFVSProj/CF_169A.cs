using System;
using System.Collections.Generic;
using System.Text;

public class CF_169A
{
    public int solve(int[] chores, int a, int b)
    {
        Array.Sort(chores);
        return chores[b] - chores[b-1];
    }

    public static void Main()
    {
        var lines = Console.ReadLine().Split();
        int n = Convert.ToInt32(lines[0]);
        int a = Convert.ToInt32(lines[1]);
        int b = Convert.ToInt32(lines[2]);
        int[] chores = new int[n];
        lines = Console.ReadLine().Split();
        for (int i = 0; i < n; i++)
        {
            chores[i] = Convert.ToInt32(lines[i]);
        }
        Console.WriteLine(new CF_169A().solve(chores, a, b));
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test_CF_169A
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual(3, new CF_169A().solve(new int[] { 6, 2, 3, 100, 1 }, 2, 3));
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(0, new CF_169A().solve(new int[] { 1, 1, 9, 1, 1, 1, 1 }, 3, 4));
        }
    }
}
#endif
