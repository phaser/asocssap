using System;

public class CF_169B
{
    public string solve(char[] num, char[] s)
    {
        Array.Sort(s);
        Array.Reverse(s);
        int j = 0;
        for (int i = 0; i < num.Length; i++)
        {
            if (num[i] < s[j])
            {
                num[i] = s[j];
                j++;
            }
            if (j >= s.Length)
            {
                break;
            }
        }
        return new string(num);
    }

    public static void Main()
    {
        string num = Console.ReadLine();
        string s = Console.ReadLine();
        Console.WriteLine(new CF_169B().solve(num.ToCharArray(), s.ToCharArray()));
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test_CF_169B
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual("1124", new CF_169B().solve("1024".ToCharArray(), "010".ToCharArray()));
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual("987", new CF_169B().solve("987".ToCharArray(), "1234567".ToCharArray()));
        }
    }
}
#endif
