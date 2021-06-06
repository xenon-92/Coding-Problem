using System;
using System.Collections.Generic;

namespace ConstructSelfBalancingBST
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Solution s = new Solution();
            var node = s.CreateSelfBalancingBST(arr);
            s.PrintBFS(node);
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
        public TreeNode CreateSelfBalancingBST(int[] arr)
        {
            if (arr == null || arr.Length == 0) return null;
            return Utility(arr, 0, arr.Length - 1);
        }
        TreeNode Utility(int[] arr, int l, int r)
        {
            if (l > r) return null;
            int mid = (l + r) / 2;
            TreeNode root = new TreeNode(arr[mid]);
            root.left = Utility(arr, l, mid - 1);
            root.right = Utility(arr, mid + 1, r);
            return root;
        }
        public void PrintBFS(TreeNode root)
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
                if (d.left != null) q.Enqueue(d.left);
                if (d.right != null) q.Enqueue(d.right);
                System.Console.Write(d.val + " ");
            }

        }
    }
}
