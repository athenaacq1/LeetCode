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
    public IList<int> InorderTraversal(TreeNode root) 
    {
        var stack = new Stack<TreeNode>();
        var currNode = root;
        var l = new List<int>();
        while(currNode != null)
        {
            if(currNode.left != null)
            {
                stack.Push(currNode);
                currNode = currNode.left;
            }
            else
            {
                l.Add(currNode.val);
                currNode = currNode.right;  
                while(stack.Count() > 0 && currNode == null)
                {
                    currNode = stack.Pop();
                    l.Add(currNode.val);
                    currNode = currNode.right;
                }
            }
        }
        return l;
    }
}