using System;
using System.Collections.Generic;

namespace AVL_tree_insertion
{
    class Program
    {
        static void PrintBFS(TreeNode root)
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
                    if (d.left != null) q.Enqueue(d.left);
                    if (d.right != null) q.Enqueue(d.right);
                    System.Console.Write(d.val + " ");
                }
                System.Console.WriteLine();
            }

        }
        static void Main(string[] args)
        {
            Solution s = new Solution();
            for (int i = 0; i < 11; i++)
            {
                s.Insert(i);
            }
            PrintBFS(s.root);
            System.Console.WriteLine("********");
            System.Console.WriteLine(s.nodeCount);
        }
    }

    class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public int bf;
        public int height;
        public TreeNode(int val)
        {
            this.val = val;
        }
    }

    class Solution
    {
        public TreeNode root; public int nodeCount = 0;
        public bool Insert(int val)
        {
            root = UtilityInsert(root, val);
            if (root != null)
            {
                nodeCount += 1;
                return true;
            }
            return false;
        }
        TreeNode UtilityInsert(TreeNode root, int k)
        {
            if (root == null) return new TreeNode(k);
            if (root.val < k)
            {
                root.right = UtilityInsert(root.right, k);
            }
            if (root.val > k)
            {
                root.left = UtilityInsert(root.left, k);
            }
            Update(root);
            return Balance(root);
        }
        void Update(TreeNode root)
        {
            int left = root.left == null ? -1 : root.left.height;
            int right = root.right == null ? -1 : root.right.height;
            root.height = Math.Max(left, right) + 1;
            root.bf = right - left;
        }

        TreeNode Balance(TreeNode root)
        {
            //left heavy === right rotation
            // case1: left left case
            //case2: left right case
            if (root.bf == -2)
            {
                if (root.left.bf <= 0)
                {
                    //left left case
                    return LeftLeftCase(root);
                }
                else
                {
                    //left right case
                    return LeftRightCase(root);
                }
            }
            //right heavy  === left rotation
            // case1: right right case
            //case2: right left case
            else if (root.bf == 2)
            {
                if (root.right.bf >= 0)
                {
                    //right right case
                    return RightRightCase(root);
                }
                else
                {
                    //right left case
                    return RightLeftCase(root);
                }
            }
            //if root.bf = -1,0,1
            return root;
        }
        TreeNode LeftLeftCase(TreeNode root)
        {
            return RotateRight(root);
        }
        TreeNode LeftRightCase(TreeNode root)
        {
            root.left = RotateLeft(root.left);
            return RotateRight(root);
        }
        TreeNode RightRightCase(TreeNode root)
        {
            return RotateLeft(root);
        }
        TreeNode RightLeftCase(TreeNode root)
        {
            root.right = RotateRight(root.right);
            return RotateLeft(root);
        }
        TreeNode RotateRight(TreeNode A)
        {
            var b = A.left;
            A.left = b.right;
            b.right = A;
            Update(A);
            Update(b);
            return b;
        }

        TreeNode RotateLeft(TreeNode B)
        {
            var a = B.right;
            B.right = a.left;
            a.left = B;
            Update(B);
            Update(a);
            return a;
        }

    }
}
