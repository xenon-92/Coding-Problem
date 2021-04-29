using System;
using System.Collections.Generic;

namespace GFG_7_deletion_in_BT
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
        public TreeNode DeleteNode(TreeNode root, int targetValue)
        {
            if (root == null) return null;
            TreeNode dummy = new TreeNode(-1);
            dummy.right = root;

            TreeNode temp = dummy;
            TreeNode preTemp = null;
            while (temp.right != null)
            {
                preTemp = temp;
                temp = temp.right;
            }
            preTemp.right = null;
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count != 0)
            {
                var d = q.Dequeue();
                if (d.val == targetValue)
                {
                    d.val = temp.val;
                    break;
                }
                if (d.left != null)
                {
                    q.Enqueue(d.left);
                }
                if (d.right != null)
                {
                    q.Enqueue(d.right);
                }
            }
            return root;
        }
    }
}
