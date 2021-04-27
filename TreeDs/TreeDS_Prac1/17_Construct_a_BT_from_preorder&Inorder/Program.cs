using System;
using System.Collections.Generic;

namespace _17_Construct_a_BT_from_preorder_Inorder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] preOrder = { 1, 2, 4, 5, 3, 6, 7, 8, 9, 10 };
            int[] inOrder = { 4, 2, 5, 1, 6, 3, 7, 9, 8, 10 };
            Solution s = new Solution();
            TreeNode res = s.BuidTree(preOrder, inOrder);
            PrintBTlinebyLine(res);
        }
        static void PrintBTlinebyLine(TreeNode root)
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
        public TreeNode BuidTree(int[] preOrder, int[] inOrder)
        {
            if (preOrder.Length != inOrder.Length) return null;
            return UtilityBuild(preOrder, inOrder, 0, inOrder.Length - 1);
        }
        int preOrderIndex = 0;
        TreeNode UtilityBuild(int[] preOrder, int[] inOrder, int iS, int iE)
        {
            if (iS > iE) return null;
            TreeNode root = new TreeNode(preOrder[preOrderIndex]);
            preOrderIndex += 1;

            int idx = 0;
            for (int i = iS; i <= iE; i++)
            {
                if (inOrder[i] == root.val)
                {
                    idx = i;
                    break;
                }
            }
            root.left = UtilityBuild(preOrder, inOrder, iS, idx - 1);
            root.right = UtilityBuild(preOrder, inOrder, idx + 1, iE);
            return root;
        }
    }
}
