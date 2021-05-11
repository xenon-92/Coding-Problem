using System;
using System.Collections.Generic;

namespace EvaluatePostFixExprsn
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "23*54*+9-";
            Solution s = new Solution();
            var res = s.EvaluatePostFix(str);
            System.Console.WriteLine(res);
        }
    }
    class Solution
    {
        public int EvaluatePostFix(string str)
        {
            Stack<int> s = new Stack<int>();
            int i = 0;
            while (i < str.Length)
            {
                if (str[i] >= 48 && str[i] <= 57)
                {
                    s.Push(str[i] - 48);
                }
                else
                {
                    var p2 = s.Pop();
                    var p1 = s.Pop();
                    int res = EvaluateExpression(p1, p2, str[i]);
                    s.Push(res);
                }
                i += 1;
            }
            return s.Pop();
        }

        int EvaluateExpression(int p1, int p2, char token)
        {
            int result = 0;
            switch (token)
            {
                case '*':
                    result = p1 * p2;
                    break;
                case '/':
                    result = p1 / p2;
                    break;
                case '+':
                    result = p1 + p2;
                    break;
                case '-':
                    result = p1 - p2;
                    break;
                default:
                    throw new Exception("invalid operator");

            }
            return result;
        }
    }
}
