using System;
using System.Collections.Generic;
using System.Text;

public class CF_227B
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] nums = new int[n];
        string[] lines = Console.ReadLine().Split();
        for (int i = 0; i < n; i++)
        {
            nums[i] = Convert.ToInt32(lines[i]);
        }
        int m = Convert.ToInt32(Console.ReadLine());
        int[] queries = new int[m];
        lines = Console.ReadLine().Split();
        for (int i = 0; i < m; i++)
        {
            queries[i] = Convert.ToInt32(lines[i]);
        }
        Console.WriteLine(new CF_227B().solve(nums, queries));
    }

    public string solve(int[] nums, int[] queries)
    {
        Dictionary<int, int> fmqueries = new Dictionary<int, int>();
        Dictionary<int, int> smqueries = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (!fmqueries.ContainsKey(nums[i]))
            {
                fmqueries[nums[i]] = i + 1;
            }
        }

        for (int i = nums.Length - 1; i >= 0; i--)
        {
            if (!smqueries.ContainsKey(nums[i]))
            {
                smqueries[nums[i]] = nums.Length - i;
            }
        }

        long sum1 = 0; long sum2 = 0;
        for (int i = 0; i < queries.Length; i++)
        {
            sum1 += fmqueries[queries[i]];
            sum2 += smqueries[queries[i]];
        }
        return sum1 + " " + sum2;
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test_CF_227B
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual("6 6", new CF_227B().solve(new int[] { 3, 1, 2 }, new int[] { 1, 2, 3 }));
        }
    }
}
#endif
