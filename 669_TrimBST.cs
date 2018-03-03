/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode TrimBST(TreeNode root, int L, int R) 
    {
        if(root == null)
            return null;
        
        if(L <= root.val && root.val <= R) //retain root
        {
            root.left = TrimBST(root.left, L, R);
            root.right = TrimBST(root.right, L, R);
            return root;
        }
        else //adjust root 
        {
            if(root.val < L)
            {
                return TrimBST(root.right, L, R);
            }
            else
            {
                return TrimBST(root.left, L, R);
            }
        }
    }
}