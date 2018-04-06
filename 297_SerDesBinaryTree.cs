/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) 
    {
        var collect = new Dictionary<TreeNode,int>();
        Traverse(root, collect);
        var list = new List<string>();
        foreach(var pair in collect)
        {
            var left = -1;
            var right = -1;
            if(pair.Key.left != null)
                left = collect[pair.Key.left];
            if(pair.Key.right != null)
                right = collect[pair.Key.right];
            list.Add(pair.Key.val + "," + left + "," + right);
        }
        var s = String.Join(";", list);
        //Console.WriteLine(s);
        return s;
    }
    
    private void Traverse(TreeNode root, Dictionary<TreeNode,int> collect)
    {
        if(root == null)
            return;
        collect.Add(root, collect.Count());
        if(root.left != null)
        {
            Traverse(root.left, collect);
        }
        if(root.right != null)
        {
            Traverse(root.right, collect);
        }
    }
    
    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) 
    {
        if(String.IsNullOrWhiteSpace(data))
            return null;
        var list = new List<TreeNode>();
        var tuples = data.Split(new char[] {';'}).Select( x=> x.Split(new char[] {','})).ToArray();
        foreach(var t in tuples)
        {
            var node = new TreeNode(int.Parse(t[0]));
            list.Add(node);
        }
        for(int i =0; i <list.Count(); i++)
        {
            var t = tuples[i].Select(x => int.Parse(x)).ToArray();
            if(t[1]!=-1)
            {
                list[i].left = list[t[1]];
            }
            if(t[2]!=-1)
            {
                list[i].right = list[t[2]];
            }
        }
        
        return list[0];
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));