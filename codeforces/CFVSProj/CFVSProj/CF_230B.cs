using System;

public class CF_230B
{
    public string solve(UInt64[] nums)
    {
        return "";
    }

    static int Main(string[] args)
    {
        string line = Console.ReadLine();
        int n = Convert.ToInt32(line);
        UInt64[] nums = new UInt64[n];
        line = Console.ReadLine();
        string[] snums = line.Split();
        for (int i = 0; i < n; i++)
        {
            nums[i] = Convert.ToUInt64(snums[i]);
        }
        Console.WriteLine(new CF_230B().solve(nums));
        return 0;
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
	
    [TestClass]
    public class Test_CF_230B
    {
        [TestMethod]
        public void Test1()
        {
            UInt64[] nums = new UInt64[] { 4, 5, 6 };
            Assert.AreEqual("YES\nNO\nNO\n", new CF_230B().solve(nums));
        }
    }
}
#endif