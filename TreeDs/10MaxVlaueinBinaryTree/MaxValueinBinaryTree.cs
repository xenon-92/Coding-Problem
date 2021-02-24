using System;

namespace _10MaxVlaueinBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            //         1
            //        / \                                                
            //       2   3                                               
            //      /\   /\                                                
            //     4  5  6 7                                               
            //              \                                            
            //               8
            //               /\                            
            //              9  10

            TreeNode node1 = new TreeNode(1);

            TreeNode node2 = new TreeNode(2);
            TreeNode node3 = new TreeNode(3);
            node1.left = node2;
            node1.right = node3;

            TreeNode node4 = new TreeNode(4);
            TreeNode node5 = new TreeNode(555);
            node2.left = node4;
            node2.right = node5;

            TreeNode node6 = new TreeNode(6);
            TreeNode node7 = new TreeNode(7);
            node3.left = node6;
            node3.right = node7;

            TreeNode node8 = new TreeNode(8);
            node7.right = node8;

            TreeNode node9 = new TreeNode(9);
            TreeNode node10 = new TreeNode(10);
            node8.left = node9;
            node8.right = node10;
            Solution s = new Solution();
            var res = s.GetMaxValue(node1);
            var res1 = s.GetMaxValue1(node1);
            System.Console.WriteLine(res);
            System.Console.WriteLine(res1);
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
        int max = int.MinValue;
        public int GetMaxValue(TreeNode root)
        {
            Utility(root);
            return max;
        }
        private void Utility(TreeNode root)
        {
            if (root == null) return;
            max = Math.Max(max, root.val);
            Utility(root.left);
            Utility(root.right);
        }
        public int GetMaxValue1(TreeNode root)
        {
            if (root == null) { return int.MinValue; }
            int left = GetMaxValue1(root.left);
            int right = GetMaxValue1(root.right);
            return Math.Max(root.val, Math.Max(left, right));
        }
    }
}
