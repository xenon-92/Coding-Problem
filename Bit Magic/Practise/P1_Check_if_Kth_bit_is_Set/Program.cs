using System;

namespace P1_Check_if_Kth_bit_is_Set
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var res1 = s.IsKthBitIsSet(5, 3);
            var res2 = s.Method2(5, 3);
            System.Console.WriteLine(res1 + " " + res2);
        }
    }

    class Solution
    {
        // by left shift
        public bool IsKthBitIsSet(int n, int k)
        {
            if ((n & (1 << k - 1)) != 0)
            {
                return true;
            }
            return false;
        }
        public bool Method2(int n, int k)
        {
            if (((n >> k - 1) & 1) != 0)
            {
                return true;
            }
            return false;
        }
    }


}
