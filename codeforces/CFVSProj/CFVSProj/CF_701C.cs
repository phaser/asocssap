using System;
using System.IO;
using System.Text;

public class CF_701C
{
    public long Set(long value, char l)
    {
        value |= ((long)1 << (l - 'A'));
        return value;
    }

    public long Unset(long value, char l)
    {
        value &= (~((long)1 << (l - 'A')));
        return value;
    }

    public bool Has(long dict, char l)
    {
        return ((dict & ((long)1 << (l - 'A'))) != 0);
    }

    public int solve(string flats)
    {
        long lLetterCount = 0;
        int[] count = new int[60];
        for (int i = 0; i < flats.Length; i++)
        {
            lLetterCount = Set(lLetterCount, flats[i]);
        }

        int l = 0, r = 0;
        int ans = int.MaxValue;
        long maxLetterCount = NumberOfSetBits(lLetterCount);
        long currentLetterCount = 0;
        long numCurrentLetterCount = 0;
        currentLetterCount = Set(currentLetterCount, flats[r]);
        numCurrentLetterCount = NumberOfSetBits(currentLetterCount);
        count[flats[r] - 'A']++;
        while (l < flats.Length)
        {
            while (r < flats.Length && numCurrentLetterCount < maxLetterCount)
            {
                r++;
                if (r < flats.Length)
                {
                    currentLetterCount = Set(currentLetterCount, flats[r]);
                    numCurrentLetterCount = NumberOfSetBits(currentLetterCount);
                    count[flats[r] - 'A']++;
                }
            }
            if (numCurrentLetterCount >= maxLetterCount)
            {
                ans = Math.Min(ans, r - l + 1);
            }

            if (count[flats[l] - 'A'] == 1)
            {
                currentLetterCount = Unset(currentLetterCount, flats[l]);
                numCurrentLetterCount = NumberOfSetBits(currentLetterCount);
            }
            count[flats[l] - 'A']--;

            l++;
        }
        return ans;
    }

    static long NumberOfSetBits(long i)
    {
        i = i - ((i >> 1) & 0x5555555555555555);
        i = (i & 0x3333333333333333) + ((i >> 2) & 0x3333333333333333);
        return (((i + (i >> 4)) & 0xF0F0F0F0F0F0F0F) * 0x101010101010101) >> 56;
    }

    static long GetLettersEncoded(string s, int start, int end)
    {
        long enc = 0;
        for (int i = start; i <= end; i++)
        {
            enc |= ((long)(1) << (s[i] - 'A'));
        }
        return enc;
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
            Assert.AreEqual(5, new CF_701C().solve("aaBCCe"));
		}

        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual(1, new CF_701C().solve("a"));
        }
	}
}
#endif