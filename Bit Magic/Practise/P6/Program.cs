using System;

namespace P6
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            s.PrintPowerset("sumit");
        }
    }

    class Solution
    {
        public void PrintPowerset(string str)
        {
            int n = str.Length;
            int pow_num = (int)Math.Pow(2, n);
            for (int i = 0; i < pow_num; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((i & (1 << j)) != 0)
                    {
                        System.Console.Write(str[j]);
                    }
                }
                System.Console.WriteLine();
            }
        }
    }
}
