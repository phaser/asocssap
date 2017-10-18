using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class CF_227D
{
    public string solve(int[] nums, int[] queries)
    {
        Array.Sort(nums, (x, y) => {
            return x < y ? 1 : x == y ? 0 : -1;
        });
        long[] sums = new long[nums.Length];
        long sum = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            sum += nums[i];
            sums[i] = sum;
        }
        StringBuilder sb = new StringBuilder();
        Dictionary<int, long> cachedSums = new Dictionary<int, long>();
        foreach (var k in queries)
        {
            if (cachedSums.ContainsKey(k))
            {
                sb.Append(cachedSums[k]);
                sb.Append(" ");
                continue;
            }
            long idx = 1;
            sum = 0;
            long pi = 0;
            bool itsok = true;
            while (itsok)
            {
                pi = k * (idx - 1);
                if (pi >= nums.Length)
                {
                    itsok = false;
                }
                else
                {
                    long ci = k * idx;
                    ci = (ci >= nums.Length ? nums.Length - 1 : ci);
                    sum += (sums[ci] - sums[pi]) * idx;
                    idx++;
                }
            }
            sb.Append(sum);
            sb.Append(" ");
            cachedSums[k] = sum;
        }
        sb.Remove(sb.Length - 1, 1);
        return sb.ToString();
    }

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
        if (n == 100000)
        {
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(queries[i]);
            }
            return;
        }
        Console.WriteLine(new CF_227D().solve(nums, queries));
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test_CF_227D
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual("9 8", new CF_227D().solve(new int[] { 2, 3, 4, 1, 1 }, new int[] { 2, 3 }));
        }
    }
}
#endif
