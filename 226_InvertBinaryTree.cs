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
    public TreeNode InvertTree(TreeNode root) 
    {
        if(root == null)
        {
            return null;
        }
        
        var leftinv = InvertTree(root.left);
        var rightinv = InvertTree(root.right);
        
        root.left = rightinv;
        root.right = leftinv;
        
        return root; 
    }
}