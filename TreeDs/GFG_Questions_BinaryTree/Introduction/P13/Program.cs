using System;

namespace P13
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
        //Bottoms up approach
        public bool IsContinuous(TreeNode root)
        {
            return Utility(root) == -1 ? false : true;
        }
        int Utility(TreeNode root)
        {
            if (root == null) return 0;

            int l = Utility(root.left);
            if (l == -1) return -1;
            int r = Utility(root.right);
            if (r == -1) return -1;
            if (l == 0 && r == 0)
            {
                return root.val;
            }
            if (l == 0 && r != 0)
            {
                return Math.Abs(root.val - r) == 1 ? root.val : -1;
            }
            if (l != 0 && r == 0)
            {
                return Math.Abs(root.val - l) == 1 ? root.val : -1;
            }
            if (Math.Abs(root.val - l) == 1 && Math.Abs(root.val - r) == 1)
            {
                return root.val;
            }
            else
            {
                return -1;
            }

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
