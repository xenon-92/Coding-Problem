﻿using System;
using System.Collections.Generic;

namespace _4SumofNodesinBinaryTree
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
            s.PrintBFS(node1);
            int res = s.GetTreeNodeSum(node1);
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
        public int GetTreeNodeSum(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            int left = GetTreeNodeSum(root.left);
            int right = GetTreeNodeSum(root.right);
            return root.val + left + right;
        }
        public void PrintBFS(TreeNode root)
        {
            if (root == null) return;
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            q.Enqueue(null);
            while (q.Count > 1)
            {
                var d = q.Dequeue();
                if (d == null)
                {
                    Console.WriteLine();
                    q.Enqueue(null);
                    continue;
                }
                Console.Write($"{d.val} ");
                if (d.left != null)
                {
                    q.Enqueue(d.left);
                }
                if (d.right != null)
                {
                    q.Enqueue(d.right);
                }
            }
            System.Console.WriteLine();
        }
    }
}
