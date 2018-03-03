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
    public bool IsValidBST(TreeNode root) 
    {
        int min, max;
        if(root == null)
            return true;
        return IsValidBST(root, out min, out max);
    }
    
    public bool IsValidBST(TreeNode root, out int min, out int max) 
    {
        
        if(root == null)
        {
            min = -1;
            max = -1;
            return false;
        }
        //Console.WriteLine("Recursing on: " + root.val);
        int lmin = -1, lmax = -1;
        int rmin = -1, rmax = -1;        
        if(root.left != null)
        {
            var left = IsValidBST(root.left, out lmin, out lmax);
            if(left)
            {
                if(root.val <= lmax)
                {
                     min = -1;
                    max = -1;
                    return false;
                }
            }
            else
            {
                 min = -1;
                max = -1;
                return false;
            }
        }
        
        if(root.right != null)
        {
            var right = IsValidBST(root.right, out rmin, out rmax);
            if(right)
            {
                if(root.val >= rmin)
                {
                     min = -1;
                    max = -1;
                    return false;
                }
            }
            else
            {
                 min = -1;
                max = -1;
                return false;
            }
        }
        
        if(lmin == -1)
            lmin = root.val;
        min = lmin;
        if(rmax == -1)
            rmax = root.val;
        max = rmax;
        //Console.WriteLine("Tree at " + root.val + "is BST");
        return true;
        
    }
}