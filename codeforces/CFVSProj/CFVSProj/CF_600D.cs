using System;
using System.Collections.Generic;
using System.Text;

class CF_600D
{
    public string GetCircleCircleIntersectionArea(int x1, int y1, int r1, int x2, int y2, int r2)
    {
        double ans = 0;
        double d = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        if (d < r1 + r2)
        {
            double a = r1 * r1;
            double b = r2 * r2;
            double x = (a - b + d * d) / (2 * d);
            double z = x * x;
            double y = Math.Sqrt(a - z);
            if (d < Math.Abs(r1 - r2))
            {
                ans = Math.PI * Math.Min(a, b);
            } else
            {
                ans = a * Math.Asin(y / r1) + Math.Asin(y / r2) - y * (x + Math.Sqrt(z + b - a));
            }
            string sans = String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:G17}", ans);
            return sans;
        }
        return "0";
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test_CF_600D
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual("7.25298806364175601379", new CF_600D().GetCircleCircleIntersectionArea(0, 0, 4, 6, 0, 4));
        }
    }
}
#endif