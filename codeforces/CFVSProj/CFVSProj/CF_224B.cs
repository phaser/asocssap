using System;
using System.Collections.Generic;

public class CF_224B
{
    public class Result
    {
        public int l, r;
    }

    public CF_224B.Result solve(int[] nums, int k)
    {
        CF_224B.Result result = new CF_224B.Result();
        result.l = -1; result.r = -1;
        int l = -1; int r = -1;
        Dictionary<int, int> numCounts = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (!numCounts.ContainsKey(nums[i])) numCounts.Add(nums[i], 0);
            numCounts[nums[i]]++;
            if (numCounts.Count == k)
            {
                r = i;
                break;
            }
        }
        if (r == -1)
        {
            return result;
        }

        while (++l <= r && numCounts.Count == k)
        {
            numCounts[nums[l]]--;
            if (numCounts[nums[l]] == 0)
            {
                numCounts.Remove(nums[l]);
            }
        }
        result.l = l;
        result.r = r + 1;
        return result;
    }

	static void Main(string[] args)
	{
		string[] lines = Console.ReadLine().Split();
        int n = Convert.ToInt32(lines[0]);
        int k = Convert.ToInt32(lines[1]);
        lines = Console.ReadLine().Split();
        int[] nums = new int[n];
        for (int i = 0; i < n; i++)
        {
            nums[i] = Convert.ToInt32(lines[i]);
        }
        var ans = new CF_224B().solve(nums, k);
        Console.WriteLine(ans.l + " " + ans.r);
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using System.IO;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test_CF_224B
    {
        [TestMethod]
        public void Test1()
        {
            var ans = new CF_224B().solve(new int[] { 1, 2, 2, 3 }, 2);
            Assert.AreEqual(1, ans.l);
            Assert.AreEqual(2, ans.r);
        }

        [TestMethod]
        public void Test2()
        {
            var ans = new CF_224B().solve(new int[] { 1, 1, 2, 2, 3, 3, 4, 5 }, 3);
            Assert.AreEqual(2, ans.l);
            Assert.AreEqual(5, ans.r);
        }

        [TestMethod]
        public void Test3()
        {
            var ans = new CF_224B().solve(new int[] { 4, 7, 7, 4, 7, 4, 7 }, 4);
            Assert.AreEqual(-1, ans.l);
            Assert.AreEqual(-1, ans.r);
        }

        [TestMethod]
        public void Test4()
        {
            var ans = new CF_224B().solve(new int[] { 1 }, 1);
			Assert.AreEqual(1, ans.l);
			Assert.AreEqual(1, ans.r);
		}
    }
}
#endif