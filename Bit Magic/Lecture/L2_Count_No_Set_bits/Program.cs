using System;

namespace L2_Count_No_Set_bits
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution1 s1 = new Solution1();
            Solution2 s2 = new Solution2();
            Solution3 s3 = new Solution3();
            var res1 = s1.Count(254);
            var res2 = s2.Count(254);
            var res3 = s3.Count(254);
            System.Console.WriteLine(res1 + " " + res2 + " " + res3);
        }
    }

    //solution naive
    class Solution1
    {
        public int Count(int n)
        {
            int result = 0;
            while (n > 0)
            {
                if ((n & 1) != 0)
                {
                    result += 1;
                }
                n = n >> 1;
            }
            return result;
        }
    }
    //solution 2 : Brian Kerningam's Algorithm

    class Solution2
    {
        public int Count(int n)
        {
            int res = 0;
            while (n > 0)
            {
                res += 1;
                n = n & (n - 1);
            }
            return res;
        }
    }

    class Solution3
    {
        int[] lookup = new int[256];
        public Solution3()
        {
            lookup[0] = 0;
            for (int i = 1; i < 256; i++)
            {
                lookup[i] = (i & 1) + lookup[i / 2];
            }
        }

        public int Count(int n)
        {
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
