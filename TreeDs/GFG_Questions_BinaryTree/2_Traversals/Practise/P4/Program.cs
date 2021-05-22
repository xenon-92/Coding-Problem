using System;
using System.Collections.Generic;

namespace P4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inorder = { 4, 2, 5, 1, 3, 6 };
            int[] preorder = { 1, 2, 4, 5, 3, 6 };
            Solution s = new Solution();
            s.PrintPostOrder(preorder, inorder);
        }
    }


    class Solution
    {
        public void PrintPostOrder(int[] preorder, int[] inorder)
        {
            if (preorder == null || inorder == null || preorder.Length == 0 || inorder.Length == 0)
                return;
            Dictionary<int, int> kvp = new Dictionary<int, int>();
            for (int i = 0; i < inorder.Length; i++)
            {
                kvp.Add(inorder[i], i);
            }
            UtilityPrintPostOrder(preorder, inorder, 0, inorder.Length - 1, kvp);
        }
        int gidx = 0;

        void UtilityPrintPostOrder(int[] preorder, int[] inorder, int iStart, int iEnd, Dictionary<int, int> kvp)
        {
            if (iStart > iEnd) return;
            int rootvalue = preorder[gidx];
            gidx += 1;
            int inorderIdx = kvp[rootvalue];
            UtilityPrintPostOrder(preorder, inorder, iStart, inorderIdx - 1, kvp);
            UtilityPrintPostOrder(preorder, inorder, inorderIdx + 1, iEnd, kvp);
            System.Console.Write(rootvalue + " ");
        }
    }
}
