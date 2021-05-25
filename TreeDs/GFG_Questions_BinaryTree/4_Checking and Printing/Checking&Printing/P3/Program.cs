using System;

namespace P3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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
        public bool P3(TreeNode root)
        {
            if (root == null) return false;
            var temp1 = root; var temp2 = root;
            int outerSum = root.val + GetLeftSum(temp1.left) + GetRightSum(temp2.right);
            int innerSum = GetSum(root) - outerSum;
            if (outerSum == innerSum) return true;
            return false;
        }
        int GetLeftSum(TreeNode root)
        {
            int sum = 0;
            while (root != null)
            {
                sum += root.val;
                root = root.left;
            }
            return sum;
        }

        int GetRightSum(TreeNode root)
        {
            int sum = 0;
            while (root != null)
            {
                sum += root.val;
                root = root.right;
            }
            return sum;
        }
        int GetSum(TreeNode root)
        {
            if (root == null) return 0;
            int l = GetSum(root.left);
            int r = GetSum(root.left);
            return l + r + root.val;
        }
    }
}
