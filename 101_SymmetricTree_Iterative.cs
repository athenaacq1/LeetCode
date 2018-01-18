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
        var l = BFS(root.left, false).ToList();
        Console.WriteLine(String.Join(" ", l.ToArray()));
        var r = BFS(root.right, true).ToList();
        Console.WriteLine(String.Join(" ", r.ToArray()));
        if(l.Count()!=r.Count())
            return false;
        for(int i = 0; i<l.Count();i++)
        {
            if(l[i]!=r[i])
                return false;
        }
        return true;
    }
    
    public IEnumerable<string> BFS(TreeNode root, bool isRight)
    {
        var l = new Queue<TreeNode>();
        if(root!=null)
        {
            l.Enqueue(root);
        }
        while(l.Any())
        {
            var node = l.Dequeue();
            if(node == null)
            {
                yield return "null";
                continue;
            }
            if(node!=null)
            {
                yield return node.val.ToString();
                if(isRight)
                {
                    l.Enqueue(node.right);
                    l.Enqueue(node.left);
                    
                }
                else
                {
                        l.Enqueue(node.left);
                   
                        l.Enqueue(node.right);
                    
                }
                
            }
        }
    }
}