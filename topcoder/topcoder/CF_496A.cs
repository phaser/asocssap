using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CF_496A
{
    static int Main(string[] args)
    {
        return 0;
    }

    public int solve(int[] holds)
    {
        int[] diffs = new int[holds.Length];
        int pn = 0;
        for (int i = 0; i < holds.Length; i++)
        {
            diffs[i] = holds[i] - pn;
            pn = holds[i];
        }

        return 0;
    }
}

namespace CodeForces
{
    using NUnit.Framework;

    [TestFixture]
    class Test_CF_496A
    {
        [Test]
        void Test1()
        {
            int[] nums = { 1, 4, 6 };
            Assert.AreEqual(5, new CF_496A().solve(nums));
        }
    }
}