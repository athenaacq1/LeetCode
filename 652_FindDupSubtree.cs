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
    public IList<TreeNode> FindDuplicateSubtrees(TreeNode root) 
    {
        var dups = new HashSet<TreeNode>();
        var dict = new Dictionary<Traverse, TreeNode>(new TraComparer());
        if(root == null)
            return dups.ToList();
        PrintTraversal(root, dict, dups);
        return dups.ToList();
    }
    
    public Traverse PrintTraversal(TreeNode root, Dictionary<Traverse, TreeNode> dict, HashSet<TreeNode> dups)
    {
        var rval = root.val;
        Traverse left = null;
        if(root.left != null)
        {
            left = PrintTraversal(root.left, dict, dups);
            //Console.WriteLine(left.ToString());
        }
        Traverse right = null;
        if(root.right != null)
        {
            right = PrintTraversal(root.right, dict, dups);
            //Console.WriteLine(right.ToString());
        }
        
        var ind = (left != null ? left.inorder : "null") + "," + rval + "," + (right != null ? right.inorder : "null");
        var pre = (left != null ? left.preorder : "null") + "," + (right != null ? right.preorder : "null") + "," + rval ;
        
        var subtree = new Traverse(ind, pre);
        if(dict.ContainsKey(subtree))
            dups.Add(dict[subtree]);
        else
            dict.Add(subtree, root);
        return subtree;
    }
    
    public class Traverse
    {
        public string inorder;
        public string preorder;
        
        public Traverse(string ind, string pre)
        {
            inorder = ind;
            preorder = pre;
        }
        
        public string ToString()
        {
            return inorder + "-" + preorder;
        }
    }
    
    public class TraComparer : IEqualityComparer<Traverse>
    {
        public bool Equals(Traverse x, Traverse y)
        {
            if(x.inorder.Equals(y.inorder))
            {
                return x.preorder.Equals(y.preorder);
            }
            return false;
        }
        
        public int GetHashCode(Traverse x)
        {
            return x.inorder.GetHashCode() + x.preorder.GetHashCode();
        }
    }
}