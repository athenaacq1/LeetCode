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
    
    Dictionary<TreeNode,TreeNode> parent = new Dictionary<TreeNode, TreeNode>();
    TreeNode root = null;
    TreeNode last = null;
    public TreeNode ConstructMaximumBinaryTree(int[] nums) 
    {
        root = new TreeNode(nums[0]);
        last = root;
        for(int i=1;i<nums.Length;i++)
        {
            var current = new TreeNode(nums[i]);
            if(current.val > root.val)
            {
                current.left = root;
                parent.Add(root,current);
                root = current;
                last = root;
            }
            else if(current.val < last.val)
            {
                last.right = current;
                parent.Add(current, last);
                last = current;
            }
            else // current.val > last.val
            {
                var p = parent[last];
                while(p!= null && p.val < current.val)
                {
                    p = parent[p];
                }
                if(p == null) // reached root
                {
                    last = current;
                    current.left = root;
                    parent.Add(root, current);
                    root = current;
                }
                else
                {
                    var rs = p.right;
                    p.right = current;
                    current.left = rs;
                    last= current;
                    parent[rs] = current;
                    parent.Add(current,p);
                }
                
            }
        }
        return root;
    }
}