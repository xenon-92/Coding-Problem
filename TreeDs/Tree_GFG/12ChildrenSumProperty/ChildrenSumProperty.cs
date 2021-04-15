using System;

namespace _12ChildrenSumProperty
{
    class Program
    {
        static void Main(string[] args)
        {
            //case
            //        20                                               
            //       /  \                                            
            //      8    12                                           
            //     / \                                                
            //    3   5                                               
            //      op--> true                                                
            // TreeNode node1 = new TreeNode(20);

            // TreeNode node2 = new TreeNode(8);
            // TreeNode node3 = new TreeNode(12);
            // node1.left = node2;
            // node1.right = node3;

            // TreeNode node4 = new TreeNode(3);
            // TreeNode node5 = new TreeNode(5);
            // node2.left = node4;
            // node2.right = node5;
            //******************************************************
            //case
            //        20                                               
            //       /  \                                            
            //      8    12                                           
            //     / \                                                
            //    3   6                                               
            //      op--> false   
            TreeNode node1 = new TreeNode(20);

            TreeNode node2 = new TreeNode(8);
            TreeNode node3 = new TreeNode(12);
            node1.left = node2;
            node1.right = node3;

            TreeNode node4 = new TreeNode(3);
            TreeNode node5 = new TreeNode(6);
            node2.left = node4;
            node2.right = node5;
            Solution s = new Solution();
            bool res = s.IsChildrenSum(node1);
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
        public bool IsChildrenSum(TreeNode root)
        {
            if (root == null) return true;
            if (root.left == null && root.right == null) return true;
            int sum = 0;
            if (root.left != null) { sum += root.left.val; }
            if (root.right != null) { sum += root.right.val; }
            return root.val == sum && IsChildrenSum(root.left) && IsChildrenSum(root.right);
        }
    }
}
