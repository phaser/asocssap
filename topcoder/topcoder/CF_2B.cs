using System;
using System.Text;

public struct Answer
{
    public int numZeroes;
    public string trail;
}

public struct Num25
{
    public UInt16 num2;
    public UInt16 num5;
    public char dir;
}

public class CF_2B
{
    static int Main(string[] args)
    {
        string[] nums;
        int n = Convert.ToInt32(Console.ReadLine());
        Num25[,] mat = new Num25[n, n];
        for (int i = 0; i < n; i++)
        {
            nums = Console.ReadLine().Split(' ');
            for (int j = 0; j < n; j++)
            {
                UInt64 a = Convert.ToUInt64(nums[j]);
                mat[i, j].num2 = CF_2B.GetPow(a, 2);
                mat[i, j].num5 = CF_2B.GetPow(a, 5);
            }
        }
        Answer ans = new CF_2B().solve(mat);
        Console.WriteLine(ans.numZeroes);
        Console.WriteLine(ans.trail);
        return 0;
    }

    public Answer solve(Num25[,] mat)
    {
        Answer ans = new Answer();
        Num25[,] pmat = mat;
        int mw = pmat.GetLength(0); int mh = pmat.GetLength(1);
        //pmat[0, 0].num2 += pmat[mw - 1, mh - 1].num2;
        //pmat[0, 0].num5 += pmat[mw - 1, mh - 1].num5;
        //pmat[mw - 1, mh - 1].num2 = 0;
        //pmat[mw - 1, mh - 1].num5 = 0;

        for (int i = 0; i < mw; i++)
        {
            for (int j = 0; j < mh; j++)
            {
                UInt16 t = (i - 1 >= 0 ? pmat[i - 1, j].num2 : UInt16.MaxValue);
                UInt16 l = (j - 1 >= 0 ? pmat[i, j - 1].num2 : UInt16.MaxValue);
                if (!(t == UInt16.MaxValue && l == UInt16.MaxValue))
                {
                    pmat[i, j].num2 += (t <= l ? t : l);
                }
                t = (i - 1 >= 0 ? pmat[i - 1, j].num5 : UInt16.MaxValue);
                l = (j - 1 >= 0 ? pmat[i, j - 1].num5 : UInt16.MaxValue);
                if (!(t == UInt16.MaxValue && l == UInt16.MaxValue))
                {
                    pmat[i, j].num5 += (t <= l ? t : l);
                }
            }
        }

        ans.numZeroes = Math.Min(pmat[mw - 1, mh - 1].num2, pmat[mw - 1, mh - 1].num5);
        StringBuilder sb = new StringBuilder();
        if (ans.numZeroes == pmat[mw - 1, mh - 1].num2)
        {
            int cx = mw - 1;
            int cy = mh - 1;
            while (!(cx == 0 && cy == 0))
            {
                UInt16 t = cx - 1 >= 0 ? pmat[cx - 1, cy].num2 : UInt16.MaxValue;
                UInt16 l = cy - 1 >= 0 ? pmat[cx, cy - 1].num2 : UInt16.MaxValue;
                if (t < l)
                {
                    sb.Append("D");
                    cx--;
                } else
                {
                    sb.Append("R");
                    cy--;
                }
            }
        }
        else
        {
            int cx = mw - 1;
            int cy = mh - 1;
            while (!(cx == 0 && cy == 0))
            {
                UInt16 t = cx - 1 >= 0 ? pmat[cx - 1, cy].num5 : UInt16.MaxValue;
                UInt16 l = cy - 1 >= 0 ? pmat[cx, cy - 1].num5 : UInt16.MaxValue;
                if (t < l)
                {
                    sb.Append("D");
                    cx--;
                }
                else
                {
                    sb.Append("R");
                    cy--;
                }
            }
        }
        char[] trail = sb.ToString().ToCharArray();
        Array.Reverse(trail);
        ans.trail = new string(trail);
        return ans;
    }

    public static ushort GetPow(UInt64 v, UInt64 p)
    {
        UInt64 r = v;
        ushort c = 0;
        while ((r % p) == 0)
        {
            c++;
            r /= p;
        }
        return c;
    }

    public static Num25[,] GetProperMatrix(int[,] mat)
    {
        Num25[,] pmat = new Num25[mat.GetLength(0), mat.GetLength(1)];
        for (int i = 0; i < pmat.GetLength(0); i++)
        {
            for (int j = 0; j < pmat.GetLength(1); j++)
            {
                pmat[i, j].num2 = CF_2B.GetPow((UInt64)mat[i, j], 2);
                pmat[i, j].num5 = CF_2B.GetPow((UInt64)mat[i, j], 5);
            }
        }
        return pmat;
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
            Answer ans = new CF_2B().solve(CF_2B.GetProperMatrix(mat));
            Assert.AreEqual(0, ans.numZeroes);
            Assert.AreEqual("DDRR", ans.trail);
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
            Answer ans = new CF_2B().solve(CF_2B.GetProperMatrix(mat));
            Assert.AreEqual(1, ans.numZeroes);
            Assert.AreEqual("DRRD", ans.trail);
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
            Answer ans = new CF_2B().solve(CF_2B.GetProperMatrix(mat));
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
            Answer ans = new CF_2B().solve(CF_2B.GetProperMatrix(mat));
            Assert.AreEqual(1, ans.numZeroes);
            Assert.AreEqual("DDRRDRDDRR", ans.trail);
        }

        [Test]
        public void Test5()
        {
            Random rand = new Random();
            int[,] mat = new int[20, 20];
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 20; j++)
                    mat[i, j] = (int)(rand.NextDouble() * 500);
            Answer ans = new CF_2B().solve(CF_2B.GetProperMatrix(mat));
        }
    }
}
#endif