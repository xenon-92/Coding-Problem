using System;
using System.Collections.Generic;

namespace P15_ConstructTreeFromPostFixExpression
{
    class Program
    {
        static void PrintInOrder(TreeNode root)
        {
            if (root == null) return;
            PrintInOrder(root.left);
            System.Console.Write(root.val + " ");
            PrintInOrder(root.right);
        }
        static void Main(string[] args)
        {
            Solution s = new Solution();
            string str = "ab+ef*g*-";
            var res = s.ConstructTreeFromPostfixExpression(str);
            PrintInOrder(res);
        }
    }

    class TreeNode
    {
        public char val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(char val)
        {
            this.val = val;
        }
    }
    class Solution
    {
        public TreeNode ConstructTreeFromPostfixExpression(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return null;
            Stack<TreeNode> s = new Stack<TreeNode>();
            for (int i = 0; i < str.Length; i++)
            {
                var token = str[i];
                if (IsOperator(token))
                {
                    TreeNode root = new TreeNode(token);
                    TreeNode right = s.Pop();
                    TreeNode left = s.Pop();
                    root.left = left;
                    root.right = right;
                    s.Push(root);
                }
                else
                {
                    TreeNode root = new TreeNode(token);
                    s.Push(root);
                }
            }
            return s.Pop();

        }
        bool IsOperator(char c)
        {
            if (c == '+' || c == '-' || c == '*' || c == '/' || c == '^') return true;
            return false;
        }
    }
}
