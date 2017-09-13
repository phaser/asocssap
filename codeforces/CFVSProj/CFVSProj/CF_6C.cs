using System;
using System.Collections.Generic;
using System.Text;

class Result
{
    public int aliceCount;
    public int bobCount;
}

class CF_6C
{
    public Result solve(int[] chocoTimes)
    {
        Result ans = new Result();
        int l = -1; int r = chocoTimes.Length;
        int t = 0;
        while (r > l + 1)
        {
            if (t <= 0)
            {
                t += chocoTimes[++l];
                ans.aliceCount++;
            }
            else
            if (t > 0)
            {
                t -= chocoTimes[--r];
                ans.bobCount++;
            }
        }

        return ans;
    }

    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] snums = Console.ReadLine().Split();
        int[] nums = new int[snums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = Convert.ToInt32(snums[i]);
        }
        var ans = new CF_6C().solve(nums);
        Console.WriteLine(ans.aliceCount + " " + ans.bobCount);
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using System.IO;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test_CF_6C
    {
        [TestMethod]
        public void Test1()
        {
            var ans = new CF_6C().solve(new int[] { 2, 9, 8, 2, 7 });
            Assert.AreEqual(2, ans.aliceCount);
            Assert.AreEqual(3, ans.bobCount);
        }

        [TestMethod]
        public void Test2()
        {
            var ans = new CF_6C().solve(new int[] { 1, 1, 1, 1, 1 });
            Assert.AreEqual(3, ans.aliceCount);
            Assert.AreEqual(2, ans.bobCount);
        }
    }
}
#endif