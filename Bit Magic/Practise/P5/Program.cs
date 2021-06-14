using System;

namespace P5
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var k = new int[] { 1, 1, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 5, 5, 6, 6 };
            s.TwoOddAppearing(k);
        }
    }
    class Solution
    {
        public void TwoOddAppearing(int[] arr)
        {
            int xor = 0, res1 = 0, res2 = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                xor = xor ^ arr[i];
            }
            int rightmostSetBit = xor & (~(xor - 1));

            for (int i = 0; i < arr.Length; i++)
            {
                if ((rightmostSetBit & arr[i]) > 0)
                {
                    res1 = res1 ^ arr[i];
                }
                else
                {
                    res2 = res2 ^ arr[i];
                }
            }
            System.Console.WriteLine(res1 + " " + res2);
        }
    }
}
