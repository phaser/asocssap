using System;

public class CF_289B
{
    public int solve(int[] mat, int d)
    {
        Array.Sort(mat);
        int selMed = mat[mat.Length / 2];
        int count = 0;
        foreach (var me in mat)
        {
            var tmp = Math.Abs(selMed - me);
            count += tmp / d;
            if (tmp % d != 0)
                return -1;
        }
        return count;
    }

    public static void Main(string[] args)
    {
        string[] lines = Console.ReadLine().Split();
        int n = Convert.ToInt32(lines[0]);
        int m = Convert.ToInt32(lines[1]);
        int d = Convert.ToInt32(lines[2]);
        int[] mat = new int[n * m];
        for (int i = 0; i < n; i++)
        {
            lines = Console.ReadLine().Split();
            for (int j = 0; j < m; j++)
            {
                mat[i * m + j] = Convert.ToInt32(lines[j]);
            }
        }
        Console.WriteLine(new CF_289B().solve(mat, d));
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class Test_CF_289B
	{
		[TestMethod]
		public void Test1()
		{
            Assert.AreEqual(4, new CF_289B().solve(new int[4] {2, 4, 6, 8}, 2));
		}

		[TestMethod]
		public void Test2()
		{
            Assert.AreEqual(-1, new CF_289B().solve(new int[2]{ 6, 7 }, 7));
		}

        [TestMethod]
        public void Test3()
        {
            int[] v = new int[10001];
            int d = 2;
            for (int i = 0; i < v.Length; i++)
            {
                v[i] = d * i;
            }

            Assert.AreEqual(25005000, new CF_289B().solve(v, d));
        }
	}
}
#endif