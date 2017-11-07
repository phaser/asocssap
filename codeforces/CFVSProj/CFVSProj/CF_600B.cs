using System;
using System.Collections.Generic;
using System.Text;

class CF_600B
{
    public string solve(int[] a, int[] b)
    {
        StringBuilder sb = new StringBuilder();
        Array.Sort(a);
        foreach (var ts in b)
        {
            int idx = Array.BinarySearch(a, ts);
            if (idx < 0)
            {
                sb.Append((~idx)); sb.Append(' ');
            }
            else
            {
                idx = Array.BinarySearch(a, ts + 1);
                if (idx < 0)
                {
                    sb.Append(~idx); sb.Append(' ');
                } else
                {
                    sb.Append(idx); sb.Append(' ');
                }
            }
        }
        sb.Remove(sb.Length - 1, 1);
        return sb.ToString();
    }

    public static void Main(string[] args)
    {
        string[] lines = Console.ReadLine().Split();
        int n = Convert.ToInt32(lines[0]); int m = Convert.ToInt32(lines[1]);
        int[] a = new int[n]; int[] b = new int[m];
        lines = Console.ReadLine().Split();
        for (int i = 0; i < n; i++)
        {
            a[i] = Convert.ToInt32(lines[i]);
        }
        lines = Console.ReadLine().Split();
        for (int i = 0; i < m; i++)
        {
            b[i] = Convert.ToInt32(lines[i]);
        }
        Console.WriteLine(new CF_600B().solve(a, b));
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test_CF_600B
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual("3 2 1 4", new CF_600B().solve(new int[] { 1, 3, 5, 7, 9 }, new int[] { 6, 4, 2, 8 }));
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual("4 2 4 2 5", new CF_600B().solve(new int[] { 1, 2, 1, 2, 5 }, new int[] { 3, 1, 4, 1, 5 }));
        }
    }
}
#endif