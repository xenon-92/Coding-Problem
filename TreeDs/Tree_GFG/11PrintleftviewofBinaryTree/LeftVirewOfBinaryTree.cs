using System;
using System.Collections.Generic;

namespace _11PrintleftviewofBinaryTree
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
            TreeNode node5 = new TreeNode(5);
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
            s.PrintLeftView(node1);
            System.Console.WriteLine($"!!!!!!!!!!!!!!!!!!!!!");
            s.PrntLeftView(node1);
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
        //recursive solution
        public void PrintLeftView(TreeNode root)
        {
            if (root == null) return;
            Utility(root, 1);
        }
        int maxValue = 0;
        public void Utility(TreeNode root, int value)
        {
            if (root == null) return;
            if (value > maxValue)
            {
                System.Console.WriteLine(root.val);
                maxValue = value;
            }
            Utility(root.left, value + 1);
            Utility(root.right, value + 1);

        }
        //iterative solution
        public void PrntLeftView(TreeNode root)
        {
            if (root == null) return;
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count != 0)
            {
                int c = q.Count;
                for (int i = 0; i < c; i++)
                {
                    var d = q.Dequeue();
                    if (i == 0) { System.Console.WriteLine(d.val); }
                    if (d.left != null) { q.Enqueue(d.left); }
                    if (d.right != null) { q.Enqueue(d.right); }
                }
            }
        }
    }
}
