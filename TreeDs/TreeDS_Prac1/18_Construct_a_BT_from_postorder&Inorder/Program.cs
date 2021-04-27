using System;
using System.Collections.Generic;

namespace _18_Construct_a_BT_from_postorder_Inorder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inOrder = { 8, 4, 9, 2, 5, 1, 6, 3, 10, 7, 11 };
            int[] postOrder = { 8, 9, 4, 5, 2, 6, 10, 11, 7, 3, 1 };

            Solution s = new Solution();
            var res = s.BuildTree(inOrder, postOrder);
            PrintBFS(res);

        }
        static void PrintBFS(TreeNode root)
        {
            if (root == null) return;
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count != 0)
            {
                var c = q.Count;
                for (int i = 0; i < c; i++)
                {
                    var d = q.Dequeue();
                    System.Console.Write(d.val + " ");
                    if (d.left != null) q.Enqueue(d.left);
                    if (d.right != null) q.Enqueue(d.right);
                }
                System.Console.WriteLine();
            }
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
        int postIndx = 0;
        public TreeNode BuildTree(int[] inOrder, int[] postOrder)
        {
            if (postOrder.Length != inOrder.Length) return null;
            postIndx = postOrder.Length - 1;
            return UtilityBuildTree(inOrder, postOrder, 0, postOrder.Length - 1);
        }

        private TreeNode UtilityBuildTree(int[] inOrder, int[] postOrder, int iS, int iE)
        {
            if (iS > iE) return null;
            TreeNode root = new TreeNode(postOrder[postIndx]);
            postIndx -= 1;
            int idx = 0;
            for (int i = iS; i <= iE; i++)
            {
                if (inOrder[i] == root.val)
                {
                    idx = i;
                    break;
                }
            }

            root.right = UtilityBuildTree(inOrder, postOrder, idx + 1, iE);
            root.left = UtilityBuildTree(inOrder, postOrder, iS, idx - 1);
            return root;
        }
    }
}
