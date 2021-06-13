using System;

namespace L5_Two_odd_occuring
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 1, 2, 2, 2, 2, 2, 3, 4, 4, 4, 4, 4, 4, 5, 5 };
            Solution s = new Solution();
            s.TwoOddOccuring(arr);
        }
    }

    class Solution
    {
        public void TwoOddOccuring(int[] arr)
        {
            int xor = 0; int res = 0; int res1 = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                xor = xor ^ arr[i];
            }
            int rightMostSetBit = xor & ~(xor - 1);
            for (int i = 0; i < arr.Length; i++)
            {
                if ((arr[i] & rightMostSetBit) != 0)
                {
                    res = res ^ arr[i];
                }
                else
                {
                    res1 = res1 ^ arr[i];
                }
            }

            System.Console.WriteLine(res + " " + res1);
        }
    }
}
