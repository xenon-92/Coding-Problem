using System;

namespace _8DesignaLL__Leetcode707
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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
    public class MyLinkedList
    {
        int length = 0;
        Node head;
        Node tail;
        /** Initialize your data structure here. */
        public MyLinkedList()
        {
            head = null;
            tail = null;
        }

        /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
        public int Get(int index)
        {
            if (index < 0 || index >= length)
            {
                return -1;
            }
            Node current = head; int k = 0;
            while (current != null)
            {
                if (k == index)
                {
                    return current.val;
                }
                current = current.next;
                k += 1;
            }
            return -1;
        }

        /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
        public void AddAtHead(int val)
        {
            Node n = new Node(val);
            if (length <= 0)
            {
                head = n;
                tail = head;
                length += 1;
                return;
            }
            n.next = head;
            head = n;
            length += 1;
        }

        /** Append a node of value val to the last element of the linked list. */
        public void AddAtTail(int val)
        {
            Node n = new Node(val);
            if (length <= 0)
            {
                head = n;
                tail = head;
                length += 1;
                return;
            }
            tail.next = n;
            tail = tail.next;
            length += 1;
        }

        /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
        public void AddAtIndex(int index, int val)
        {
            if (index < 0 || index > length)
            {
                return;
            }
            if (index == 0)
            {
                AddAtHead(val);
                return;
            }
            if (length == index)
            {
                AddAtTail(val);
                return;
            }
            int k = 0;
            Node current = head;
            while (current != null)
            {
                if (k == index - 1)
                {
                    Node n = new Node(val);
                    n.next = current.next;
                    current.next = n;
                    length += 1;
                    break;
                }
                current = current.next;
                k += 1;
            }
        }

        /** Delete the index-th node in the linked list, if the index is valid. */
        public void DeleteAtIndex(int index)
        {
            if (index < 0 || index >= length)
            {
                return;
            }
            if (index == 0)
            {
                head = head.next;
                length -= 1;
                return;
            }
            int counter = 0;
            Node current = head;
            while (current != null && current.next != null)
            {
                if (counter == index - 1)
                {
                    Node next = current.next.next;
                    if (next == null)
                    {
                        tail = current;
                    }
                    current.next = next;
                    length -= 1;
                }
                counter += 1;
                current = current.next;
            }
        }
    }

}
