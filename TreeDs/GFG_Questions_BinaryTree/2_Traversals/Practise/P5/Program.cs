using System;

namespace P5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] preOrder = { 40, 30, 32, 35, 80, 90, 100, 120 };

            Solution s = new Solution();
            s.PrintPostOrder(preOrder);
        }
    }
    class Solution
    {
        public void PrintPostOrder(int[] preOrder)
        {
            if (preOrder == null) return;
            UtilityPrint(preOrder, int.MinValue, int.MaxValue);
        }

        int gIdx = 0;
        void UtilityPrint(int[] preOrder, int minval, int maxval)
        {
            if (gIdx > preOrder.Length - 1) return;

            int val = preOrder[gIdx];
            if (val > minval && val < maxval)
            {
                gIdx += 1;
                UtilityPrint(preOrder, minval, val);
                UtilityPrint(preOrder, val, maxval);
                System.Console.Write(val + " ");
            }
        }
    }
}
