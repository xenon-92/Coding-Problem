using System;
using System.Collections.Generic;

namespace P19
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            s.P19(TestSolution.DesignBT10());
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
        public void P19(TreeNode root)
        {
            if (root == null) return;
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            Stack<List<int>> s = new Stack<List<int>>();

            while (q.Count != 0)
            {
                var c = q.Count;
                List<int> lst = new List<int>();
                for (int i = 0; i < c; i++)
                {
                    var d = q.Dequeue();
                    if (d.left != null) q.Enqueue(d.left);
                    if (d.right != null) q.Enqueue(d.right);
                    lst.Add(d.val);
                }
                s.Push(lst);
            }

            while (s.Count != 0)
            {
                var poped = s.Pop();
                if (poped.Count == 1)
                {
                    System.Console.Write(poped[0] + " ");
                }
                else
                {
                    int i = 0; int j = poped.Count - 1;
                    while (i < j)
                    {
                        System.Console.Write(poped[i] + " " + poped[j] + " ");
                        i += 1;
                        j -= 1;
                    }
                }
            }
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
        public static TreeNode DesignBT9()
        {
            //           1
            //        /   \
            //       2       3
            //     /  \     /  \
            //    4    5    6    7
            //   / \  / \  / \  / \ 
            //  8  9 3   1 4  2 7  2
            //    /     / \    \
            //   16    17  18   19

            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(7);
            root.left.left.left = new TreeNode(8);
            root.left.left.right = new TreeNode(9);
            root.left.right.left = new TreeNode(3);
            root.left.right.right = new TreeNode(1);
            root.right.left.left = new TreeNode(4);
            root.right.left.right = new TreeNode(2);
            root.right.right.left = new TreeNode(7);
            root.right.right.right = new TreeNode(2);
            root.left.right.left.left = new TreeNode(16);
            root.left.right.left.right = new TreeNode(17);
            root.right.left.right.left = new TreeNode(18);
            root.right.right.left.right = new TreeNode(19);
            return root;
        }
        public static TreeNode DesignBT10()
        {
            var root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);

            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(7);

            root.left.left.left = new TreeNode(8);
            root.left.left.right = new TreeNode(9);
            root.left.right.left = new TreeNode(10);
            root.left.right.right = new TreeNode(11);
            root.right.left.left = new TreeNode(12);
            root.right.left.right = new TreeNode(13);
            root.right.right.left = new TreeNode(14);
            root.right.right.right = new TreeNode(15);

            root.left.left.left.left = new TreeNode(16);
            root.left.left.left.right = new TreeNode(17);
            root.left.left.right.left = new TreeNode(18);
            root.left.left.right.right = new TreeNode(19);
            root.left.right.left.left = new TreeNode(20);
            root.left.right.left.right = new TreeNode(21);
            root.left.right.right.left = new TreeNode(22);
            root.left.right.right.right = new TreeNode(23);
            root.right.left.left.left = new TreeNode(24);
            root.right.left.left.right = new TreeNode(25);
            root.right.left.right.left = new TreeNode(26);
            root.right.left.right.right = new TreeNode(27);
            root.right.right.left.left = new TreeNode(28);
            root.right.right.left.right = new TreeNode(29);
            root.right.right.right.left = new TreeNode(30);
            root.right.right.right.right = new TreeNode(31);
            return root;
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
