using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

class CF_556A
{
    public int solve(string zo)
    {
        Stack<char> st = new Stack<char>();
        foreach (var c in zo)
        {
            if (st.Count > 0)
            {
                if (st.Peek() != c)
                {
                    st.Pop();
                } else {
                    st.Push(c);
                }
            } else {
                st.Push(c);
            }
        }
        return st.Count;
    }

    public static void Main(string[] args)
    {
        Console.ReadLine();
        Console.WriteLine(new CF_556A().solve(Console.ReadLine()));
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class Test_CF_556A
	{
		[TestMethod]
		public void Test1()
		{
            Assert.AreEqual(0, new CF_556A().solve("1100"));
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(1, new CF_556A().solve("01010"));
        }

        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual(6, new CF_556A().solve("11101111"));

        }
    }
}
#endif
