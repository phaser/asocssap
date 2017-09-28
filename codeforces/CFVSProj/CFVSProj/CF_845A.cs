using System;
using System.Collections.Generic;

public class CF_845A
{
    static int Main(string[] args)
    {
        string l = Console.ReadLine();
        Console.WriteLine(new CF_845A().solve(l));
        return 0;
    }

    public int solve(string t)
    {
        if (IsItEqualSum(t.ToCharArray()))
            return 0;
        HashSet<int> visited = new HashSet<int>();
        char[] tc = t.ToCharArray();
        int diff = Math.Abs(Sum1(tc) - Sum2(tc));
        int c = 0;
        while (diff > 0)
        {
            int midx = 0;
            int min = diff;
            char mc = '0';
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    char aux = tc[i];
                    tc[i] = (char)(j + '0');
                    int cdiff = Math.Abs(Sum1(tc) - Sum2(tc));
                    if (cdiff < min)
                    {
                        min = cdiff;
                        midx = i;
                        mc = tc[i];
                    }
                    tc[i] = aux;
                }
            }
            tc[midx] = mc;
            diff = Math.Abs(Sum1(tc) - Sum2(tc));
            c++;
        }
        return c;
    }

    public bool IsItEqualSum(char[] t)
    {
        return t[0] + t[1] + t[2] == t[3] + t[4] + t[5];
    }

    public int Sum1(char[] t)
    {
        return (t[0] - '0') + (t[1] - '0') + (t[2] - '0');
    }

    public int Sum2(char[] t)
    {
        return (t[3] - '0') + (t[4] - '0') + (t[5] - '0');
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    class Test_CF_845A
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual("1", new CF_845A().solve("899888"));
            Assert.AreEqual("1", new CF_845A().solve("899889"));
            Assert.AreEqual("1", new CF_845A().solve("199880"));
            Assert.AreEqual("2", new CF_845A().solve("123456"));
            Assert.AreEqual("2", new CF_845A().solve("858022"));
        }
    }
}
#endif