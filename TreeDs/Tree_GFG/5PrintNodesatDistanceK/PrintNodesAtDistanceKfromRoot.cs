using System;


//ref : https://www.geeksforgeeks.org/print-nodes-at-k-distance-from-root/
namespace _5PrintNodesatDistanceK
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
            s.PrintNodesAtDistanceKfromRoot1(node1, 2);
            s.PrintNodesAtDistanceKfromRoot2(node1, 2);
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
        public void PrintNodesAtDistanceKfromRoot1(TreeNode root, int k)
        {

            Utility(root, k, 0);
        }
        private void Utility(TreeNode root, int k, int j)
        {
            if (root == null) return;
            if (k == j)
            {
                System.Console.WriteLine(root.val);
            }
            Utility(root.left, k, j + 1);
            Utility(root.right, k, j + 1);
        }
        public void PrintNodesAtDistanceKfromRoot2(TreeNode root, int k)
        {
            if (root == null) return;
            if (k == 0)
            {
                System.Console.WriteLine(root.val);
            }
            PrintNodesAtDistanceKfromRoot2(root.right, k - 1);
            PrintNodesAtDistanceKfromRoot2(root.left, k - 1);

        }
    }
}
