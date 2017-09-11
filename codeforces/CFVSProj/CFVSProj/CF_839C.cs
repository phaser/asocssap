using System;
using System.Collections.Generic;
using System.Text;

class CF_839C
{
    public double solve(HashSet<int>[] roads)
    {
        HashSet<int> visited = new HashSet<int>();
        Queue<int> toCheck = new Queue<int>();
        double[] p = new double[roads.Length];
        int[] l = new int[roads.Length];
        p[0] = 1.0d;
        toCheck.Enqueue(0);
        double ans = 0;
        while (toCheck.Count > 0)
        {
            int cn = toCheck.Dequeue();
            visited.Add(cn);
            HashSet<int> connections = roads[cn];
            int noC = 0;
            foreach (var c in connections)
            {
                if (!visited.Contains(c))
                {
                    noC++;
                }
            }
            foreach (var c in connections)
            {
                if (!visited.Contains(c))
                {
                    toCheck.Enqueue(c);
                    p[c] = p[cn] * (1.0d / noC);
                    l[c] = l[cn] + 1;
                }
            }

            if (noC == 0)
            {
                ans += (double)l[cn] * (double)p[cn];
            }
        }

        return ans;
    }
    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        HashSet<int>[] roads = new HashSet<int>[n];
        for (int i = 0; i < n; i++)
        {
            roads[i] = new HashSet<int>();
        }

        for (int i = 0; i < (n - 1); i++)
        {
            string[] nums = Console.ReadLine().Split();
            int a = Convert.ToInt32(nums[0]);
            int b = Convert.ToInt32(nums[1]);
            roads[a - 1].Add(b - 1);
            roads[b - 1].Add(a - 1);
        }
        double ans = new CF_839C().solve(roads);
        string sans = String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:G17}", ans);
        Console.WriteLine(sans);
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test_CF_839C
    {
        [TestMethod]
        public void Test1()
        {
            HashSet<int>[] roads = new HashSet<int>[4]
            {
                new HashSet<int>() { 1, 2},
                new HashSet<int>() { 0, 3},
                new HashSet<int>() { 0 },
                new HashSet<int>() { 1 }
            };
            Assert.AreEqual(1.5, new CF_839C().solve(roads));
        }

        [TestMethod]
        public void Test2()
        {
            HashSet<int>[] roads = new HashSet<int>[5]
            {
                new HashSet<int>() { 1, 2},
                new HashSet<int>() { 0, 4},
                new HashSet<int>() { 0, 3 },
                new HashSet<int>() { 2 },
                new HashSet<int>() { 1 }
            };
            Assert.AreEqual(2.0, new CF_839C().solve(roads));
        }

        [TestMethod]
        public void Test3()
        {
            int n = 100000;
            HashSet<int>[] roads = new HashSet<int>[n];
            for (int i = 0; i < n; i++)
            {
                roads[i] = new HashSet<int>();
                if (i != n-1)
                {
                    roads[i].Add(i + 1);
                } else
                {
                    roads[i].Add(i - 1);
                }
                
                if (i > 0)
                {
                    roads[i].Add(i - 1);
                } else
                {
                    roads[i].Add(i + 1);
                }
            }
            Assert.AreEqual(99999.0, new CF_839C().solve(roads));
        }
    }
}
#endif
