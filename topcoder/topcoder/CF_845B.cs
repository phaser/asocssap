using System;

public class CF_845A
{
	static int Main(string[] args)
	{
		string l = Console.ReadLine();
		Console.WriteLine(new CF_845A().solve(l));
		return 0;
	}

	public string solve(string t)
	{
		string t1 = t.Substring(0, 3);
		string t2 = t.Substring(3, 3);
		int s1 = t1[0] + t1[1] + t1[2];
		int s2 = t2[0] + t2[1] + t2[2];
		if (s1 == s2)
		{
			return "0";
		}
		int diff = Math.Abs(s1 - s2);
		char[] ct1 = t1.ToCharArray();
		char[] ct2 = t2.ToCharArray();
		Array.Sort(ct1);
		Array.Sort(ct2);
        if (  '9' - ct1[0] >= diff
           || '9' - ct2[0] >= diff
           || ct1[2] - '0' >= diff
           || ct2[2] - '0' >= diff)
		{
			return "1";
		}
		else
        if (('9' - ct1[0]) + ('9' - ct1[1]) >= diff
           || ('9' - ct2[0]) + ('9' - ct2[1]) >= diff
           || (ct1[2] + ct1[1] - 2 * '0') >= diff
           || (ct2[2] + ct2[1] - 2 * '0') >= diff)
		{
			return "2";
		}
		else
			return "3";
	}
}

#if !ONLINE_JUDGE
namespace CodeForces
{
	using NUnit.Framework;

	[TestFixture]
	class Test_CF_845A
    {
		[Test]
		public void Test1()
		{
            Assert.AreEqual("1", new CF_845A().solve("899888"));
            Assert.AreEqual("1", new CF_845A().solve("899889"));
            Assert.AreEqual("1", new CF_845A().solve("199880"));
            Assert.AreEqual("2", new CF_845A().solve("123456"));
		}
	}
}
#endif