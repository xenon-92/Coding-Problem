using System;

namespace _12_CheckIfBTisBalanced
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val)
        {
            this.val = val;
        }
    }

    class Solution
    {
        public bool IsBalanced(TreeNode root)
        {
            return Utility(root);
        }
        bool Utility(TreeNode root)
        {
            if (root == null) return true;
            int lH = GetHeight(root.left);
            int rH = GetHeight(root.right);
            return Math.Abs(lH - rH) < 2 && IsBalanced(root.left) && IsBalanced(root.right);
        }
        int GetHeight(TreeNode root)
        {
            if (root == null) return -1;
            int l = GetHeight(root.left);
            int r = GetHeight(root.right);
            return Math.Max(l, r) + 1;
        }
    }
}
