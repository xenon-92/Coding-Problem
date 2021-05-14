using System;

namespace _1_SearchinBST
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var find = 5;
            var res = s.SearchRecursive(TestSolution.DesignBST3(), find);
            var res1 = s.SearchRecursive(TestSolution.DesignBST3(), find);
            System.Console.WriteLine(res + " " + res1);
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
        public bool SearchRecursive(TreeNode root, int k)
        {
            if (root == null) return false;

            if (root.val == k) return true;
            else if (k < root.val)
            {
                bool left = SearchRecursive(root.left, k);
                return left;
            }
            // else if (k > root.val)
            // {
            //     bool right = SearchRecursive(root.right, k);
            //     return right;
            // }
            // return false;


            //or we can write
            else
            {
                bool right = SearchRecursive(root.right, k);
                return right;
            }
        }

        public bool SearchIterative(TreeNode root, int k)
        {
            if (root == null) return false;

            while (root != null)
            {
                if (root.val == k) return true;

                if (k < root.val)
                {
                    root = root.left;
                }
                if (k > root.val)
                {
                    root = root.right;
                }
            }
            return false;
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
    }
}
