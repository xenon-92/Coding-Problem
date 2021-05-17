using System;
using System.Collections.Generic;

namespace _6ConstructaSelfBSTfromBST
{
    class Program
    {
        static void PrintBFS(TreeNode root)
        {
            if (root == null) return;
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            q.Enqueue(null);
            while (q.Count > 1)
            {
                var d = q.Dequeue();
                if (d == null)
                {
                    q.Enqueue(null);
                    System.Console.WriteLine();
                    continue;
                }
                System.Console.Write(d.val + " ");
                if (d.left != null) q.Enqueue(d.left);
                if (d.right != null) q.Enqueue(d.right);
            }
        }
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var res = s.ConvertToSelfBalancingBST(TestSolution.DesignBST9());
            PrintBFS(res);
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
        public TreeNode ConvertToSelfBalancingBST(TreeNode root)
        {
            if (root == null) return null;
            List<int> arr = new List<int>();
            InorderTraversal(root, arr);
            return BuildSelfBBST(arr, 0, arr.Count - 1);
        }
        TreeNode BuildSelfBBST(List<int> arr, int start, int end)
        {
            if (start > end) return null;
            int mid = (end + start) / 2;
            TreeNode root = new TreeNode(arr[mid]);
            root.left = BuildSelfBBST(arr, start, mid - 1);
            root.right = BuildSelfBBST(arr, mid + 1, end);
            return root;
        }

        void InorderTraversal(TreeNode root, List<int> arr)
        {
            if (root == null) return;
            InorderTraversal(root.left, arr);
            arr.Add(root.val);
            InorderTraversal(root.right, arr);
        }
    }

    class TestSolution
    {
        static int idx = 0;

        /// Creates a BST from preorder traversal of BST

        static TreeNode UtilityCreateBST(int[] pre, int minval, int maxval)
        {
            if (idx > pre.Length - 1) return null;
            int nowVal = pre[idx];
            if (nowVal >= maxval || nowVal <= minval) return null;
            TreeNode root = new TreeNode(nowVal);
            idx += 1;
            root.left = UtilityCreateBST(pre, minval, nowVal);
            root.right = UtilityCreateBST(pre, nowVal, maxval);
            return root;
        }
        public static TreeNode DesignBST1()
        {
            int[] preOrder = { };
            if (preOrder == null || preOrder.Length == 0) return null;
            idx = 0;
            return UtilityCreateBST(preOrder, int.MinValue, int.MaxValue);
        }
        public static TreeNode DesignBST2()
        {
            //           31
            //         /    \                                                   
            //        /      \                                                
            //      14         56                                               
            //      /\        /  \                                                
            //     5  23     42   92                                            
            //    /\  /\    / \   / \                                         
            //   1 9 17 27 35 49 71 105   
            int[] preOrder = { 31, 14, 5, 1, 9, 23, 17, 27, 56, 42, 35, 49, 92, 71, 105 };
            if (preOrder == null || preOrder.Length == 0) return null;
            idx = 0;
            return UtilityCreateBST(preOrder, int.MinValue, int.MaxValue);
        }
        public static TreeNode DesignBST3()
        {
            //                      7                                                   
            //                    /  \                                              
            //                  1     13                                               
            //                       / \                                                 
            //                     11   28
            //                          /\
            //                        21  36
            //                            / \
            //                          32   49
            //                               /\
            //                             42  55      
            int[] preOrder = { 7, 1, 13, 11, 28, 21, 36, 32, 49, 42, 55 };
            if (preOrder == null || preOrder.Length == 0) return null;
            idx = 0;
            return UtilityCreateBST(preOrder, int.MinValue, int.MaxValue);
        }

        public static TreeNode DesignBST4()
        {
            //             80
            //         /        \                                                   
            //        /          \                                                
            //       40           10                                               
            //     /    \        /  \                                                
            //   20      60     100  120
            //   /\      /\    /       \
            //  1  30   50 70 90        130            
            int[] preOrder = { 80, 40, 20, 10, 30, 60, 50, 70, 110, 100, 90, 120, 130 };
            if (preOrder == null || preOrder.Length == 0) return null;
            idx = 0;
            return UtilityCreateBST(preOrder, int.MinValue, int.MaxValue);
        }

        public static TreeNode DesignBST5()
        {
            //           50                                                   
            //          /                                              
            //         40                                               
            //        /                                                 
            //       30
            //      /
            //     20
            //    /           
            //   10            
            int[] preOrder = { 50, 40, 30, 20, 10 };
            if (preOrder == null || preOrder.Length == 0) return null;
            idx = 0;
            return UtilityCreateBST(preOrder, int.MinValue, int.MaxValue);
        }

        public static TreeNode DesignBST6()
        {
            //         10                                                   
            //          \                                              
            //           20                                               
            //            \                                                 
            //             30
            //              \
            //               40
            //                 \     
            //                  50    

            int[] preOrder = { 10, 20, 30, 40, 50 };
            if (preOrder == null || preOrder.Length == 0) return null;
            idx = 0;
            return UtilityCreateBST(preOrder, int.MinValue, int.MaxValue);
        }
        public static TreeNode DesignBST7()
        {
            //             80
            //            /
            //          20                                           
            //            \                                          
            //             70                                        
            //            /                                          
            //           30                                          
            //            \                                         
            //             60                                         
            //             /
            //            40             
            //              \            
            //               50                                                         
            int[] preOrder = { 80, 20, 70, 30, 60, 40, 50 };
            if (preOrder == null || preOrder.Length == 0) return null;
            idx = 0;
            return UtilityCreateBST(preOrder, int.MinValue, int.MaxValue);
        }

        public static TreeNode DesignBST8()
        {
            //         40                                                   
            //        / \                                                
            //       30  50                                               
            //      /\   /\                                                
            //     20      60                                               
            //    /\       / \                                            
            //   10           70    
            int[] preOrder = { 40, 30, 20, 10, 50, 60, 70 };
            if (preOrder == null || preOrder.Length == 0) return null;
            idx = 0;
            return UtilityCreateBST(preOrder, int.MinValue, int.MaxValue);
        }
        public static TreeNode DesignBST9()
        {
            //         40                                                   
            //        /   \                                                
            //       30    80                                               
            //        \     /\                                                
            //        32     90                                               
            //         \     / \                                            
            //          35      100
            //                     \       
            //                      120      
            //                                  
            int[] preOrder = { 40, 30, 32, 35, 80, 90, 100, 120 };
            if (preOrder == null || preOrder.Length == 0) return null;
            idx = 0;
            return UtilityCreateBST(preOrder, int.MinValue, int.MaxValue);
        }
    }
}
