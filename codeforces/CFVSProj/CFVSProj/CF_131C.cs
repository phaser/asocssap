using System;

public class CF_131C
{
    public long solve(long n, long m, long t)
    {
        return 0;
    }

    public long C(long n, long k)
    {
        long a = Math.Max(k, n - k);
        long b = Math.Min(k, n - k);
        return F(a + 1, n) / F(1, b);
    }

    public long F(long a, long b)
    {
        long ans = 1;
        for (long i = a; i <= b; i++)
        {
            ans *= i;
        }
        return ans;
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
        }
	}
}
#endif