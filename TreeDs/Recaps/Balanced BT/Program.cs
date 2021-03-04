using System;

namespace Balanced_BT
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.right.left = new TreeNode(8);
            Solution s = new Solution();
            System.Console.WriteLine(s.CheckBalancedBT(root));
            System.Console.WriteLine(s.CheckBalancedBT1(root));
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
        public bool CheckBalancedBT(TreeNode root)
        {
            return UtilityCheck(root);
        }
        bool UtilityCheck(TreeNode root)
        {
            if (root == null) return true;
            int lh = GetHeight(root.left);
            int rh = GetHeight(root.right);
            if (Math.Abs(lh - rh) < 2 && UtilityCheck(root.left) && UtilityCheck(root.right)) return true;
            return false;
        }
        public int GetHeight(TreeNode root)
        {
            if (root == null) return 0;
            int left = GetHeight(root.left);
            int right = GetHeight(root.right);
            return Math.Max(left, right) + 1;
        }
        //O(n)
        public bool CheckBalancedBT1(TreeNode root)
        {
            int res = Height(root);
            return res == -1 ? false : true;
        }
        public int Height(TreeNode root)
        {
            if (root == null) return 0;
            int lft = Height(root.left);
            if (lft == -1) return -1;
            int rght = Height(root.right);
            if (rght == -1) return -1;
            if (Math.Abs(lft - rght) > 1)
            {
                return -1;
            }
            else
            {
                return Math.Max(lft, rght) + 1;
            }
        }
    }
}
