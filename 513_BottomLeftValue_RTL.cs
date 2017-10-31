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
    public int FindBottomLeftValue(TreeNode root) 
    {
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);
        var r = root;
        while(q.Count > 0)
        {
            r = q.Dequeue();
            if(r.right != null)
            {
                q.Enqueue(r.right);
            }
            if(r.left != null)
            {
                q.Enqueue(r.left);
            }
        }
        return r.val;
    }
}