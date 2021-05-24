using System;

namespace P2
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var res = s.isSumTree(TestSolution.DesignBT2());
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
        public bool isSumTree(TreeNode root)
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

            if (l == 0 && r == 0) return root.val;
            else
            {
                if (l + r == root.val)
                {
                    return 2 * root.val;
                }
                else return -1;
            }
        }
    }

    class TestSolution
    {
        public static TreeNode DesignBT2()
        {
            var root = new TreeNode(26);
            root.left = new TreeNode(10);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(6);
            root.right.right = new TreeNode(3);
            return root;
        }
    }
}
