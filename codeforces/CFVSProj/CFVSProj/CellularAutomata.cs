using System;
namespace CFVSProj
{
    public class CellularAutomata
    {
        public int[] rule = new int[8] { 0, 1, 1, 1, 1, 0, 0, 0 };

        public long GetPattern(long a)
        {
			var idx = new int[3] { 0, 0, 0 };
            var len = 64;
			for (int i = 0; i < len; i++)
            {
                idx[0] = CorrectIdx(i - 2, len);
                idx[1] = CorrectIdx(i - 1, len);
                idx[2] = CorrectIdx(i, len);
            }
            return 0;
        }

        private int CorrectIdx(int v, int len)
        {
            v = (v < 0 ? v + len : v);
            v = (v >= len ? v % len : v);
            return v;
        }

        public CellularAutomata()
        {
        }
    }
}
