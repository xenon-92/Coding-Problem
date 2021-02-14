using System;

//def. GetMiddle: a->b->c->d    middle  = c->d
// GetMiddle:  a->b->c   middle = b
namespace _7MiddleOfLL
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
            a.next = a1; a1.next = a2; a2.next = a3; a3.next = a4; //a4.next = a5; //a5.next = a6;

            Solution s = new Solution();
            var res1 = s.GetMiddleOfLL(a);
            var res2 = s.FindMiddle(a);
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
        //Iterative
        public Node GetMiddleOfLL(Node head)
        {
            if (head == null)
            {
                return null;
            }
            int len = GetLength(head);
            int middle = len / 2;
            int counter = 0;
            while (head != null)
            {
                if (counter == middle)
                {
                    return head;
                }
                counter += 1;
                head = head.next;
            }
            return null;
        }
        public int GetLength(Node head)
        {
            if (head == null)
            {
                return 0;
            }
            return 1 + GetLength(head.next);
        }

        //2 pointer approach
        public Node FindMiddle(Node head)
        {
            if (head == null)
            {
                return null;
            }
            Node p1 = head;
            Node p2 = head;
            while (p2 != null && p2.next != null)
            {
                p1 = p1.next;
                p2 = p2.next.next;
            }
            return p1;
        }
    }
}
