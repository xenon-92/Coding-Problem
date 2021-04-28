using System;
using System.Collections.Generic;

namespace _21_count_nodes_in_complete_binary_tree
{
    class Program
    {
        static void Main(string[] args)
        {
            TestSolution t = new TestSolution();
            Solution1 s = new Solution1();
            var treeroot = t.DesignCompleteTree1();
            var res = s.CountNodesForCompleteBT(treeroot);
            System.Console.WriteLine(res);
            t.BFS(treeroot);

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

    // A binary tree is said to be complete, if all the level except the last level is completely filled
    // and all the nodes are as left as possible
    // https://web.cecs.pdx.edu/~sheard/course/Cs163/Doc/FullvsComplete.html#:~:text=A%20full%20binary%20tree%20(sometimes,as%20far%20left%20as%20possible.
    class Solution
    {
        // Naive approach
        public int GetNodeCountForCompleteBT(TreeNode root)
        {
            return UtilityCountNodes(root);
        }
        //naive method
        int UtilityCountNodes(TreeNode root)
        {
            if (root == null) return 0;
            int l = UtilityCountNodes(root.left);
            int r = UtilityCountNodes(root.right);
            return l + r + 1;
        }
    }

    class Solution1
    {
        public int CountNodesForCompleteBT(TreeNode root)
        {
            return (int)UtilityCountNodes(root);
        }
        // If we observe carefully, the left subtree of BT is a Full Binary tree
        // for a full BT, the number of nodes in it is 2^n-1, where n represents the
        // height of BT wrt node, we use that fact in to account and for right subtree we call
        // the general count nodes function 
        double UtilityCountNodes(TreeNode root)
        {
            if (root == null) return 0;
            int left = 0, right = 0;
            TreeNode temp = root;
            while (temp != null)
            {
                left += 1;
                temp = temp.left;
            }
            temp = root;
            while (temp != null)
            {
                right += 1;
                temp = temp.right;
            }
            if (left == right)
            {
                return Math.Pow(2, left) - 1;
            }
            else
            {
                double l = UtilityCountNodes(root.left);
                double r = UtilityCountNodes(root.right);
                return l + r + 1;
            }
        }
    }

    class TestSolution
    {
        List<int> lst = new List<int>();
        public TestSolution()
        {
            string s = "1,2,4,6,-1,-1,7,-1,-1,5,8,-1,-1,9,-1,-1,3,10,12,-1,-1,-1,11,-1,-1";
            string[] str = s.Split(',', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < str.Length; i++)
            {
                lst.Add(Convert.ToInt32(str[i]));
            }
        }
        public TreeNode DesignCompleteTree1()
        {
            return Deserialize(lst);
        }
        int preIndex = 0;
        private TreeNode Deserialize(List<int> arr)
        {
            if (arr.Count == preIndex)
            {
                return null;
            }
            int val = arr[preIndex++];
            if (val == -1) return null;
            TreeNode root = new TreeNode(val);
            root.left = Deserialize(arr);
            root.right = Deserialize(arr);
            return root;
        }
        public void BFS(TreeNode root)
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
    }
}
