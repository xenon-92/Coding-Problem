using System;

namespace P1
{
    class Program
    {
        static void Main(string[] args)
        {
            var parm = TestSolution.DesignBT1();
            Solution s = new Solution();
            System.Console.WriteLine(s.P1(parm) + " " + s.P1_1(parm));
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
        //top bottom approach
        public bool P1(TreeNode root)
        {
            if (root == null) return true;
            if (root.left == null && root.right == null) return true;//it is required for leaf nodes
            int sum = 0;
            if (root.left != null) sum += root.left.val;
            if (root.right != null) sum += root.right.val;
            return sum == root.val && P1(root.left) && P1(root.right);
        }

        public bool P1_1(TreeNode root)
        {
            return Utility(root) == -1 ? false : true;
        }
        //bottoms up approach
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
            else
            {
                return root.val == l + r ? root.val : -1;
            }
        }
    }
    class TestSolution
    {
        public static TreeNode DesignBT1()
        {
            var root = new TreeNode(10);
            root.left = new TreeNode(8);
            root.right = new TreeNode(2);
            root.left.left = new TreeNode(3);
            root.left.right = new TreeNode(5);
            root.right.right = new TreeNode(2);
            return root;
        }
    }
}
