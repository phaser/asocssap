using System;

class CF_130J
{
    private int[] days_normal = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    private int[] days_leap = new int[] { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

    public string solve(int year, int day)
    {
        int[] days = (IsLeapYear(year) ? days_leap : days_normal);
        int c = -1;
        int md = day;
        while (md > 0)
        {
            md -= days[++c];
        }
        int month = c + 1;
        int day_month = days[c] + md;
        return day_month + " " + month;
    }

    private bool IsLeapYear(int year)
    {
        if (year % 400 == 0)
            return true;
        if (year % 100 != 0 && year % 4 == 0)
            return true;
        return false;
    }

    public static void Main(string[] args)
    {
        int year = Convert.ToInt32(Console.ReadLine());
        int day = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(new CF_130J().solve(year, day));
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test_CF_130J
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual("20 11", new CF_130J().solve(2011, 324));
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual("30 9", new CF_130J().solve(2012, 274));
        }

        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual("29 2", new CF_130J().solve(2400, 60));
        }
    }
}
#endif