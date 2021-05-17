namespace P1
{
    class SolutionInsert
    {
        public TreeNode Insert(TreeNode root, int k)
        {
            if (root == null) return new TreeNode(k);
            if (root.val == k)
            {
                return root;
            }
            else if (root.val < k)
            {
                root.left = Insert(root.left, k);
                return root;
            }
            else
            {
                root.right = Insert(root.right, k);
                return root;
            }
        }

        public TreeNode InsertIterative(TreeNode root, int k)
        {
            if (root == null) return new TreeNode(k);
            var temp = root; TreeNode preTemp = null;
            while (temp != null)
            {
                if (temp.val == k) return root;
                preTemp = temp;
                if (k < temp.val)
                {
                    temp = temp.left;
                }
                else
                {
                    temp = temp.right;
                }
            }
            if (k < preTemp.val)
            {
                preTemp.left = new TreeNode(k);
            }
            else
            {
                preTemp.right = new TreeNode(k);
            }
            return root;
        }

    }
}