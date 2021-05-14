using System;
using System.Collections.Generic;

namespace _2_InsertinBST
{
    class Program
    {

        static void PrintBFS(TreeNode root)
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
            System.Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var res = s.InsertRecursive(TestSolution.DesignBST9(), 32);
            var res1 = s.InsertIterative(TestSolution.DesignBST9(), 41);
            PrintBFS(res);
            System.Console.WriteLine();
            PrintBFS(res1);

            //System.Console.WriteLine(res?.val);
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

        // In BST insertion always happens at Leaf node
        public TreeNode InsertRecursive(TreeNode root, int k)
        {
            if (root == null) return new TreeNode(k);
            if (root.val == k)
            {
                return root;
            }
            else if (k < root.val)
            {
                root.left = InsertRecursive(root.left, k);
            }
            else
            {
                root.right = InsertRecursive(root.right, k);
            }
            return root;
        }

        public TreeNode InsertIterative(TreeNode root, int k)
        {
            if (root == null) return new TreeNode(k);
            TreeNode curr = root; TreeNode temp = null;
            while (curr != null)
            {
                temp = curr;
                if (curr.val == k) return root;

                if (k < curr.val)
                {
                    curr = curr.left;
                }
                else
                {
                    curr = curr.right;
                }
            }

            if (k < temp.val)
            {
                temp.left = new TreeNode(k);
            }
            else
            {
                temp.right = new TreeNode(k);
            }
            return root;

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
