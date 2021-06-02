using System;
using System.Collections.Generic;

namespace P3
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
        }
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var node = TestSolution.DesignBT1();
            PrintBFS(node);
            var res = s.P3(node);
            System.Console.WriteLine(res);
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
            int outerBoundary = root.val + GetLeftSum(root.left) + GetRightSum(root.right);
            int totalSum = GetSum(root);
            return totalSum - outerBoundary == outerBoundary;
        }
        int GetLeftSum(TreeNode root)
        {
            if (root == null) return 0;
            if (root.left == null && root.right == null) return root.val;
            if (root.left != null)
            {
                return root.val + GetLeftSum(root.left);
            }
            else
            {
                return root.val + GetRightSum(root.right);
            }
        }

        int GetRightSum(TreeNode root)
        {
            if (root == null) return 0;
            if (root.left == null && root.right == null) return root.val;
            if (root.right != null)
            {
                return root.val + GetRightSum(root.right);
            }
            else
            {
                return root.val + GetRightSum(root.left);
            }
        }
        int GetSum(TreeNode root)
        {
            if (root == null) return 0;
            int l = GetSum(root.left);
            int r = GetSum(root.right);
            return l + r + root.val;
        }
    }

    class TestSolution
    {
        public static TreeNode DesignBT1()
        {
            TreeNode n1 = new TreeNode(9);
            TreeNode n2 = new TreeNode(2);
            TreeNode n3 = new TreeNode(7);
            n1.left = n2;
            n1.right = n3;
            TreeNode n4 = new TreeNode(8);
            TreeNode n5 = new TreeNode(15);
            n2.left = n4;
            n2.right = n5;
            TreeNode n6 = new TreeNode(15);
            TreeNode n7 = new TreeNode(6);
            n3.left = n6;
            n3.right = n7;
            TreeNode n8 = new TreeNode(1);
            TreeNode n9 = new TreeNode(1);
            n5.left = n8;
            n6.right = n9;
            return n1;
        }
    }
}
