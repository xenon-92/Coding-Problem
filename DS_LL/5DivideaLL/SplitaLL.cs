using System;
//divide a LL in two equal halves
// ex: a->b->c->d  then a->b   and c->d
// ex: a->b->c->d->e  then a->b and c->d->e
namespace _5DivideaLL
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
            a.next = a1; a1.next = a2; //a2.next = a3; a3.next = a4; a4.next = a5; //a5.next = a6;
            Solution s = new Solution();
            var res = s.SplitLL(a);
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
        public Node[] SplitLL(Node head)
        {
            if (head == null)
            {
                return null;
            }
            Node p1 = head;
            Node p2 = head;
            Node temp = null;
            while (p2 != null && p2.next != null)
            {
                temp = p1;
                p1 = p1.next;
                p2 = p2.next.next;
            }
            temp.next = null;
            return new[] { head, p1 };
        }
    }
}
