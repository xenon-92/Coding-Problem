using System;

namespace P17
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(2);
            root.left.left = new TreeNode(3);
            root.left.right = new TreeNode(4);
            root.right.left = new TreeNode(4);
            root.right.right = new TreeNode(3);

            Solution s = new Solution();
            var res = s.IsSymmetric(root);
            System.Console.WriteLine(res);
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
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;
            return Utility(root.left, root.right);
        }
        bool Utility(TreeNode a, TreeNode b)
        {
            if (a == null && b == null) return true;
            if (a == null || b == null) return false;
            return (a.val == b.val) && Utility(a.left, b.right) && Utility(a.right, b.left);
        }
    }


}
