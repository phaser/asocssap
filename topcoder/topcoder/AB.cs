using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AB
{
    public string createString(int n, int k)
    {
        string result = "";
        return result;
    }
}

namespace TopCoder
{
    [TestFixture]
    public class TestAB
    {
        [Test]
        public void TestExample1()
        {
            AB solver = new AB();
            string a = solver.createString(2, 0);
            Assert.AreEqual(a.Length, 2);
        }
    }
}