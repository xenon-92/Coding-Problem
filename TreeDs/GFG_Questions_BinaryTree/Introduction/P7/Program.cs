using System;
using System.Collections.Generic;

namespace P7
{
    class Program
    {
        static void BFS_Print(TreeNode root)
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
                    q.Enqueue(null);
                    System.Console.WriteLine();
                    continue;
                }
                System.Console.Write(d.val + " ");
                if (d.left != null) q.Enqueue(d.left);
                if (d.right != null) q.Enqueue(d.right);
            }
        }
        static void Main(string[] args)
        {
            Solution s = new Solution();
            // TreeNode x = new TreeNode(1);
            // x.left = new TreeNode(2);
            var res = s.DeleteinBT(TestSolution.DesignBT1(), 2);
            
            BFS_Print(res);
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
        public TreeNode DeleteinBT(TreeNode root, int k)
        {
            if (root == null) return null;
            TreeNode btm = GetBottmMostRghtNode(root);
            Traversal(root, btm, k);
            //BFS(root, btm, k);
            return root;
        }
        void BFS(TreeNode root, TreeNode btm, int k)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count != 0)
            {
                var c = q.Count;
                for (int i = 0; i < c; i++)
                {
                    var d = q.Dequeue();
                    if (d.val == k) d.val = btm.val;
                    if (d.left != null)
                    {
                        if (d.left == btm) d.left = null;
                        else q.Enqueue(d.left);
                    }
                    if (d.right != null)
                    {
                        if (d.right == btm) d.right = null;
                        else q.Enqueue(d.right);

                    }
                }
            }
        }
        void Traversal(TreeNode root, TreeNode btm, int k)
        {
            if (root == null) return;
            if (root.val == k)
            {
                root.val = btm.val;
            }
            Traversal(root.left, btm, k);
            Traversal(root.right, btm, k);
            if (root.left == btm) root.left = null;
            if (root.right == btm) root.right = null;
        }
        TreeNode GetBottmMostRghtNode(TreeNode root)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            TreeNode temp = null;
            while (q.Count != 0)
            {
                var c = q.Count;
                for (int i = 0; i < c; i++)
                {
                    var d = q.Dequeue();
                    temp = d;
                    if (d.left != null) q.Enqueue(d.left);
                    if (d.right != null) q.Enqueue(d.right);
                }
            }
            return temp;
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
