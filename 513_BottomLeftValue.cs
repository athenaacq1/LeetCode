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
    Queue<Tuple<TreeNode,int>> q = new Queue<Tuple<TreeNode,int>>();
    public int FindBottomLeftValue(TreeNode root) 
    {
        q.Enqueue(new Tuple<TreeNode,int>(root, 0));
        int leftVal = root.val;
        int level = 0;
        while(q.Any())
        {
            var tup = q.Dequeue();
            if(level < tup.Item2)
            {
                level = tup.Item2;
                leftVal = tup.Item1.val;
            }
            if(tup.Item1.left != null)
            {
                q.Enqueue(new Tuple<TreeNode,int>(tup.Item1.left, tup.Item2 + 1));
            }
            if(tup.Item1.right != null)
            {
                q.Enqueue(new Tuple<TreeNode,int>(tup.Item1.right, tup.Item2 + 1));
            }
        }
        return leftVal;
    }
}