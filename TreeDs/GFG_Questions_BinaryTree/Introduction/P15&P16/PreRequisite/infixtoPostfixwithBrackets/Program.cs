using System;
using System.Collections.Generic;

namespace infixtoPostfixwithBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "(2*(5+4)-3) * (2+9)";
            Solution s = new Solution();
            var res = s.InfixToPostFix(str);
            System.Console.WriteLine(res);
        }
    }

    class Solution
    {

        public string InfixToPostFix(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return null;
            Stack<char> s = new Stack<char>();
            string res = "";
            for (int i = 0; i < str.Length; i++)
            {
                var token = str[i];
                if (IsOperand(token))
                {
                    res += token;
                }
                else if (IsOperator(token))
                {
                    while (s.Count > 0 && s.Peek() != '(' && HasHigherPrcedence(s.Peek(), token))
                    {
                        res += s.Pop();
                    }
                    s.Push(token);
                }
                else if (token == '(')
                {
                    s.Push(token);
                }
                else if (token == ')')
                {
                    while (s.Count != 0 && s.Peek() != '(')
                    {
                        res += s.Pop();
                    }
                    s.Pop();
                }
            }
            while (s.Count != 0)
            {
                res += s.Pop();
            }
            return res;
        }
        bool IsOperand(char c)
        {
            if (c >= 'a' && c <= 'z') return true;
            if (c >= 'A' && c <= 'Z') return true;
            if (c >= '0' && c <= '9') return true;
            return false;
        }
        bool IsOperator(char c)
        {
            if (c == '+' || c == '-' || c == '*' || c == '/' || c == '^') return true;
            return false;
        }
        bool IsRightToLeft(char c)
        {
            if (c == '^') return true;
            return false;
        }
        int GetTokenWeight(char c)
        {
            if (c == '+' || c == '-') return 1;
            if (c == '*' || c == '/') return 2;
            if (c == '^') return 3;
            return -1;
        }
        bool HasHigherPrcedence(char peeked, char token)
        {
            int peekedWeight = GetTokenWeight(peeked);
            int tokenWeight = GetTokenWeight(token);
            if (peekedWeight == tokenWeight)
            {
                if (IsRightToLeft(peeked)) return false;
                return true;
            }
            return peekedWeight > tokenWeight ? true : false;
        }
    }
}
