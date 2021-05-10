using System;

namespace P9
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var res = s.BTtoArray(null);
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
        public int[] BTtoArray(TreeNode root)
        {
            if (root == null) return null;
            int h = GetHeight(root);
            //max number of nodes for a BT of height h is equal to Math.Pow(2,h)-1;
            int[] arr = new int[(int)Math.Pow(2, h) - 1];
            CaptureValues(root, arr, 0);
            return arr;
        }
        void CaptureValues(TreeNode root, int[] arr, int idx)
        {
            if (root == null) return;
            arr[idx] = root.val;
            CaptureValues(root, arr, 2 * idx + 1);
            CaptureValues(root, arr, 2 * idx + 2);
        }
        int GetHeight(TreeNode root)
        {
            if (root == null) return 0;
            int l = GetHeight(root.left);
            int r = GetHeight(root.right);
            return Math.Max(l, r) + 1;
        }
    }
}
