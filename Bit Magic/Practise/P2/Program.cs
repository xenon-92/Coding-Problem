using System;

namespace P2
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var res = s.CountnumberOfSetBits(2147483647);
            var res1 = s.M2(2147483647);
            var res2 = s.M2_recursive(2147483647);
            var res3 = s.M3(2147483647);
            System.Console.WriteLine(res + " " + res1 + " " + res2 + " " + res3);
        }
    }

    class Solution
    {
        // trivial solution
        public int CountnumberOfSetBits(int n)
        {
            if (n <= 0) return 0;
            int res = 0;
            while (n > 0)
            {
                if ((n & 1) != 0)
                {
                    res += 1;
                }

                n = n >> 1;
            }
            return res;
        }
        //Brian Kerninangams algorithm
        public int M2(int n)
        {
            if (n <= 0) return 0;
            int res = 0;
            while (n > 0)
            {
                n = n & (n - 1);
                res += 1;
            }
            return res;
        }
        public int M2_recursive(int n)
        {
            if (n <= 0) return 0;
            return 1 + M2_recursive(n & (n - 1));
        }
        public int M3(int n)
        {
            int[] lookup = new int[256];
            lookup[0] = 0;
            for (int i = 1; i <= 255; i++)
            {
                lookup[i] = (i & 1) + lookup[i / 2];
            }
            int res = lookup[n & 0xff];
            n = n >> 8;
            res = res + lookup[n & 0xff];
            n = n >> 8;
            res = res + lookup[n & 0xff];
            n = n >> 8;
            res = res + lookup[n & 0xff];
            return res;

        }
    }
}
