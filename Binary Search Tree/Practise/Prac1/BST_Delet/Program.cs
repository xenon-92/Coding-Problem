using System;
using System.Collections.Generic;

namespace BST_Delet
{
    class Program
    {
        static void PrintBFS(TreeNode root)
        {
            if (root == null) return;
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count != 0)
            {
                var c = q.Count;
                for (int i = 0; i < c; i++)
                {
                    var d = q.Dequeue();
                    if (d.left != null) q.Enqueue(d.left);
                    if (d.right != null) q.Enqueue(d.right);
                    System.Console.Write(d.val + " ");
                }
                System.Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var prm = TestSolution.DesignBST4();
            var res = s.Delete(prm, 60);
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
        public TreeNode Delete(TreeNode root, int k)
        {
            if (root == null) return null;
            if (root.val < k)
            {
                root.right = Delete(root.right, k);
                return root;
            }
            else if (root.val > k)
            {
                root.left = Delete(root.left, k);
                return root;
            }
            else
            {
                if (root.left == null)
                {
                    var temp = root.right;
                    root = null;
                    return temp;
                }
                if (root.right == null)
                {
                    var temp = root.left;
                    root = null;
                    return temp;
                }
                else
                {
                    TreeNode succesor = getInorderSuccessor(root.right);
                    root.val = succesor.val;
                    root.right = Delete(root.right, succesor.val);
                }
            }
            return root;

        }
        TreeNode getInorderSuccessor(TreeNode root)
        {
            while (root != null && root.left != null)
            {
                root = root.left;
            }
            return root;
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
            //       40           110                                               
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
