using System;

namespace _12_CheckIfBTisBalancedOptimal
{
    class Program
    {
        static void Main(string[] args)
        {

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
            if (UtilityBalanced(root) == -1) return false;
            return true;
        }
        int UtilityBalanced(TreeNode root)
        {
            if (root == null) return 0;
            int l = UtilityBalanced(root.left);
            if (l == -1) return -1;
            int r = UtilityBalanced(root.right);
            if (r == -1) return -1;
            if (Math.Abs(l - r) > 1)
            {
                return -1;
            }
            else
            {
                return Math.Max(l, r) + 1;
            }
        }
    }
}
