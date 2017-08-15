using System;

public class CF_535B
{
    public int solve(string num)
    {
        int result = 0;
        for (int i = 0; i < num.Length; i++)
        {
            if (num[i] == '7')
            {
                result |= (1 << i);
            }
        }
        return result + 1;
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using NUnit.Framework;

    [TestFixture]
    class Test_CF_535B
    {
        [Test]
        public void Test1()
        {
            string num = "4";
            Assert.AreEqual(1, new CF_535B().solve(num));
        }

        [Test]
        public void Test2()
        {
            string num = "7";
            Assert.AreEqual(2, new CF_535B().solve(num));
        }

        [Test]
        public void Test3()
        {
            string num = "77";
            Assert.AreEqual(6, new CF_535B().solve(num));
        }
    }
}
#endif