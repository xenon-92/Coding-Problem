using System;

namespace _3NthNodeFromEndOfLL
{
    /// <summary>
    /// Get Nth node from end base on 1 based index, i.e
    /// last index is 1 position
    /// </summary>
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
            var res = s.GetNthNodeFromEndIterative(a, 7);
            var res1 = s.GetNthNodeFromEndRecursive(a, 7);
            System.Console.WriteLine($"{res.val}    {res1.val}");
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
        //Iterative approach
        public Node GetNthNodeFromEndIterative(Node head, int backpos)
        {
            if (head == null || backpos < 1)
            {
                return null;
            }
            int len = GetLength(head);
            if (len - backpos < 0)
            {
                return null;
            }
            int counter = 0;
            //N position from back is equal to Length - N position from front
            while (head != null)
            {
                if (counter == (len - backpos))
                {
                    return head;
                }
                counter += 1;
                head = head.next;
            }
            return null;

        }
        private int GetLength(Node head)
        {
            if (head == null)
            {
                return 0;
            }
            return 1 + GetLength(head.next);
        }

        //recursive approach
        public Node StoreNode;
        public Node GetNthNodeFromEndRecursive(Node head, int backpos)
        {
            Utility(head, backpos);
            return StoreNode;
        }
        private int Utility(Node head, int backpos)
        {
            if (head == null)
            {
                return 0;
            }
            int k = 1 + Utility(head.next, backpos);
            if (k == backpos)
            {
                StoreNode = head;
            }
            return k;
        }
    }
}
