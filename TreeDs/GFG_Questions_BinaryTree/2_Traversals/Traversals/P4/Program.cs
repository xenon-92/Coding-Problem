using System;
using System.Collections.Generic;

namespace P4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] preorder = { 1, 2, 4, 5, 3, 6 };
            int[] inorder = { 4, 2, 5, 1, 3, 6 };
            int[] postorder = { 4, 5, 2, 6, 3, 1 };

            Solution s = new Solution();
            //s.PrintPostOrder(postorder, inorder);
            Solution1 s1 = new Solution1();
            s1.PrintPreOrder(postorder, inorder);

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
        public void PrintPostOrder(int[] preorder, int[] inorder)
        {
            gIdx = 0;
            if (preorder == null || inorder == null || preorder.Length != inorder.Length)
            {
                return;
            }
            UtilityPrintPostOrder(preorder, inorder, 0, inorder.Length - 1);
        }
        int gIdx = 0;
        void UtilityPrintPostOrder(int[] preorder, int[] inorder, int iStart, int iEnd)
        {
            if (iStart > iEnd) return;
            int value = preorder[gIdx];
            gIdx += 1;
            int idx = 0;
            for (int i = iStart; i <= iEnd; i++)
            {
                if (inorder[i] == value)
                {
                    idx = i;
                    break;
                }
            }
            UtilityPrintPostOrder(preorder, inorder, iStart, idx - 1);
            UtilityPrintPostOrder(preorder, inorder, idx + 1, iEnd);
            System.Console.Write(value + " ");
        }
    }

    // to print postorder from postorder and inorder we need to create a tree.
    // without creating a tree, it is not possible to write down the node values as 
    // the right subtree is created first
    class Solution1
    {
        public void PrintPreOrder(int[] postorder, int[] inorder)
        {
            if (postorder == null || inorder == null || postorder.Length != inorder.Length) return;
            Dictionary<int, int> kvp = new Dictionary<int, int>();
            //storing in hashmap due to avoid running for loop in the above section for each recursion stack
            for (int i = 0; i < inorder.Length; i++)
            {
                kvp.Add(inorder[i], i);
            }
            gidx = postorder.Length - 1;
            TreeNode getTree = ConstructTree(postorder, inorder, 0, inorder.Length - 1, kvp);
            PrintPreOrder(getTree);

        }
        int gidx = 0;
        TreeNode ConstructTree(int[] postorder, int[] inorder, int iStart, int iEnd, Dictionary<int, int> kvp)
        {
            if (iStart > iEnd) return null;
            TreeNode root = new TreeNode(postorder[gidx--]);
            int idx = kvp[root.val];
            root.right = ConstructTree(postorder, inorder, idx + 1, iEnd, kvp);
            root.left = ConstructTree(postorder, inorder, iStart, idx - 1, kvp);
            return root;
        }
        void PrintPreOrder(TreeNode root)
        {
            if (root == null) return;
            Stack<TreeNode> s = new Stack<TreeNode>();
            var temp = root;
            while (temp != null || s.Count != 0)
            {
                while (temp != null)
                {
                    System.Console.Write(temp.val + " ");
                    s.Push(temp);
                    temp = temp.left;
                }
                var poped = s.Pop();
                temp = poped.right;
            }
        }
    }
}
