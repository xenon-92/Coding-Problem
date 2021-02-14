using System;

namespace _6MoveLLbyNplace
{
    class Program
    {
        static void Main(string[] args)
        {
            Node a = new Node(1);
            Node a1 = new Node(2);
            Node a2 = new Node(3);
            Node a3 = new Node(4);
            Node a4 = new Node(5);
            Node a5 = new Node(6);
            Node a6 = new Node(7);
            a.next = a1; a1.next = a2; a2.next = a3; a3.next = a4; a4.next = a5; a5.next = a6;

            Solution s = new Solution();
            var res = s.MoveByNplace(a, 3);
            System.Console.WriteLine(res.val);
        }
    }
    class Node
    {
        public int val;
        public Node next;
        public Node(int val)
        {
            this.val = val;
            this.next = null;
        }
    }

    class Solution
    {
        public Node MoveByNplace(Node head, int k)
        {
            if (head == null)
            {
                return null;
            }
            int i = 0;
            while (i < k)
            {
                i += 1;
                head = head.next;
            }
            return head;
        }
    }
}
