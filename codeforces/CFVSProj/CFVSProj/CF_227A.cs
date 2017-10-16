using System;
using System.Collections.Generic;
using System.Text;

public class Point
{
    public long x, y;
    public Point(int x, int y)
    {
        this.x = x; this.y = y;
    }

    public static Point operator-(Point b, Point c)
    {
        Point a = new Point(0, 0);
        a.x = b.x - c.x;
        a.y = b.y - c.y;
        return a;
    }

    public static Point operator+(Point b, Point c)
    {
        Point a = new Point(0, 0);
        a.x = b.x + c.x;
        a.y = b.y + c.y;
        return a;
    }

    public void Rot90()
    {
        long tmp = x;
        x = -y;
        y = tmp;
    }
}

public class CF_227A
{
    public static void Main(string[] args)
    {
        string[] lines = Console.ReadLine().Split();
        Point A = new Point(Convert.ToInt32(lines[0]), Convert.ToInt32(lines[1]));
        lines = Console.ReadLine().Split();
        Point B = new Point(Convert.ToInt32(lines[0]), Convert.ToInt32(lines[1]));
        lines = Console.ReadLine().Split();
        Point C = new Point(Convert.ToInt32(lines[0]), Convert.ToInt32(lines[1]));
        Console.WriteLine(new CF_227A().solve(A, B, C));
    }

    public string solve(Point A, Point B, Point C)
    {
        if ((B.y - A.y) * (C.x - A.x) == (B.x - A.x) * (C.y - A.y))
        {
            return "TOWARDS";
        }

        Point F1 = B - A;
        F1.Rot90();
        Point F2 = C - B;
        if (F1.x * F2.x + F1.y * F2.y < 0)
        {
            return "RIGHT";
        }
        return "LEFT";
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test_CF_227A
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual("TOWARDS", new CF_227A().solve(new Point(-1, -1), new Point(-3, -3), new Point(-4, -4)));
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual("RIGHT", new CF_227A().solve(new Point(0, 0), new Point(0, 1), new Point(1, 1)));
        }

        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual("LEFT", new CF_227A().solve(new Point(-4, -6), new Point(-3, -7), new Point(-2, -6)));
        }

        [TestMethod]
        public void Test4()
        {
            Assert.AreEqual("RIGHT", new CF_227A().solve(new Point(-44, 57), new Point(-118, -41), new Point(-216, 33)));
        }
    }
}
#endif