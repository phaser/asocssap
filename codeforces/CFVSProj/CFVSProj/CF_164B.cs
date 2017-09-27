using System;
using System.Collections.Generic;

public class CF_164B
{
    public int solve(int[] a, HashSet<int> b)
    {
        int l = 0; int r = 0;
        int n = a.Length;
        while (l < n)
        {
            
            l++;
        }
        return 0;
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test_CF_164B
    {
        [TestMethod]
        public void Test1()
        {
            return;
            Assert.AreEqual(2, new CF_164B().solve(
                new int[] {1, 2, 3, 4, 5}
              , new HashSet<int>() { 1, 3, 5, 6}));
        }
    }
}
#endif