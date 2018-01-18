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
    public bool IsSymmetric(TreeNode root) 
    {
        if(root == null)
            return true;
        return AreSym(root.left, root.right);
    }
    
    public bool AreSym(TreeNode one, TreeNode two)
    {
        if(one == null && two==null)
            return true;
        if(one == null && two!=null)
            return false;
        if(one != null && two == null)
            return false;
        if(one.val!=two.val)
        {
            return false;
        }
        if(!AreSym(one.left, two.right))
            return false;
        if(!AreSym(one.right, two.left))
            return false;
        return true;
    }
}