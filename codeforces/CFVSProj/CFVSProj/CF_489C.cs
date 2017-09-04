using System;

public class CF_489C
{
    public string solve(int m, int s)
    {
        if (s == 0)
        {
            if (m == 1)
            {
                return "0 0";
            }
            else
            {
                return "-1 -1";
            }
        }

        int md = s / m + (s % m == 0 ? 0 : 1);
        if (md > 9)
        {
            return "-1 -1";
        }
        int[] min = new int[m];
        int idx = m - 1; int sum = s;
        while (sum > 0)
        {
            min[idx] = sum >= 9 ? 9 : sum;
            sum -= min[idx];
            idx--;
        }
        string smax = "";
        for (int j = min.Length - 1; j >= 0; j--)
        {
            smax += min[j];
        }

        if (min[0] == 0)
        {
            min[0] = 1;
            min[idx + 1]--;
        }
        string smin = "";
        foreach (var d in min)
        {
            smin += d;
        }

        return "" + smin + " " + smax;
    }

#if ONLINE_JUDGE
    static int Main(string[] args)
    {
        string line = Console.ReadLine();
        string[] snums = line.Split();
        int m = Convert.ToInt32(snums[0]);
        int s = Convert.ToInt32(snums[1]);
        Console.WriteLine(new CF_489C().solve(m, s));
        return 0;
    }
#endif
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
	
    [TestClass]
    public class Test_CF_489C
    {
        [TestMethod]
        public void SpecialCase1()
        {
            Assert.AreEqual("0 0", new CF_489C().solve(1, 0));
        }

        [TestMethod]
        public void SpecialCase2()
        {
            Assert.AreEqual("-1 -1", new CF_489C().solve(2, 0));
            Assert.AreEqual("-1 -1", new CF_489C().solve(3, 0));
        }

        [TestMethod]
        public void NoSolution()
        {
            Assert.AreEqual("-1 -1", new CF_489C().solve(3, 29));
            Assert.AreEqual("-1 -1", new CF_489C().solve(2, 19));
        }

        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual("69 96", new CF_489C().solve(2, 15));
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual("18 90", new CF_489C().solve(2, 9));
        }

        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual("9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999 9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999", new CF_489C().solve(100, 900));
        }

        [TestMethod]
        public void FailedTest1()
        {
            Assert.AreEqual("899 998", new CF_489C().solve(3, 26));
        }
    }
}
#endif