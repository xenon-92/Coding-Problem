using System;
using System.Collections.Generic;

//date 20-04-21
namespace _11_LeetCode662_maxWidth
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
        public int GetMaxWidth(TreeNode root)
        {
            if (root == null) return 0;
            int result = 0;
            Queue<(TreeNode, int)> q = new Queue<(TreeNode, int)>();
            q.Enqueue((root, 1));
            while (q.Count != 0)
            {
                var c = q.Count;
                int l = 0; int r = 0;
                for (int i = 0; i < c; i++)
                {
                    var d = q.Dequeue();
                    if (i == 0)
                    {
                        l = d.Item2;
                        r = d.Item2;
                    }
                    else
                    {
                        r = d.Item2;
                    }
                    if (d.Item1.left != null)
                    {
                        q.Enqueue((d.Item1.left, d.Item2 * 2));
                    }
                    if (d.Item1.right != null)
                    {
                        q.Enqueue((d.Item1.right, d.Item2 * 2 + 1));
                    }
                }
                result = Math.Max(result, r - l + 1);
            }
            return result;
        }
    }
}
