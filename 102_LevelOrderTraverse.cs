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
    public IList<IList<int>> LevelOrder(TreeNode root) 
    {
        var result = new List<IList<int>>();
        if(root == null)
            return result;
        var nq = new List<Tuple<TreeNode,int>>();
        nq.Add(new Tuple<TreeNode,int>(root, 0));
        var cl = -1;
        while(nq.Count() > 0)
        {
            Tuple<TreeNode,int> curr = nq[0];
            nq.RemoveAt(0);
            if(curr.Item2 != cl)
            {
                result.Add(new List<int>());
                cl = curr.Item2;
            }
            result[cl].Add(curr.Item1.val);
            if(curr.Item1.left != null)
            {
                nq.Add(new Tuple<TreeNode,int>(curr.Item1.left, curr.Item2 + 1));
            }
            if(curr.Item1.right != null)
            {
                nq.Add(new Tuple<TreeNode,int>(curr.Item1.right, curr.Item2 + 1));
            }
        }
        
        return result;
    }
}