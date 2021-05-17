namespace P1
{
    class Solution
    {
        public TreeNode Delete(TreeNode root, int k)
        {
            if (root == null) return null;

            if (k < root.val)
            {
                root.left = Delete(root.left, k);
            }
            else if (k > root.val)
            {
                root.right = Delete(root.right, k);
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
                    TreeNode successor = GetInorderSuccessor(root.right);
                    root.val = successor.val;
                    root.right = Delete(root.right, successor.val);
                }
            }
            return root;
        }
        TreeNode GetInorderSuccessor(TreeNode root)
        {
            TreeNode temp = null;
            while (root != null)
            {
                temp = root;
                root = root.left;
            }
            return temp;
        }
    }
}