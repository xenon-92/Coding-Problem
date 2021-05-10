using System;

namespace P13_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var res = s.IsContinuous(TestSolution.DesignBT1());
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
        //top down approach
        public bool IsContinuous(TreeNode root)
        {
            if (root == null) return true;
            if (root.left == null && root.right == null) return true;

            if (root.left != null)
            {
                return Math.Abs(root.val - root.left.val) == 1 && IsContinuous(root.left);
            }
            if (root.right != null)
            {
                return Math.Abs(root.val - root.right.val) == 1 && IsContinuous(root.right);
            }
            return Math.Abs(root.val - root.right.val) == 1 && Math.Abs(root.val - root.right.val) == 1
            && IsContinuous(root.left) && IsContinuous(root.right);
        }
    }
    class TestSolution
    {
        public static TreeNode DesignBT1()
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(2);
            root.right = new TreeNode(4);
            root.left.left = new TreeNode(1);
            root.left.right = new TreeNode(3);
            root.right.right = new TreeNode(5);
            return root;
        }
    }
}
