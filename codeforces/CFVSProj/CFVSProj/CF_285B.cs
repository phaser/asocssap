using System;
 
public class CF_285B
{
    public int solve(int[] p, int s, int t)
    {
        s--; t--;
        for (int i = 0; i < p.Length; p[i]--, i++) { }
        int cp = s;
        int numelems = 0;
        while (numelems <= p.Length && (cp != t))
        {
            numelems++;
            cp = p[cp];
        }
        return (numelems <= p.Length ? numelems : -1);
    }

    static int Main(string[] args)
    {
        string[] lines = Console.ReadLine().Split();
        int n = Convert.ToInt32(lines[0]);
        int s = Convert.ToInt32(lines[1]);
        int t = Convert.ToInt32(lines[2]);
        lines = Console.ReadLine().Split();
        int[] p = new int[n];
        for (int i = 0; i < n; i++)
        {
            p[i] = Convert.ToInt32(lines[i]);
        }
        Console.WriteLine(new CF_285B().solve(p, s, t));
        return 0;
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test_CF_285B
    {
        [TestMethod]
        public void SpecialCase1()
        {
            Assert.AreEqual(3, new CF_285B().solve(new int[] {2, 3, 4, 1}, 2, 1));
        }

        [TestMethod]
        public void Test2()
        {
			Assert.AreEqual(0, new CF_285B().solve(new int[] { 4, 1, 3, 2 }, 3, 3));
		}

        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual(-1, new CF_285B().solve(new int[] {1, 2, 3, 4}, 3, 4));
        }
    }
}
#endif