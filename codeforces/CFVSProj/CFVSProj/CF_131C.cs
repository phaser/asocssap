using System;

public class CF_131C
{
    public long solve(long n, long m, long t)
    {
        long b = Math.Min(n, t - 1);
        long tsum = 0;
        for (long i = 4; i <= b; i++)
        {
            tsum += GetBinCoeff(n, i) * GetBinCoeff(m, t - i);
        }
        return tsum;
    }

    static long GetBinCoeff(long N, long K)
    {
        // This function gets the total number of unique combinations based upon N and K.
        // N is the total number of items.
        // K is the size of the group.
        // Total number of unique combinations = N! / ( K! (N - K)! ).
        // This function is less efficient, but is more likely to not overflow when N and K are large.
        // Taken from:  http://blog.plover.com/math/choose.html
        //
        if (K > N) return 0;
        long r = 1;
        long d;
        for (d = 1; d <= K; d++)
        {
            r *= N--;
            r /= d;
        }
        return r;
    }

    static void Main(string[] args)
    {
        string[] snums = Console.ReadLine().Split();
        long n = Convert.ToInt64(snums[0]);
        long m = Convert.ToInt64(snums[1]);
        long t = Convert.ToInt64(snums[2]);
        Console.WriteLine(new CF_131C().solve(n, m, t));
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class Test_CF_131C
	{
		[TestMethod]
		public void Test1()
		{
            Assert.AreEqual(10, new CF_131C().solve(5, 2, 5));
		}

        [TestMethod]
        public void Test2()
        {
            long c = new CF_131C().C(5, 4);
            Assert.AreEqual(5, c);
            c = new CF_131C().C(5, 2);
            Assert.AreEqual(10, c);
            c = new CF_131C().C(1, 1);
            Assert.AreEqual(1, c);
        }

        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual(3, new CF_131C().solve(4, 3, 5));
        }

        [TestMethod]
        public void FailedTest1()
        {
            Assert.AreEqual(118264581548187697, new CF_131C().solve(30, 30, 30));
        }
    }
}
#endif