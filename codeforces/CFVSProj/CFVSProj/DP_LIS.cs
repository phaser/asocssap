using System;
using System.Collections.Generic;
using System.Text;

class DP_LIS
{
    public int ComputeLongestIncreasingSubsequence(int[] nums)
    {
        int[] lis = new int[nums.Length];
        for (int i = 0; i < lis.Length; i++)
        {
            lis[i] = 1;
        }
        int max = 1;
        for (int i = 1; i < lis.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[i] >= nums[j])
                {
                    if (lis[i] < lis[j] + 1)
                    {
                        lis[i] = lis[j] + 1;
                        if (lis[i] > max)
                        {
                            max = lis[i];
                        }
                    }
                }
            }
        }

        return max;
    }
}

namespace CodeForces
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test_DP_LIS
    {
        [TestMethod]
        public void Test1()
        {
            var dplis = new DP_LIS();
            int lis = dplis.ComputeLongestIncreasingSubsequence(new int[] { 53, 43, 1, 20, 55, 56, 2, 3, 4, 5});
            Assert.AreEqual(5, lis);
        }
    }
}
