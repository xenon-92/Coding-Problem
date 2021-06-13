using System;

namespace L4_One_odd__occuring
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[] arr = { 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 5, 7, 7 };
            var res = s.OneOddOccuring(arr);
            //System.Console.WriteLine(res);

            Solution1 s1 = new Solution1();
            int[] arr1 = { 1, 2, 4 };
            var res1 = s1.GetMissingNumber(arr1);
            System.Console.WriteLine(res1);
        }
    }

    class Solution
    {
        public int OneOddOccuring(int[] arr)
        {
            int res = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                res = res ^ arr[i];
            }
            return res;
        }
    }
    // Other way of framing it
    // Given a array of n numbers, that has a value in Range [1,n+1].
    // Every number appears once. Hence one number is missing, find the missing number

    class Solution1
    {
        public int GetMissingNumber(int[] arr)
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
