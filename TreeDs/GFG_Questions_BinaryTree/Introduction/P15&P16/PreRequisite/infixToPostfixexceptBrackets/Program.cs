using System;
using System.Collections.Generic;

namespace infixToPostfixexceptBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            string str = "A+B*C-D*E";
            var res = s.InfixToPostfix(str);
            System.Console.WriteLine(res);
        }
    }

    class Solution
    {
        public string InfixToPostfix(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return null;
            string res = string.Empty;
            Stack<char> s = new Stack<char>();
            for (int i = 0; i < str.Length; i++)
            {
                var token = str[i];
                if (IsOpearnd(token))
                {
                    res += token;
                }
                else if (IsOperator(token))
                {
                    while (s.Count > 0 && HasHigherPrecedence(s.Peek(), token))
                    {
                        res += s.Pop();
                    }
                    s.Push(token);
                }
            }
            while (s.Count != 0)
            {
                res += s.Pop();
            }
            return res;
        }

        bool IsOperator(char c)
        {
            if (c == '+' || c == '-' || c == '*' || c == '/' || c == '^')
                return true;
            return false;
        }

        bool IsOpearnd(char c)
        {
            if (c >= 'a' && c <= 'z') return true;
            if (c >= 'A' && c <= 'Z') return true;
            if (c >= '0' && c <= '9') return true;
            return false;
        }
        bool IsRightToLeft(char c)
        {
            if (c == '^') return true;
            return false;
        }
        int GetOperatorValue(char c)
        {
            if (c == '+' || c == '-') return 1;
            if (c == '*' || c == '/') return 2;
            if (c == '^') return 3;
            return -1;
        }
        bool HasHigherPrecedence(char a, char b)
        {
            int a1 = GetOperatorValue(a);
            int b1 = GetOperatorValue(b);

            if (a1 == b1)
            {
                if (IsRightToLeft(a)) return false;
                return true;
            }
            return a1 > b1 ? true : false;
        }
    }
}
