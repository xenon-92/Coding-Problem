using System;

namespace _11breakCycleinLL
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
            a.next = a; a1.next = a2; a2.next = a3;
            a3.next = a4; a4.next = a5; a5.next = a6;
            a6.next = a;
            Solution s = new Solution();
            s.BreakCycle(a);
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
        public Node p1;
        public Node p2;
        public void BreakCycle(Node head)
        {
            if (head == null)
            {
                return;
            }
            bool flag = HasCycle(head);
            if (!flag)
            {
                return;
            }
            p1 = head;
            while (p1 != p2)
            {
                p1 = p1.next;
                p2 = p2.next;
            }
            // After this both sit at the starting point of the loop
            p1 = p1.next;
            while (p1.next != p2)
            {
                p1 = p1.next;
            }
            p1.next = null;
        }
        private bool HasCycle(Node head)
        {
            p1 = head;
            p2 = head;
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
