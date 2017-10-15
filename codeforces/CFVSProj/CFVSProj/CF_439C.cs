using System;
using System.Collections.Generic;
using System.Text;

public class CF_439C
{
    public static void Main(string[] args)
    {
        string[] lines = Console.ReadLine().Split();
        int n, k, p;
        n = Convert.ToInt32(lines[0]);
        k = Convert.ToInt32(lines[1]);
        p = Convert.ToInt32(lines[2]);
        lines = Console.ReadLine().Split();
        var even = new Queue<int>();
        var odd = new Queue<int>();
        for (int i = 0; i < n; i++)
        {
            int num = Convert.ToInt32(lines[i]);
            if (num % 2 == 0)
            {
                even.Enqueue(num);
            }
            else
            {
                odd.Enqueue(num);
            }
        }

        Console.WriteLine(new CF_439C().solve(n, k, p, even, odd));
    }

    private string solve(int n, int k, int p, Queue<int> even, Queue<int> odd)
    {
        if ((k - p > odd.Count)
         || (p > even.Count + (odd.Count - k + p) / 2))
        {
            return "NO";
        }

        // Generate odds
        List<int>[] oddPart = new List<int>[k-p];
        for (int i = 0; i < oddPart.Length; i++)
        {
            oddPart[i] = new List<int>();
            oddPart[i].Add(odd.Dequeue());
        }

        // Generate evens
        List<int>[] evenPart = new List<int>[p];
        for (int i = 0; i < evenPart.Length; i++)
        {
            evenPart[i] = new List<int>();
            if (even.Count > 0)
            {
                evenPart[i].Add(even.Dequeue());
            } else {
                evenPart[i].Add(odd.Dequeue());
                evenPart[i].Add(odd.Dequeue());
            }
        }

        // Deal with what remained
        if (k - p > 0)
        {
            if (odd.Count > 0)
            {
                if (odd.Count % 2 == 0)
                {
                    oddPart[0].AddRange(odd);
                }
                else
                {
                    return "NO";
                }
            }
        } else {
            if (odd.Count > 0)
            {
                if (odd.Count % 2 == 0)
                {
                    evenPart[0].AddRange(odd);
                } else {
                    return "NO";
                }
            }
        }

        if (p > 0)
        {
            if (even.Count > 0)
            evenPart[0].AddRange(even);
        } else {
            if (even.Count > 0)
            oddPart[0].AddRange(even);
        }

        StringBuilder sb = new StringBuilder();
        sb.Append("YES\n");
        for (int i = 0; i < evenPart.Length; i++)
        {
            sb.Append(evenPart[i].Count + " ");
            foreach (var num in evenPart[i])
            {
                sb.Append(num + " ");
            }
            sb.Append("\n");
        }

        for (int i = 0; i < oddPart.Length; i++)
        {
            sb.Append(oddPart[i].Count + " ");
            foreach (var num in oddPart[i])
            {
                sb.Append(num + " ");
            }
            sb.Append("\n");
        }
        return sb.ToString();
    }
}
