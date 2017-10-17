using System;
using System.Collections.Generic;
using System.Text;

public class CF_227D
{
    public string solve(int[] nums, int[] queries)
    {
        Array.Sort(nums);
        return "";
    }

    public static void Main(string[] args)
    {
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test_CF_227D
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual("9 8", new CF_227D().solve(new int[] { 2, 3, 4, 1, 1 }, new int[] { 2, 3 }));
        }
    }
}
#endif
