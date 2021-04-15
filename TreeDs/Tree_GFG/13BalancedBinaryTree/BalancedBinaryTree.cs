using System;


/**
def: balanced binary tree : At any  node if the difference of height of left sub tree and right sub tree is 1 or 0 then 
it is balanced sub tree else not.and this has to repeat for every node in the subtree for the entire tree to be balanced.
1-->  null node is balanced.
2--> all leaf nodes are balanced
                                           18                                 
                                          / \
                                         4   20
                                            / \
                                           13  70
below is not balanced sub tree
                                 30                       
                                / \
                               40  80
                              / \    \
                            50   70   5
                                     /
                                     6
                                    
*/
namespace _13BalancedBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode node18 = new TreeNode(18);

            TreeNode node4 = new TreeNode(4);
            TreeNode node20 = new TreeNode(20);
            node18.left = node4;
            node18.right = node20;

            TreeNode node13 = new TreeNode(13);
            TreeNode node70 = new TreeNode(70);
            node20.left = node13;
            node20.right = node70;
            TreeNode node22 = new TreeNode(22);
            node70.right = node22;
            TreeNode node33 = new TreeNode(33);
            node22.right = node33;

            Solution s = new Solution();
            bool res = s.CheckIfBinaryTreeIsBalanced(node18);
            bool res1 = s.CheckIfBinaryTreeIsBalanced1(node18);
            System.Console.WriteLine(res);
            System.Console.WriteLine(res1);

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
        // O(n2) soln
        public bool CheckIfBinaryTreeIsBalanced(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }
            int left = UtilityGetHeight(root.left);
            int right = UtilityGetHeight(root.right);
            return Math.Abs(left - right) < 2 && CheckIfBinaryTreeIsBalanced(root.left) && CheckIfBinaryTreeIsBalanced(root.right);

        }
        int UtilityGetHeight(TreeNode root)
        {
            if (root == null)
            {
                return -1;
            }
            int left = UtilityGetHeight(root.left);
            int right = UtilityGetHeight(root.right);
            return Math.Max(left, right) + 1;
        }


        // O(n) solution
        // The idea is that we calculate the height of left and right subtree and while calculating the height we 
        // also check if the subtree is balanced or not
        // if not balanced we retun -1, determining it is not balanced.
        public bool CheckIfBinaryTreeIsBalanced1(TreeNode root)
        {
            int ans = CheckForBalance(root);
            if (ans == -1)
            {
                return false;
            }
            return true;
        }
        int CheckForBalance(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            int left = CheckForBalance(root.left);
            if (left == -1) { return -1; }
            int right = CheckForBalance(root.right);
            if (right == -1) { return -1; }
            if (Math.Abs(left - right) > 1)
            {
                return -1;
            }
            else
            {
                return Math.Max(left, right) + 1;
            }
        }
    }
}
