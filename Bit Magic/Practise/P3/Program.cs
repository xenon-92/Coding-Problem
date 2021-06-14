using System;

namespace P3
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var res1 = s.IsPowerof2(32);
            var res2 = s.M2(32);
            System.Console.WriteLine(res1 + " " + res2);
        }
    }

    class Solution
    {
        public bool IsPowerof2(int n)
        {
            if (n <= 0) return false;
            int res = 0;
            while (n > 0)
            {
                n = n & (n - 1);
                res += 1;
            }
            return res == 1 ? true : false;
        }
        public bool M2(int n)
        {
            if (n <= 0) return false;
            if ((n & (n - 1)) == 0) return true;
            return false;
        }
    }
}
