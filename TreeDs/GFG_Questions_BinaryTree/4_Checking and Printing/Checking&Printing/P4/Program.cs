﻿using System;
using System.Collections.Generic;

namespace P4
{
    class Program
    {
        static void Main(string[] args)
        {

            TreeNode root = new TreeNode(3);
            TreeNode l = new TreeNode(9);
            TreeNode r = new TreeNode(20);
            TreeNode rl = new TreeNode(15);
            TreeNode rr = new TreeNode(7);

            root.left = l; root.right = r;
            r.left = rl;
            r.right = rr;

            Solution s = new Solution();
            var res = s.LevelOrder(root);
            // var res = s.P4(TestSolution.DesignBT1(), 2, 6);
            // System.Console.WriteLine(res);
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
        public bool P4(TreeNode root, int k, int l)
        {
            if (root == null) return false;
            CountLevels(root, k);
            int level_K = cntLevel;
            cntLevel = 0;
            CountLevels(root, l);
            int level_L = cntLevel;
            if (level_K != level_L) return false;
            List<int> arr = new List<int>();
            AddParent(root, k, l, arr);
            return arr[0] == arr[1] ? false : true;
        }
        int cntLevel = 0;
        TreeNode AddParent(TreeNode root, int k, int l, List<int> arr)
        {
            if (root == null) return null;
            if (root.left == null && root.right == null) return root;
            var left = AddParent(root.left, k, l, arr);
            var right = AddParent(root.right, k, l, arr);
            if (left != null && (left.val == k || left.val == l))
            {
                arr.Add(root.val);
            }
            if (right != null && (right.val == k || right.val == l))
            {
                arr.Add(root.val);
            }
            return root;
        }
        bool CountLevels(TreeNode root, int k)
        {
            if (root == null) return false;
            cntLevel += 1;
            if (root.val == k)
            {
                return true;
            }
            bool l = CountLevels(root.left, k);
            bool r = CountLevels(root.right, k);
            if (l || r) return true;
            else
            {
                cntLevel -= 1;
                return false;
            }
        }
        // rough leetcode other question
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (root == null) return res;

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            q.Enqueue(null);
            List<int> lst = new List<int>();
            while (q.Count > 1)
            {
                var d = q.Dequeue();
                if (d == null)
                {
                    q.Enqueue(null);
                    res.Add(lst);
                    lst = new List<int>();
                    continue;
                }
                lst.Add(d.val);
                if (d.left != null) q.Enqueue(d.left);
                if (d.right != null) q.Enqueue(d.right);
            }
            if (lst.Count > 0)
                res.Add(lst);
            return res;
        }
    }
    class TestSolution
    {
        public static TreeNode DesignBT1()
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
            return node1;
        }
        public static TreeNode DesignBT2()
        {

            //         1                                                   
            //        / \                                                
            //       2   3                                               
            //      /\   /\                                                
            //     4  5  6 7                                               
            //    /\       / \                                            
            //   8  9      10 11    
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
            TreeNode node9 = new TreeNode(9);
            node4.left = node8;
            node4.right = node9;
            TreeNode node10 = new TreeNode(10);
            TreeNode node11 = new TreeNode(11);
            node7.left = node10;
            node7.right = node11;
            Console.WriteLine("Full BT");
            return node1;
        }
        public static TreeNode DesignBT3()
        {

            //         1                                                   
            //        / \                                                
            //       2   3                                               
            //      /\   /\                                                
            //     4  5  6 null                                              

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
            Console.WriteLine("Complete BT");
            node3.left = node6;
            return node1;
        }
        public static TreeNode DesignBT4()
        {

            //         1                                                   
            //        / \                                                
            //       2   3                                               
            //      /\   /\                                                
            //     4  5  6 7                                               

            TreeNode node1 = new TreeNode(1);

            TreeNode node2 = new TreeNode(2);
            TreeNode node3 = new TreeNode(3);
            node1.left = node2;
            node1.right = node3;

            TreeNode node4 = new TreeNode(4);
            TreeNode node5 = new TreeNode(5);
            node2.left = node4;
            node2.right = node5;
            Console.WriteLine("Perfect BT");
            TreeNode node6 = new TreeNode(6);
            TreeNode node7 = new TreeNode(7);
            node3.left = node6;
            node3.right = node7;
            return node1;
        }
        public static TreeNode DesignBT5()
        {

            //         1                                                   
            //        / \                                                
            //       2   3                                               
            //      /                                             
            //     4                                             

            TreeNode node1 = new TreeNode(1);

            TreeNode node2 = new TreeNode(2);
            TreeNode node3 = new TreeNode(3);
            node1.left = node2;
            node1.right = node3;

            TreeNode node4 = new TreeNode(4);

            node2.left = node4;
            Console.WriteLine("Balanced binary tree");
            return node1;
        }
        public static TreeNode DesignBT6()
        {

            //         1                                                   
            //        /                                              
            //       2                                               
            //       \                                                 
            //        3
            //       /
            //      4

            TreeNode node1 = new TreeNode(1);

            TreeNode node2 = new TreeNode(2);
            TreeNode node3 = new TreeNode(3);
            node1.left = node2;
            node2.right = node3;
            TreeNode node4 = new TreeNode(4);
            node3.left = node4;
            Console.WriteLine("Degenerate BT");
            return node1;
        }
        public static TreeNode DesignBT7()
        {

            //         1                                                   
            //        /                                              
            //       2                                               
            //      /                                                 
            //     3
            //    /
            //   4

            TreeNode node1 = new TreeNode(1);

            TreeNode node2 = new TreeNode(2);
            TreeNode node3 = new TreeNode(3);
            node1.left = node2;
            node2.left = node3;
            TreeNode node4 = new TreeNode(4);
            node3.left = node4;
            return node1;
        }

