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
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) 
    {
        if(root == null)
            return null;
        var pf = false;
        var qf = false;
        var re = Find(root, p, q, out pf, out qf);
        if(re != null)
            return re;
        return root;
    }
    
    public TreeNode Find(TreeNode root, TreeNode p, TreeNode q, out bool pf, out bool qf)
    {
        Console.WriteLine("val = " + root.val);
        var pfl = false;
        var qfl = false;
        if(root.left != null)
        {
            var re = Find(root.left, p, q, out pfl, out qfl);
            if(re != null)
            {
                pf = true;
                qf = true;
                return re;
            }
                
        }
        pf = (root == p) || pfl;
        qf = (root == q) || qfl;
        
         if(pf && qf)
            return root;
        
        var pfr = false;
        var qfr = false;
        if(root.right != null)
        {
            var re1 = Find(root.right, p, q, out pfr, out qfr);
            if(re1 != null)
                return re1;
        }
        pf = pf || pfr;
        qf = qf || qfr;
        
        Console.WriteLine("For val = " + root.val + " pf = " + pf + " qf = " + qf);
        
        if(pf && qf)
        {
            
            return root;
        }
            
        return null;
    }
}

