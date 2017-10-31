using System;
using System.Numerics;

public class CF_227C
{
    public CF_227C()
    {
    }

    public long solve(int n, int m)
    {
		long[] powersof3 = new long[32];
		powersof3[0] = 3 % m;
		for (int i = 1; i < 32; i++)
        {
			powersof3[i] = (powersof3[i - 1] * powersof3[i - 1]) % m;
		}

        long answer = 1;
        for (int i = 0; i < 32; i++)
        {
            if ((n & (1 << i)) != 0)
            {
                answer *= powersof3[i];
                answer %= m;
            }
        }
        answer = (answer == 0 ? m - 1 : answer - 1);
        return answer;
	}

    public static void Main(string[] args)
    {
        string[] lines = Console.ReadLine().Split();
        int n = Convert.ToInt32(lines[0]);
        int m = Convert.ToInt32(lines[1]);
        Console.WriteLine(new CF_227C().solve(n, m));
    }
}
