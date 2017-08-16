using System;

public class CF_734A
{
    static int Main(string[] args)
    {
        Console.ReadLine();
        string gh = Console.ReadLine();
        Console.WriteLine(new CF_734A().solve(gh));
        return 0;
    }

    public string solve(string gh)
    {
        int aw = 0;
        int dw = 0;
        foreach (var c in gh)
        {
            if (c == 'A')
                aw++;
            else
                dw++;
        }
        return (aw > dw ? "Anton" : aw == dw ? "Friendship" : "Danik");
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using NUnit.Framework;
    [TestFixture]
    public class Test_CF_734A
    {
        [Test]
        public void Test1()
        {
            string gh = "ADAAAA";
            Assert.AreEqual("Anton", new CF_734A().solve(gh));
        }

        [Test]
        public void Test2()
        {
            string gh = "DDDAADA";
            Assert.AreEqual("Danik", new CF_734A().solve(gh));
        }

        [Test]
        public void Test3()
        {
            string gh = "DADADA";
            Assert.AreEqual("Friendship", new CF_734A().solve(gh));
        }
    }
}
#endif