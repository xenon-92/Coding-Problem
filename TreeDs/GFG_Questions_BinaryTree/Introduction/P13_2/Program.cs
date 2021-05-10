using System;

namespace P13_2
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
        // Top down approach
        /**
        One thing to notice is that if at any point it's left or right subtree is null,
        we return root.val -1.
        which in the next step will evaluate to true as
        root.val - root.val-1 == 1 (always!)
        which means that its left or right subtree is continuous.
        */
        public bool IsContinuous(TreeNode root)
        {
            if (root == null) return true;
            if (root.left == null && root.right == null) return true;
            int l = 0; int r = 0;
            if (root.left == null)
            {
                l = root.val - 1;
            }
            else
            {
                l = root.left.val;
            }
            if (root.right == null)
            {
                r = root.val - 1;
            }
            else
            {
                r = root.right.val;
            }
            return Math.Abs(root.val - l) == 1 && Math.Abs(root.val - r) == 1
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
