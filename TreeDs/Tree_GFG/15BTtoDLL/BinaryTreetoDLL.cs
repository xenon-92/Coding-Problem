using System;
//https://www.geeksforgeeks.org/convert-given-binary-tree-doubly-linked-list-set-3/
/**
INORDER TRAVERSAL IS DONE, AND WHILE TRAVELLING WE KEEP THE PREVIOUS POINTER FOR REFERING
Head node refernce id kept by head variable in the if condition
HERE THE DOUBLY Linked List next equals right and that of prev equals left
*/
namespace _15BTtoDLL
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(10);
            root.left = new TreeNode(12);
            root.right = new TreeNode(15);
            root.left.left = new TreeNode(25);
            root.left.right = new TreeNode(30);
            root.right.left = new TreeNode(36);
            Solution s = new Solution();
            var res = s.ConvertBTtoLL(root);
        }
    }

    class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val)
        {
            this.val = val;
        }
    }

    class Solution
    {
        TreeNode head;
        TreeNode prev;
        private void UtilityBTtoLL(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            UtilityBTtoLL(root.left);
            if (prev == null)
            {
                head = root;
            }
            else
            {
                root.left = prev;
                prev.right = root;
            }
            prev = root;
            UtilityBTtoLL(root.right);
        }
        public TreeNode ConvertBTtoLL(TreeNode root)
        {
            UtilityBTtoLL(root);
            return head;
        }
    }
}
