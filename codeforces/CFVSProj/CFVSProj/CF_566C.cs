using System;
using System.Collections.Generic;

public class CF_566C
{
    public class Key
    {
        public static long GetCity1(long key)
        {
            return (key >> 32);
        }

        public static long GetCity2(long key)
        {
            return (key & 0x00000000FFFFFFFF);
        }

        public static long EncodeKey(int city1, int city2)
        {
			long key = 0;
			key = key | (long)city1;
			key = key << 32;
            key = key | (long)city2;
            return key;
		}
    }

    public class Result
    {
        public int city;
        public double cost;

        public void print()
        {
            Console.WriteLine(city + " " + cost);
        }
    }

    public Result solve(Dictionary<long, int> cities, HashSet<int>[] links, int[] participants)
    {
        Result result = new Result();
        int n = participants.Length;

		int minCity = 1;
        double minCost = double.MaxValue;
		for (int k = 1; k <= n; k++)
        {
			int[] lenghts = new int[n + 1];
			HashSet<int> visited = new HashSet<int>();
			Queue<int> currentCity = new Queue<int>();
            currentCity.Enqueue(k);
            while (currentCity.Count > 0)
            {
                int cc = currentCity.Dequeue();
				visited.Add(cc);
				foreach (var city in links[cc])
                {
                    if (!visited.Contains(city))
                    {
                        currentCity.Enqueue(city);
                        lenghts[city] += lenghts[cc] + GetCost(cc, city, cities);
                    }
                }
            }
			double cost = ComputeCost(lenghts, participants);
            if (cost < minCost)
            {
                minCost = cost;
                minCity = k;
            }
		}
        result.city = minCity;
        result.cost = minCost;
        return result;
    }

    private double ComputeCost(int[] lenghts, int[] participants)
    {
        double sum = 0;
        for (int i = 0; i < participants.Length; i++)
        {
            double l = participants[i] * Math.Pow(lenghts[i + 1], 3.0 / 2.0);
            sum += l;
        }
        return sum;
    }

    public static bool HasLink(int city1, int city2, Dictionary<long, int> cities)
    {
		if (city1 > city2)
		{
			var aux = city1;
			city1 = city2;
			city2 = aux;
		}
		var key = Key.EncodeKey(city1, city2);
        return cities.ContainsKey(key);
	}

    public static int GetCost(int city1, int city2, Dictionary<long, int> cities)
    {
        if (city1 > city2)
        {
            var aux = city1;
            city1 = city2;
            city2 = aux;
        }
        var key = Key.EncodeKey(city1, city2);
        return cities[key];
    }

    public static void RegisterCost(int city1, int city2, int cost, Dictionary<long, int> cities, HashSet<int>[] links)
    {
		if (city1 > city2)
		{
			var aux = city1;
			city1 = city2;
			city2 = aux;
		}
		var key = Key.EncodeKey(city1, city2);
        links[city1].Add(city2); links[city2].Add(city1);
        cities[key] = cost;
	}
}

#if !ONLINE_JUDGE
namespace CodeForces
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class Test_CF_566C
	{
		[TestMethod]
		public void Test_Key()
		{
            long key = CF_566C.Key.EncodeKey(123212, 200000);
            long city1 = CF_566C.Key.GetCity1(key);
            long city2 = CF_566C.Key.GetCity2(key);
            Assert.AreEqual(123212, city1);
            Assert.AreEqual(200000, city2);
		}

		[TestMethod]
		public void Test_Dictionary()
		{
			HashSet<int>[] links = new HashSet<int>[6];
			for (int i = 0; i < links.Length; i++)
			{
				links[i] = new HashSet<int>();
			}
			Dictionary<long, int> cities = new Dictionary<long, int>();
            CF_566C.RegisterCost(1, 2, 3, cities, links);
			CF_566C.RegisterCost(2, 3, 1, cities, links);
			CF_566C.RegisterCost(4, 3, 9, cities, links);
			CF_566C.RegisterCost(5, 3, 1, cities, links);
			Assert.AreEqual(3, CF_566C.GetCost(2, 1, cities));
			Assert.AreEqual(3, CF_566C.GetCost(1, 2, cities));
			Assert.AreEqual(1, CF_566C.GetCost(2, 3, cities));
			Assert.AreEqual(1, CF_566C.GetCost(3, 2, cities));
			Assert.AreEqual(9, CF_566C.GetCost(4, 3, cities));
			Assert.AreEqual(9, CF_566C.GetCost(3, 4, cities));
			Assert.AreEqual(1, CF_566C.GetCost(5, 3, cities));
			Assert.AreEqual(1, CF_566C.GetCost(3, 5, cities));
		}

        [TestMethod]
        public void Test1()
        {
			Dictionary<long, int> cities = new Dictionary<long, int>();
			HashSet<int>[] links = new HashSet<int>[6];
            for (int i = 0; i < links.Length; i++)
            {
                links[i] = new HashSet<int>();
            }
			CF_566C.RegisterCost(1, 2, 3, cities, links);
			CF_566C.RegisterCost(2, 3, 1, cities, links);
			CF_566C.RegisterCost(4, 3, 9, cities, links);
			CF_566C.RegisterCost(5, 3, 1, cities, links);
            var result = new CF_566C().solve(cities, links, new int[] { 3, 1, 2, 6, 5 });
            Assert.AreEqual(3, result.city);
            Assert.AreEqual(192.0, result.cost);
		}

        [TestMethod]
        public void Test2()
        {
			Dictionary<long, int> cities = new Dictionary<long, int>();
			HashSet<int>[] links = new HashSet<int>[3];
			for (int i = 0; i < links.Length; i++)
			{
				links[i] = new HashSet<int>();
			}
			CF_566C.RegisterCost(1, 2, 2, cities, links);
			var result = new CF_566C().solve(cities, links, new int[] { 5, 5 });
			Assert.AreEqual(1, result.city);
			Assert.AreEqual(14.142135623730951000, result.cost);
        }

        [TestMethod]
        public void Test3()
        {
            int num = 100;
			Dictionary<long, int> cities = new Dictionary<long, int>();
			HashSet<int>[] links = new HashSet<int>[num + 1];
			for (int i = 0; i < links.Length; i++)
			{
				links[i] = new HashSet<int>();
			}
            int[] participants = new int[num];
            for (int i = 2; i <= num; i++)
            {
				CF_566C.RegisterCost(i-1, i, 1, cities, links);
                participants[i - 2] = 1;
			}
            var result = new CF_566C().solve(cities, links, participants);
            Assert.AreEqual(50, result.city);
            Assert.AreEqual(13790.299032633038, result.cost);
		}

        [TestMethod]
        public void Test4()
        {
			int num = 1000;
			Dictionary<long, int> cities = new Dictionary<long, int>();
			HashSet<int>[] links = new HashSet<int>[num + 1];
			for (int i = 0; i < links.Length; i++)
			{
				links[i] = new HashSet<int>();
			}
			int[] participants = new int[num];
			for (int i = 2; i <= num; i++)
			{
				CF_566C.RegisterCost(i - 1, i, 1, cities, links);
				participants[i - 2] = 1;
			}
			var result = new CF_566C().solve(cities, links, participants);
			Assert.AreEqual(500, result.city);
			//Assert.AreEqual(13790.299032633038, result.cost);
		}
	}
}
#endif