        public static TreeNode DesignBT8()
        {

            //         1                                                   
            //          \                                              
            //           2                                               
            //            \                                                 
            //             3
            //              \
            //               4

            TreeNode node1 = new TreeNode(1);

            TreeNode node2 = new TreeNode(2);
            TreeNode node3 = new TreeNode(3);
            node1.right = node2;
            node2.right = node3;
            TreeNode node4 = new TreeNode(4);
            node3.right = node4;
            return node1;
        }
        public static TreeNode LC662_Test()
        {

            //         1                                                   
            //        / \                                                
            //       2   3                                               
            //      /\   /\                                                
            //     4       7                                               
            //    /\       / \                                            
            //   8           11    
            TreeNode node1 = new TreeNode(1);

            TreeNode node2 = new TreeNode(2);
            TreeNode node3 = new TreeNode(3);
            node1.left = node2;
            node1.right = node3;

            TreeNode node4 = new TreeNode(4);
            node2.left = node4;

            TreeNode node7 = new TreeNode(7);
            node3.right = node7;
            TreeNode node8 = new TreeNode(8);
            node4.left = node8;
            TreeNode node11 = new TreeNode(11);
            node7.right = node11;
            Console.WriteLine("Full BT");
            return node1;
        }
        public static TreeNode LC662_Test2()
        {

            //         1                                                   
            //        / \                                                
            //       2   3                                               
            //      /\   /\                                                
            //     4       7                                               
            //    /\       / \                                            
            //   8        10    
            TreeNode node1 = new TreeNode(1);

            TreeNode node2 = new TreeNode(2);
            TreeNode node3 = new TreeNode(3);
            node1.left = node2;
            node1.right = node3;

            TreeNode node4 = new TreeNode(4);
            node2.left = node4;

            TreeNode node7 = new TreeNode(7);
            node3.right = node7;
            TreeNode node8 = new TreeNode(8);
            node4.left = node8;
            TreeNode node10 = new TreeNode(10);
            node7.left = node10;
            Console.WriteLine("Full BT");
            return node1;
        }
    }
}
