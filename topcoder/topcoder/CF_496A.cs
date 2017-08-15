using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CF_496A
{
    static int Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string line = Console.ReadLine();
        string[] snums = line.Split(new char[] { ' ' });
        List<int> nums = new List<int>();
        foreach (var snum in snums)
        {
            nums.Add(Convert.ToInt32(snum));
        }
        int result = new CF_496A().solve(nums.ToArray());
        Console.WriteLine(result);
        return 0;
    }

    public int solve(int[] holds)
    {
        int[] diffs = new int[holds.Length];
        int pn = 0;
        for (int i = 0; i < holds.Length; i++)
        {
            diffs[i] = holds[i] - pn;
            pn = holds[i];
        }

        int min = 1;
        for (int i = 2; i < diffs.Length; i++)
        {
            if (diffs[i] < diffs[min])
                min = i;
            else if (diffs[i] == diffs[min] 
                     && i+1 < diffs.Length 
                     && min+1 < diffs.Length 
                     && (diffs[i] + diffs[i + 1]) < (diffs[min] + diffs[min + 1]))
                min = i;
        }
        if (min == (diffs.Length - 1)) min--;
        diffs[min] += diffs[min + 1];
        int max = diffs[1];
        for (int i = 2; i < diffs.Length; i++)
        {
            if (diffs[i] > max)
                max = diffs[i];
        }
        return max;
    }
}

#if !ONLINE_JUDGE
namespace CodeForces
{
    using NUnit.Framework;

    [TestFixture]
    class Test_CF_496A
    {
        [Test]
        public void Test1()
        {
            int[] nums = { 1, 4, 6 };
            Assert.AreEqual(5, new CF_496A().solve(nums));
        }

        [Test]
        public void Test2()
        {
            int[] nums = { 1, 2, 3, 4, 5 };
            Assert.AreEqual(2, new CF_496A().solve(nums));
        }

        [Test]
        public void Test3()
        {
            int[] nums = { 1, 2, 3, 7, 8 };
            Assert.AreEqual(4, new CF_496A().solve(nums));
        }

        [Test]
        public void Test4()
        {
            int[] nums = { 1, 4, 9, 16, 25, 36, 49, 64, 81, 100 };
            Assert.AreEqual(19, new CF_496A().solve(nums));
        }

        [Test]
        public void Test5()
        {
            int[] nums = {
                178, 186, 196, 209, 217,
                226, 236, 248, 260, 273,
                281, 291, 300, 309, 322,
                331, 343, 357, 366, 377,
                389, 399, 409, 419, 429,
                442, 450, 459, 469, 477,
                491, 501, 512, 524, 534,
                548, 557, 568, 582, 593,
                602, 616, 630, 643, 652,
                660, 670, 679, 693, 707,
                715, 728, 737, 750, 759,
                768, 776, 789, 797, 807,
                815, 827, 837, 849, 863,
                873, 881, 890, 901, 910,
                920, 932};
            Assert.AreEqual(17, new CF_496A().solve(nums));
        }
    }
}
#endif