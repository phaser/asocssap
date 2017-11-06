using System;
using System.Collections.Generic;
using System.Text;

class TestImgCompression
{
    UInt32[] halves = new UInt32[]
    {
            0xFFFF,
            0xFF,
            0xF,
            3,
            1
    };

    public byte ConverIntToChar(UInt32 num)
    {
        UInt32 cnum = num;
        byte res = 0;
        for (int i = 0; i < halves.Length; i++)
        {
            if (cnum > halves[i])
            {
                res |= (byte)(1 << (halves.Length - i - 1));
                cnum %= halves[i];
            }
        }
        if (cnum == 1)
        {
            res |= 1;
        }
        return res;
    }

    public UInt32 ConvertByteToInt(byte a)
    {
        UInt32 res = 0;
        if ((a & 1) != 0)
            res = 1;
        for (int i = 1; i < halves.Length; i++)
        {
            if ((a & (byte)(1 << i)) != 0)
            {
                res = res * halves[i];
            }
        }
        return 0;
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test_ImgCompression
    {
        [TestMethod]
        public void Test1()
        {
            var tic = new TestImgCompression();
            UInt32 num = (UInt32)(new Random().NextDouble() * UInt32.MaxValue);
            byte a = tic.ConverIntToChar(num);
            UInt32 test = tic.ConvertByteToInt(a);
            Assert.AreEqual(num, test);
        }
    }
}
#endif
