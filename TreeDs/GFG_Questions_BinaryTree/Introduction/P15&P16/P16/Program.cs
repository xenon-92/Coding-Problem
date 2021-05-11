using System;
using System.Collections.Generic;

namespace P16
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new TreeNode('+');
            root.left = new TreeNode('*');
            root.left.left = new TreeNode('5');
            root.left.right = new TreeNode('4');
            root.right = new TreeNode('-');
            root.right.left = new TreeNode('8');
            root.right.right = new TreeNode('2');

            Solution s = new Solution();
            int res = s.Conversion(root);
            System.Console.WriteLine(res);

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
        public int Conversion(TreeNode exprsnTree)
        {

            PostFix(exprsnTree);
            string str = postfix;
            Stack<int> s = new Stack<int>();
            int i = 0;
            while (i < str.Length)
            {
                var token = str[i];
                if (token >= 48 && token <= 57)
                {
                    s.Push(token - '0');
                }
                else
                {
                    var p2 = s.Pop();
                    var p1 = s.Pop();
                    int res = GetVal(p1, p2, token);
                    s.Push(res);
                }
                i += 1;
            }
            return s.Pop();

        }
        string postfix = "";
        void PostFix(TreeNode root)
        {
            if (root == null) return;
            PostFix(root.left);
            PostFix(root.right);
            postfix += root.val;
        }
        int GetVal(int a, int b, char token)
        {
            int resul = -1;
            switch (token)
            {
                case '+':
                    resul = a + b;
                    break;
                case '-':
                    resul = a - b;
                    break;
                case '*':
                    resul = a * b;
                    break;
                case '/':
                    resul = a / b;
                    break;

                default:
                    throw new Exception("invalid");
            }
            return resul;
        }
    }
}
