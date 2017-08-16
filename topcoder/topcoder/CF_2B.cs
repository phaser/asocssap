using System;

public struct Answer
{
    public int numZeroes;
    public string trail;
}

public struct Num25
{
    public int value;
    public int num0;
    public char dir;

    internal void ExtractPow10()
    {
        while ((value % 10) == 0)
        {
            num0++;
            value /= 10;
        }
    }
}

public class CF_2B
{
    static int Main(string[] args)
    {
        string[] nums;
        int n = Convert.ToInt32(Console.ReadLine());
        int[,] mat = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            nums = Console.ReadLine().Split(' ');
            for (int j = 0; j < n; j++)
            {
                mat[i, j] = Convert.ToInt32(nums[j]);
            }
        }
        Answer ans = new CF_2B().solve(mat);
        Console.WriteLine(ans.numZeroes);
        Console.WriteLine(ans.trail);
        return 0;
    }

    public Answer solve(int[,] mat)
    {
        Answer ans = new Answer();
        Num25[,] pmat = new Num25[mat.GetLength(0), mat.GetLength(1)];
        for (int i = 0; i < pmat.GetLength(0); i++)
        {
            for (int j = 0; j < pmat.GetLength(1); j++)
            {
                pmat[i, j].value = mat[i, j];
                pmat[i, j].ExtractPow10();
            }
        }
        pmat[0, 0].value *= pmat[pmat.GetLength(0) - 1, pmat.GetLength(1) - 1].value;
        pmat[pmat.GetLength(0) - 1, pmat.GetLength(1) - 1].value = 1;
        pmat[0, 0].ExtractPow10();

        for (int i = 0; i < pmat.GetLength(0); i++)
        {
            for (int j = 0; j < pmat.GetLength(1); j++)
            {
                Num25 top = new Num25(); top.num0 = int.MaxValue; top.value = int.MaxValue;
                Num25 left = new Num25(); left.num0 = int.MaxValue; left.value = int.MaxValue;
                if (i - 1 >= 0)
                {
                    top.num0 = pmat[i - 1, j].num0 + pmat[i, j].num0;
                    top.value = pmat[i - 1, j].value * pmat[i, j].value;
                }
                if (j - 1 >= 0)
                {
                    left.num0 = pmat[i, j - 1].num0 + pmat[i, j].num0;
                    left.value = pmat[i, j - 1].value * pmat[i, j].value;
                }
                Num25 choice = new Num25();
                choice.dir = 'N';
                top.ExtractPow10();
                left.ExtractPow10();
                if (left.num0 != int.MaxValue || top.num0 != int.MaxValue)
                {
                    if (left.num0 == top.num0)
                    {
                        int tp2 = NumPow2(top.value);
                        int lp2 = NumPow2(left.value);
                        int tp5 = NumPow5(top.value);
                        int lp5 = NumPow5(top.value);
                        if (tp2 + tp5 <= lp2 + lp5)
                        {
                            choice = top;
                            choice.dir = 'D';
                        }
                        else
                        {
                            choice = left;
                            choice.dir = 'R';
                        } 
                    }
                    else
                    if (left.num0 < top.num0)
                    {
                        choice = left;
                        choice.dir = 'R';
                    }
                    else
                    {
                        choice = top;
                        choice.dir = 'D';
                    }
                    if (choice.dir != 'N')
                    {
                        pmat[i, j].value = choice.value;
                        pmat[i, j].num0 = choice.num0;
                        pmat[i, j].dir = choice.dir;
                    }
                }
            }
        }

        ans.numZeroes = pmat[pmat.GetLength(0) - 1, pmat.GetLength(1) - 1].num0;
        ans.trail = "";
        int cx = pmat.GetLength(0) - 1; int cy = pmat.GetLength(1) - 1;
        while (!(cx == 0 && cy == 0))
        {
            ans.trail += pmat[cx, cy].dir;
            if (pmat[cx, cy].dir == 'D') { cx--; }
            else { cy--; }
        }
        char[] ll = ans.trail.ToCharArray();
        Array.Reverse(ll);
        ans.trail = new string(ll);
        return ans;
    }

    private int NumPow5(int value)
    {
        int res = value;
        int c = 0;
        while ((res % 5) == 0)
        {
            c++;
            res /= 5;
        }
        return c;
    }

    private int NumPow2(int value)
    {
        int res = value;
        int c = 0;
        while ((res % 2) == 0)
        {
            c++;
            res /= 2;
        }
        return c;
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using NUnit.Framework;

    [TestFixture]
    class Test_CF_2B
    {
        [Test]
        public void Test1()
        {
            int[,] mat = new int[3, 3]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
            Answer ans = new CF_2B().solve(mat);
            Assert.AreEqual(0, ans.numZeroes);
            Assert.AreEqual("RRDD", ans.trail);
        }

        [Test]
        public void Test2()
        {
            int[,] mat = new int[3, 3]
            {
                { 4, 10, 5 },
                { 10, 9, 4 },
                { 6, 5, 3 }
            };
            Answer ans = new CF_2B().solve(mat);
            Assert.AreEqual(1, ans.numZeroes);
            Assert.AreEqual("RDRD", ans.trail);
        }

        [Test]
        public void Test3()
        {
            int[,] mat = new int[4, 4]
            {
                { 1, 1, 9, 9 },
                { 3, 4, 7, 3 },
                { 7, 9, 1, 7 },
                { 1, 7, 1, 5 }
            };
            Answer ans = new CF_2B().solve(mat);
            Assert.AreEqual(0, ans.numZeroes);
            Assert.AreEqual("DDDRRR", ans.trail);
        }

        [Test]
        public void Test4()
        {
            int[,] mat =
                {
                { 5, 5, 4, 10, 5, 5 },
                { 7, 10, 8, 7, 6, 6 },
                { 7, 1, 7, 9, 7, 8 },
                { 5, 5, 3, 3, 10, 9 },
                { 5, 8, 10, 6, 3, 8 },
                { 3, 10, 5, 4, 3, 4 }
                };
            Answer ans = new CF_2B().solve(mat);
            Assert.AreEqual(1, ans.numZeroes);
        }

        [Test]
        public void Test5()
        {
            Random rand = new Random();
            int[,] mat = new int[20, 20];
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 20; j++)
                    mat[i, j] = (int)(rand.NextDouble() * 500);
            Answer ans = new CF_2B().solve(mat);
        }
    }
}
#endif