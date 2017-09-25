using System;
using System.Collections.Generic;
using System.Text;

public class CF_246D
{
    public int solve(int[] colors, HashSet<int>[] graf)
    {
        Dictionary<int, HashSet<int>> color = new Dictionary<int, HashSet<int>>();
        for (int i = 0; i < colors.Length; i++)
        {
            if (!color.ContainsKey(colors[i]))
            {
                color[colors[i]] = new HashSet<int>();
            }
            foreach (var n in graf[i])
            {
                if (colors[n] != colors[i])
                    color[colors[i]].Add(colors[n]);
            }
        }
        int max = int.MinValue;
        int col = -1;
        foreach (var kvp in color)
        {
            if (kvp.Value.Count > max)
            {
                max = kvp.Value.Count;
                col = kvp.Key;
            } else
            if (kvp.Value.Count == max && kvp.Key < col)
            {
                col = kvp.Key;
            }
        }
        return col;
    }

    public static int Main(string[] args)
    {
        string[] lines = Console.ReadLine().Split();
        int n = Convert.ToInt32(lines[0]); int m = Convert.ToInt32(lines[1]);
        lines = Console.ReadLine().Split();
        int[] colors = new int[n];
        for (int i = 0; i < n; i++)
        {
            colors[i] = Convert.ToInt32(lines[i]);
        }
        var graf = new HashSet<int>[n];
        for (int i = 0; i < graf.Length; i++)
        {
            graf[i] = new HashSet<int>();
        }

        for (int i = 0; i < m; i++)
        {
            lines = Console.ReadLine().Split();
            int a = Convert.ToInt32(lines[0]) - 1;
            int b = Convert.ToInt32(lines[1]) - 1;
            AddPair(graf, a, b);
        }
        Console.WriteLine(new CF_246D().solve(colors, graf));
        return 0;
    }

    public static void AddPair(HashSet<int>[] graf, int i, int j)
    {
        graf[i].Add(j);
        graf[j].Add(i);
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test_CF_246D
    {
        [TestMethod]
        public void Test1()
        {
            var graf = new HashSet<int>[6];
            for (int i = 0; i < graf.Length; i++)
            {
                graf[i] = new HashSet<int>();
            }
            CF_246D.AddPair(graf, 0, 1);
            CF_246D.AddPair(graf, 2, 1);
            CF_246D.AddPair(graf, 3, 2);
            CF_246D.AddPair(graf, 3, 4);
            CF_246D.AddPair(graf, 3, 5);
            Assert.AreEqual(3, new CF_246D().solve(new int[] { 1, 1, 2, 3, 5, 8 }, graf));
        }

        [TestMethod]
        public void Test2()
        {
            var graf = new HashSet<int>[5];
            for (int i = 0; i < graf.Length; i++)
            {
                graf[i] = new HashSet<int>();
            }
            CF_246D.AddPair(graf, 0, 1);
            CF_246D.AddPair(graf, 1, 2);
            CF_246D.AddPair(graf, 2, 0);
            CF_246D.AddPair(graf, 4, 2);
            CF_246D.AddPair(graf, 4, 3);
            CF_246D.AddPair(graf, 2, 3);
            Assert.AreEqual(2, new CF_246D().solve(new int[] { 4, 2, 5, 2, 4 }, graf));
        }
    }
}
#endif