using System;
using System.Collections.Generic;

namespace _3_DeleteinBST
{
    class Program
    {

        static void BFSPrint(TreeNode root)
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
        static void Main(string[] args)
        {
            Solution s = new Solution();
            BFSPrint(TestSolution.DesignBST4());
            System.Console.WriteLine();
            var res = s.DeleteRecursive(TestSolution.DesignBST4(), 8);
            BFSPrint(res);
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
        public TreeNode DeleteRecursive(TreeNode root, int k)
        {
            if (root == null) return null;
            if (k < root.val)
            {
                root.left = DeleteRecursive(root.left, k);
            }
            else if (k > root.val)
            {
                root.right = DeleteRecursive(root.right, k);
            }
            //when the node to be deleted is found
            else
            {
                if (root.left == null)
                {
                    var temp = root.right;
                    //root = null;
                    return temp;
                }
                if (root.right == null)
                {
                    var temp = root.left;
                    //root = null;
                    return temp;
                }
                else
                {
                    TreeNode successor = GetSuccessor(root.right);
                    root.val = successor.val;
                    root.right = DeleteRecursive(root.right, successor.val);
                }
            }
            return root;
        }
        TreeNode GetSuccessor(TreeNode root)
        {
            TreeNode temp = null;
            while (root != null)
            {
                temp = root;
                root = root.left;
            }
            return temp;
        }
    }
    class TestSolution
    {
        static int idx = 0;

        /// Creates a BST from preorder traversal of BST

        static TreeNode UtilityCreateBST(int[] pre, int minval, int maxval)
        {
            if (idx > pre.Length - 1) return null;
            int nowVal = pre[idx];
            if (nowVal >= maxval || nowVal <= minval) return null;
            TreeNode root = new TreeNode(nowVal);
            idx += 1;
            root.left = UtilityCreateBST(pre, minval, nowVal);
            root.right = UtilityCreateBST(pre, nowVal, maxval);
            return root;
        }
        public static TreeNode DesignBST1()
        {
            int[] preOrder = { };
            if (preOrder == null || preOrder.Length == 0) return null;
            idx = 0;
            return UtilityCreateBST(preOrder, int.MinValue, int.MaxValue);
        }
        public static TreeNode DesignBST2()
        {
            int[] preOrder = { 8, 4, 2, 1, 3, 6, 5, 7, 12, 10, 9, 11, 14, 13, 15 };
            if (preOrder == null || preOrder.Length == 0) return null;
            idx = 0;
            return UtilityCreateBST(preOrder, int.MinValue, int.MaxValue);
        }
        public static TreeNode DesignBST3()
        {
            int[] preOrder = { 2, 1, 4, 3, 6, 5, 8, 7, 10, 9, 11 };
            if (preOrder == null || preOrder.Length == 0) return null;
            idx = 0;
            return UtilityCreateBST(preOrder, int.MinValue, int.MaxValue);
        }

        public static TreeNode DesignBST4()
        {
            int[] preOrder = { 8, 4, 2, 1, 3, 6, 5, 7, 11, 10, 9, 12, 13 };
            if (preOrder == null || preOrder.Length == 0) return null;
            idx = 0;
            return UtilityCreateBST(preOrder, int.MinValue, int.MaxValue);
        }

        public static TreeNode DesignBST5()
        {
            int[] preOrder = { 5, 4, 3, 2, 1 };
            if (preOrder == null || preOrder.Length == 0) return null;
            idx = 0;
            return UtilityCreateBST(preOrder, int.MinValue, int.MaxValue);
        }

        public static TreeNode DesignBST6()
        {
            int[] preOrder = { 1, 2, 3, 4, 5 };
            if (preOrder == null || preOrder.Length == 0) return null;
            idx = 0;
            return UtilityCreateBST(preOrder, int.MinValue, int.MaxValue);
        }
        public static TreeNode DesignBST7()
        {
            int[] preOrder = { 8, 2, 7, 3, 6, 4, 5 };
            if (preOrder == null || preOrder.Length == 0) return null;
            idx = 0;
            return UtilityCreateBST(preOrder, int.MinValue, int.MaxValue);
        }

        public static TreeNode DesignBST8()
        {
            int[] preOrder = { 4, 3, 2, 1, 5, 6, 7 };
            if (preOrder == null || preOrder.Length == 0) return null;
            idx = 0;
            return UtilityCreateBST(preOrder, int.MinValue, int.MaxValue);
        }
        public static TreeNode DesignBST9()
        {
            int[] preOrder = { 40, 30, 32, 35, 80, 90, 100, 120 };
            if (preOrder == null || preOrder.Length == 0) return null;
            idx = 0;
            return UtilityCreateBST(preOrder, int.MinValue, int.MaxValue);
        }
    }
}
