using System;

namespace _10_MaxWidthofBT_PreOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int m = s.GetMaxWidth(TestSolution.DesignBT8());
            System.Console.WriteLine(m);
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
        public int GetMaxWidth(TreeNode root)
        {
            if (root == null) return 0;
            int h = GetHeightofBT(root);
            int[] count = new int[h];
            GetWidthRecursive(root, count, 0);
            int max = count[0];
            for (int i = 1; i < count.Length; i++)
            {
                max = Math.Max(max, count[i]);
            }
            return max;

        }
        void GetWidthRecursive(TreeNode root, int[] count, int level)
        {
            if (root == null) return;
            count[level] = count[level] + 1;
            GetWidthRecursive(root.left, count, level + 1);
            GetWidthRecursive(root.right, count, level + 1);
        }
        int GetHeightofBT(TreeNode root)
        {
            if (root == null) return 0;
            int left = GetHeightofBT(root.left);
            int right = GetHeightofBT(root.right);
            return Math.Max(left, right) + 1;
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
    }
}
