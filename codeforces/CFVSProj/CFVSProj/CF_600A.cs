using System;
using System.Collections.Generic;
using System.Text;

class CF_600A
{
    public string solve(string input)
    {
        return "";
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test_CF_600A
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual("\"123, 0\"\n\"aba,1a\"", new CF_600A().solve("aba,123;1a;0"));
        }
    }
}
#endif