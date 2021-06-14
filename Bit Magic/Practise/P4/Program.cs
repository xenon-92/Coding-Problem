using System;

namespace P4
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 1, 1, 1, 2, 2, 3, 3, 3, 3 };
            Solution s = new Solution();
            System.Console.WriteLine(s.oddOccuring(arr));

            int[] k = { 1, 2, 4, 5 };
            System.Console.WriteLine(s.M1(k));
        }
    }

    class Solution
    {
        public int oddOccuring(int[] n)
        {
            int res = 0;
            for (int i = 0; i < n.Length; i++)
            {
                res = res ^ n[i];
            }
            return res;
        }
        //Given an array of n numbers that has value in range of [1,n+1]. every number appears once and hence one number is missing.find the missing number

        public int M1(int[] arr)
        {
            int res = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                res = res ^ arr[i];
            }
            for (int i = 1; i <= arr.Length + 1; i++)
            {
                res = res ^ i;
            }
            return res;
        }
    }

}
