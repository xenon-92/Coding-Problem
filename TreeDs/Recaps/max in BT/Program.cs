using System;

namespace max_in_BT
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var res1 = s.FindMax(TestSolution.DesignBT5());
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
        public int FindMax(TreeNode root)
        {
            //return Utility1(root);
            Utility2(root);
            System.Console.WriteLine("Sooner or later you are going to die");
            return max;
        }
        int Utility1(TreeNode root)
        {
            if (root == null) return int.MinValue;
            int left = Utility1(root.left);
            int right = Utility1(root.right);
            return Math.Max(left, Math.Max(right, root.val));
        }
        int max = int.MinValue;
        void Utility2(TreeNode root)
        {
            if (root == null) return;
            else
            {
                max = Math.Max(max, root.val);
                Utility2(root.left);
                Utility2(root.right);
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

            TreeNode node1 = new TreeNode(1234);

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
    }
}
