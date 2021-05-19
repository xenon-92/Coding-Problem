using System;

namespace P5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] preorder = { 40, 30, 35, 80, 100 };
            Solution s = new Solution();
            s.PostOrderBST(preorder);
        }
    }

    class Solution
    {
        public void PostOrderBST(int[] preorder)
        {
            if (preorder == null || preorder.Length == 0) return;
            gidx = 0;
            PrintPostOrder(preorder, int.MinValue, int.MaxValue);
        }
        int gidx = 0;
        void PrintPostOrder(int[] preorder, int minvalue, int maxvalue)
        {
            if (gidx > preorder.Length - 1) return;

            int value = preorder[gidx];
            if (value > minvalue && value < maxvalue)
            {
                gidx += 1;
                PrintPostOrder(preorder, minvalue, value);
                PrintPostOrder(preorder, value, maxvalue);
                System.Console.Write(value + " ");
            }
        }
    }
}
