using System;

public class CF_842A
{
    public string solve(int l, int r, int a, int b, int k)
    {
        for (int j = a; j <= b; j++)
        {
            for (int i = l; i <= r; i++)
            {
                if (i % j == 0 && i / j == k)
                {
                    return "YES";
                }
            }
        }
        return "NO";
    }

    static void Main(string[] args)
    {
        string[] lines = Console.ReadLine().Split();
        int l = Convert.ToInt32(lines[0]);
        int r = Convert.ToInt32(lines[1]);
        int a = Convert.ToInt32(lines[2]);
        int b = Convert.ToInt32(lines[3]);
        int k = Convert.ToInt32(lines[4]);
        Console.WriteLine(new CF_842A().solve(l, r, a, b, k));
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using System.IO;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test_CF_842A
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual("YES", new CF_842A().solve(1, 10, 1, 10, 1));
        }

        [TestMethod]
		public void Test2()
		{
			Assert.AreEqual("NO", new CF_842A().solve(1, 5, 6, 10, 1));
		}
	}
}
#endif
