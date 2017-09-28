using System;

public class Segment
{
    public int l, r;
    public Segment(int l, int r)
    {
        this.l = l; this.r = r;
    }
    public int size()
    {
        return (r - l + 1);
    }
}

public class CF_289A
{
    public long solve(Segment[] segments, int k)
    {
        long sum = 0;
        foreach (var s in segments) { sum += s.size(); }
        return (k - (sum % k)) % k;
    }

    public static void Main(string[] args)
    {
        string[] lines = Console.ReadLine().Split();
        int n = Convert.ToInt32(lines[0]);
        int k = Convert.ToInt32(lines[1]);
        Segment[] segments = new Segment[n];
        for (int i = 0; i < n; i++)
        {
            lines = Console.ReadLine().Split();
            segments[i] = new Segment(Convert.ToInt32(lines[0]), Convert.ToInt32(lines[1]));
        }
        Console.WriteLine(new CF_289A().solve(segments, k));
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class Test_CF_289A
	{
		[TestMethod]
		public void Test1()
		{
            Assert.AreEqual(2, new CF_289A().solve(new Segment[2] { new Segment(1, 2), new Segment(3, 4) }, 3));
		}

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(0, new CF_289A().solve(new Segment[3] {
                new Segment(1, 2),
                new Segment(3, 3),
                new Segment(4, 7)
            }, 7));
        }
	}
}
#endif