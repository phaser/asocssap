using System;
using System.Collections.Generic;
using System.Text;

class CF_556B
{
    internal string solve(int[] v)
    {
        if (CheckIfStolp(v))
            return "Yes";

        for (int j = 0; j < v.Length; j++)
        {
            for (int i = 0; i < v.Length; i++)
            {
                if (i % 2 == 0)
                {
                    v[i] = (++v[i]) % v.Length;
                }
                else
                {
                    v[i] = (--v[i]); v[i] = (v[i] < 0 ? v.Length + v[i] : v[i]);
                }
            }

            if (CheckIfStolp(v))
            {
                return "Yes";
            }
        }
        return "No";
    }

    private bool CheckIfStolp(int[] v)
    {
        bool fine = true;
        for (int i = 0; i < v.Length; i++)
        {
            if (v[i] != i)
            {
                fine = false;
                break;
            }
        }
        return fine;
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
        Console.WriteLine(new CF_556B().solve(nums));
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test_CF_556B
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual("Yes", new CF_556B().solve(new int[] { 1, 0, 0 }));
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual("Yes", new CF_556B().solve(new int[] { 4, 2, 1, 4, 3 }));
        }

        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual("No", new CF_556B().solve(new int[] { 0, 2, 3, 1 }));
        }
    }
}
#endif