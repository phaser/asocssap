using System;
using System.Collections.Generic;
using System.Text;

class CF_227C
{
    public long[] powersOf3 = new long[]
    {
          3
        , 9
        , 27
        , 81
        , 243
        , 729
        , 2187
        , 6561
        , 19683
        , 59049
        , 177147
        , 531441
        , 1594323
        , 4782969
        , 14348907
        , 43046721
        , 129140163
        , 387420489
        , 1162261467
        , 3486784401
        , 10460353203
        , 31381059609
        , 94143178827
    };

    public long solve(long n, long m)
    {
        long k = 1;
        long left = n;
        Dictionary<long, long> cachedModulos = new Dictionary<long, long>();
        while (left > 0)
        {
            long power = (n % powersOf3.Length);
            if (cachedModulos.ContainsKey(power - 1))
            {
                k *= cachedModulos[power - 1];
            } else {
                long cm = powersOf3[power - 1] % m;
                cachedModulos[power - 1] = cm;
                k *= cm;
            }
            k %= m;
            left -= power;
        }
        return k - 1;
    }

    public static void Main(string[] args)
    {
        string[] lines = Console.ReadLine().Split();
        long n = Convert.ToInt64(lines[0]);
        long m = Convert.ToInt64(lines[1]);
        Console.WriteLine(new CF_227C().solve(n, m));
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test_CF_227C
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual(2, new CF_227C().solve(1, 10));
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(2, new CF_227C().solve(3, 8));
        }

        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual(2619146, new CF_227C().solve(331358794, 820674098));
        }
    }
}
#endif
