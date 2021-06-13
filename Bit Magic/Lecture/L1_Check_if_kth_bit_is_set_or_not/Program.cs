using System;

namespace L1_Check_if_kth_bit_is_set_or_not
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var res = s.CheckIfKthBitIsSet(7, 2);
            var res1 = s.CheckIfKthBitIsSet_1(13, 2);
            System.Console.WriteLine(res + " " + res1);
        }
    }

    class Solution
    {
        //Left shift way
        public bool CheckIfKthBitIsSet(int n, int k)
        {
            if (((1 << k - 1) & n) != 0)
            {
                return true;
            }
            return false;
        }

        //right shift
        public bool CheckIfKthBitIsSet_1(int n, int k)
        {
            if (((n >> k - 1) & 1) != 0)
            {
                return true;
            }
            return false;
        }
    }
}
