using System;

public class CF_56B
{
    public string solve(int[] v)
    {
        int[] diff = new int[v.Length + 2];
        diff[1] = v[0];
        for (int i = 1; i < v.Length; i++)
        {
            diff[i + 1] = v[i] - v[i - 1];
        }
        diff[diff.Length - 1] = (v.Length + 1) - v[v.Length - 1];
        string result = "";
        int idx = 0;
        int cnt = 0;
        for (int i = 1; i < diff.Length; i++)
        {
            if (Math.Abs(diff[i]) != 1)
            {
                result += (i + idx) + " ";
                idx -= 1;
                cnt++;
            }
        }
        if (cnt == 2)
        {
            result = result.Substring(0, result.Length - 1);
        } else
        {
            result = "0 0";
        }
        return result;
    }

    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] v = new int[n];
        string[] lines = Console.ReadLine().Split();
        for (int i = 0; i < n; i++)
        {
            v[i] = Convert.ToInt32(lines[i]);
        }
        Console.WriteLine(new CF_56B().solve(v));
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test_CF_56B
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual("0 0", new CF_56B().solve(new int[] { 1, 2, 3, 4 }));
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual("2 6", new CF_56B().solve(new int[] { 1, 6, 5, 4, 3, 2, 7, 8 }));
        }

        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual("0 0", new CF_56B().solve(new int[] { 2, 3, 4, 1 }));
        }

        [TestMethod]
        public void Test4()
        {
            Assert.AreEqual("3 4", new CF_56B().solve(new int[] { 1, 2, 4, 3 }));
        }
    }
}
#endif