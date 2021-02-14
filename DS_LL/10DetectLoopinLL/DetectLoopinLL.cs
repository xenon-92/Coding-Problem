using System;

namespace _10DetectLoopinLL
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
            a.next = a1; a1.next = a2; a2.next = a3;
            a3.next = null; a4.next = a5; a5.next = a6;
            a6.next = a1;
            Solution s = new Solution();
            var res = s.HasCycle(a);
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
        public bool HasCycle(Node head)
        {
            if (head == null)
            {
                return false;
            }
            Node p1 = head;
            Node p2 = head;
            while (p2 != null && p2.next != null)
            {
                p1 = p1.next;
                p2 = p2.next.next;
                if (p1 == p2)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
