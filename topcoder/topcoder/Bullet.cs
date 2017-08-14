using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Bullets
{
    public int match(string[] guns, string bullet)
    {
        int result = -1;
        for (int i = 0; i < guns.Length; i++)
        {
            if (matchGun(guns[i], bullet))
                return i;
        }
        return result;
    }

    private bool matchGun(string v, string bullet)
    {
        bool result = countStripes(v) == countStripes(bullet);
        result = result && (v.Length == bullet.Length);
        if (!result)
        {
            return result;
        }

        result = false;
        for (int i = 0; i < v.Length; i++)
        {
            bool match = true;
            for (int j = 0; j < bullet.Length; j++)
            {
                if (v[(j + i) % v.Length] != bullet[j])
                {
                    match = false;
                    break;
                }
            }
            if (match)
            {
                return true;
            }
        }
        return result;
    }

    public int countStripes(string b)
    {
        int count = 0;
        foreach (char c in b)
        {
            count += (c == '|' ? 1 : 0);
        }
        return count;
    }
}

namespace topcoder
{
    using NUnit.Framework;

    [TestFixture]
    class TestBullets
    {
        [Test]
        public void Test1()
        {
            string[] guns = { "| | | |", "|| || |", " |||| " };
            string bullet = "|| || |";
            Assert.AreEqual(1, new Bullets().match(guns, bullet));
        }

        [Test]
        public void Test2()
        {
            string[] guns = { "||| |", "| | || " };
            string bullet = "|||| ";
            Assert.AreEqual(0, new Bullets().match(guns, bullet));
        }

        [Test]
        public void Test3()
        {
            string[] guns = { "|| || ||", "| | | | ", "||||||||" };
            string bullet = "||| ||| ";
            Assert.AreEqual(-1, new Bullets().match(guns, bullet));
        }

        [Test]
        public void Test4()
        {
            string[] guns = { };
            string bullet = "| | | |";
            Assert.AreEqual(-1, new Bullets().match(guns, bullet));
        }

        [Test]
        public void TestCount()
        {
            var bc = new Bullets();
            Assert.AreEqual(bc.countStripes("|| || |"), 5);
            Assert.AreEqual(bc.countStripes(""), 0);
            Assert.AreEqual(bc.countStripes("|"), 1);
            Assert.AreEqual(bc.countStripes("||| |"), 4);
        }
    }
}
