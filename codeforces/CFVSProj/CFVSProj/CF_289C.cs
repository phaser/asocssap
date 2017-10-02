using System;

public class CF_289C
{
    public string solve(int n, int k)
    {
        if (k > n || (k == 1 && n > 1))
            return "-1";
        if (k == 1 && n == 1)
            return "a";
        char[] result = new char[n];
        for (int i = 0; i < (n - k + 2); i++)
        {
            result[i] = (i % 2 == 0 ? 'a' : 'b');
        }

        for (int i = (n - k + 2); i < n; i++)
        {
            result[i] = (char)((i - n + k - 2) + 'c');
        }
        return new string(result);
    }

    public static void Main(string[] args)
    {
        string[] lines = Console.ReadLine().Split();
        int n = Convert.ToInt32(lines[0]);
        int k = Convert.ToInt32(lines[1]);
        Console.WriteLine(new CF_289C().solve(n, k));
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class Test_CF_289C
	{
		[TestMethod]
		public void Test1()
		{
            Assert.AreEqual("ababacd", new CF_289C().solve(7, 4));
		}

		[TestMethod]
		public void Test2()
		{
            Assert.AreEqual("-1", new CF_289C().solve(4, 7));
		}
	}
}
#endif
