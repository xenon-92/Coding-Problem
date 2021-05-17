namespace P1
{
    class SolutionSearch
    {
        public int i = 0;
        public bool SearchBST(TreeNode root, int k)
        {
            if (root == null) return false;
            i += 1;
            if (root.val == k) return true;

            else if (k < root.val)
            {
                bool left = SearchBST(root.left, k);
                return left;
            }
            else
            {
                bool right = SearchBST(root.right, k);
                return right;
            }
        }

        public bool SearchBSTIterative(TreeNode root, int k)
        {
            if (root == null) return false;
            while (root != null)
            {
                if (root.val == k) { return true; }
                else if (k < root.val) root = root.left;
                else if (k > root.val) root = root.right;
            }
            return false;
        }
    }
}