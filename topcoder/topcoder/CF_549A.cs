using System;
public class CF_549A
{
    static int Main(string[] args)
    {
        string nums = Console.ReadLine();
        int nl = Convert.ToInt32(nums.Split()[0]);
        string[] lines = new string[nl];
        for (int i = 0; i < nl; i++)
        {
            lines[i] = Console.ReadLine();
        }
        Console.WriteLine(new CF_549A().solve(lines));
        return 0;    
    }

	public int solve(string[] lines)
	{
		int count = 0;
		int[] lc = new int[4];
		for (int i = 0; i < lines.Length - 1; i++)
		{
			for (int j = 1; j < lines[i].Length; j++)
			{
                lc[0] = 0; lc[1] = 0; lc[2] = 0; lc[3] = 0;
				adjustCount(lines[i][j], lc);
				adjustCount(lines[i][j-1], lc);
				adjustCount(lines[i+1][j], lc);
				adjustCount(lines[i+1][j-1], lc);
                if (lc[0] == 1 && lc[1] == 1 && lc[2] == 1 && lc[3] == 1)
                {
					count++;
				}
			}
		}
		return count;
	}

    private void adjustCount(char v, int[] lc)
    {
        switch (v)
        {
            case ('f'): { lc[0]++; break; }
            case ('a'): { lc[1]++; break; }
            case ('c'): { lc[2]++; break; }
            case ('e'): { lc[3]++; break; }
        }
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using NUnit.Framework;

    [TestFixture]
    class Test_CF_549A
    {
        [Test]
        public void Test1()
        {
            string[] lines = {
                "xxxx",
                "xfax",
                "xcex",
                "xxxx"
            };

            Assert.AreEqual(1, new CF_549A().solve(lines));
        }

        [Test]
        public void Test2()
        {
            string[] lines = {
                "xx",
                "cf",
                "ae",
                "xx"
            };
            Assert.AreEqual(1, new CF_549A().solve(lines));
        }

        [Test]
        public void Test3()
        {
            string[] lines = {
				"fac",
                "cef"
            };
            Assert.AreEqual(2, new CF_549A().solve(lines));
        }

        [Test]
        public void Test4()
        {
            string[] lines = { "face" };
            Assert.AreEqual(0, new CF_549A().solve(lines));
        }
    }
}
#endif