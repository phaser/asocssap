using System;
using System.IO;
using System.Text;

public class CF_701C
{
    uint[] letterCount; 
    public int solve(string flats)
    {
        letterCount = new uint['z' - 'A' + 1];
        foreach (var c in flats)
        {
            letterCount[c - 'A']++;
        }
        int p1 = 0;
        while (p1 < flats.Length && letterCount[flats[p1] - 'A'] > 1)
        {
            letterCount[flats[p1] - 'A']--;
            p1++;
        }

        int p2 = flats.Length - 1;
        while (p2 >= 0 && letterCount[flats[p2] - 'A'] > 1)
        {
            letterCount[flats[p2] - 'A']--;
            p2--;
        }
        return p2 - p1 + 1;
    }

    static void Main(string[] args)
    {
		int bufSize = 101000;
		Stream inStream = Console.OpenStandardInput(bufSize);
		Console.SetIn(new StreamReader(inStream, Console.InputEncoding, false, bufSize));

		Console.ReadLine();
		string input = Console.ReadLine();
        Console.WriteLine(new CF_701C().solve(input));
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using System.IO;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class Test_CF_701C
	{
		[TestMethod]
		public void Test1()
		{
            Assert.AreEqual(3, new CF_701C().solve("bcAAcbc"));
		}

        [TestMethod]
        public void Test2()
        {
            int perchar = 10000 / 52;
            StringBuilder flats = new StringBuilder();
            for (char c = 'A'; c <= 'Z'; c++)
            {
                for (int i = 0; i < perchar; i++)
                {
                    flats.Append(c);
                }
            }
			for (char c = 'a'; c <= 'z'; c++)
			{
				for (int i = 0; i < perchar; i++)
				{
                    flats.Append(c);
				}
			}
            File.WriteAllText("/Users/phaser/input.txt", flats.ToString());
		}

        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual(9986, new CF_701C().solve(File.ReadAllText("/Users/phaser/input.txt")));    
        }
	}
}
#endif