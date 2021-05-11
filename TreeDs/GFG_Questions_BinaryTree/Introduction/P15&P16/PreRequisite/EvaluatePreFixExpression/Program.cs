using System;
using System.Collections.Generic;

namespace EvaluatePreFixExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            string str = "-+*23*549";
            var res = s.EvaluatePreFix(str);
            System.Console.WriteLine(res);
        }
    }
    class Solution
    {
        public int EvaluatePreFix(string str)
        {
            Stack<int> s = new Stack<int>();
            int i = str.Length - 1;
            while (i >= 0)
            {
                if (str[i] >= 48 && str[i] <= 57)
                {
                    s.Push(str[i] - 48);
                }
                else
                {
                    var p1 = s.Pop();
                    var p2 = s.Pop();
                    int res = Utility(p1, p2, str[i]);
                    s.Push(res);

                }
                i -= 1;
            }
            return s.Pop();
        }
        int Utility(int p1, int p2, char c)
        {
            int result = 0;
            switch (c)
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
                    throw new Exception("unknown operator");

            }
            return result;
        }
    }
}
