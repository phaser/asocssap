using System;

public class CF_859C
{
    public string solve(int[] pies)
    {
        long max = 1;
        for (int i = 0; i < (pies.Length - 1); i++)
        {
            max = (max << 1) + 1;
        }

        int minDiff = int.MaxValue;
        int bob = 0;
        int alice = 0;
        int si = 0;
        for (int i = 0; i <= max; i++)
        {
            int cb = 0; int ca = 0;
            for (int k = 0; k < (pies.Length); k++)
            {
                if ((i & (1 << k)) != 0)
                {
                    ca += pies[k];
                }
                else
                {
                    cb += pies[k];
                }
            }
            int diff = Math.Abs(cb - ca);
            if (diff < minDiff)
            {
                bob = cb; alice = ca; minDiff = diff; si = i;
            }
        }
        if (alice > bob)
        {
            return bob + " " + alice;
        }
        return alice + " " + bob;
    }

	static void Main(string[] args)
	{
        int n = Convert.ToInt32(Console.ReadLine());
		string[] lines = Console.ReadLine().Split();
        int[] pies = new int[n];
        for (int i = 0; i < n; i++)
        {
            pies[i] = Convert.ToInt32(lines[i]);
        }
        Console.WriteLine(new CF_859C().solve(pies));
	}
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test_CF_859C
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual("653 733", new CF_859C().solve(new int[] {141, 592, 653 }));
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual("31 41", new CF_859C().solve(new int[] {10, 21, 10, 21, 10}));
        }

        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual("0 0", new CF_859C().solve(new int[] {
                1, 1, 1, 1, 1, 3, 3, 3, 3, 3,
                2, 2, 2, 2, 2, 1, 1, 1, 1, 1,
                1, 1, 1, 1, 1, 4, 4, 4, 4, 4,
                5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
                1, 2, 3, 7, 7, 7, 7, 7, 7, 7,
                7, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                1, 4, 1, 1, 1, 1, 1, 1, 1, 1}));
        }
    }
}
#endif
