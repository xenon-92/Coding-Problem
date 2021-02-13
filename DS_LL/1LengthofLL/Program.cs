using System;

namespace _1LengthofLL
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
      System.Console.WriteLine(s.GetLength(a));
      System.Console.WriteLine(s.GetLengthRecursive(a));
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
    // iterative approach
    public int GetLength(Node head)
    {
      if (head == null)
      {
        return 0;
      }
      int count = 0;
      while (head != null)
      {
        count += 1;
        head = head.next;
      }
      return count;
    }
    // recursive approach
    public int GetLengthRecursive(Node head)
    {
      if (head == null)
      {
        return 0;
      }
      return 1 + GetLengthRecursive(head.next);
    }
  }


}
