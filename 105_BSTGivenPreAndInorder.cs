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
    public TreeNode BuildTree(int[] preorder, int[] inorder) 
    {
        if(preorder.Length == 0)
            return null;
        return BuildTree(preorder, inorder, 0, preorder.Length - 1, 0, preorder.Length - 1);
    }
    public TreeNode BuildTree(int[] preorder, int[] inorder, int pi, int pj, int ni, int nj)
    {
        Console.WriteLine("pi = " + pi + " pj = " + pj + " ni = " + ni + " nj = " + nj);
        if(pi == pj)
        {
            return new TreeNode(preorder[pi]);
        }
        var r = preorder[pi];
        int ri = -1;
        for(int i = ni; i <=nj; i++)
        {
            if(r == inorder[i])
            {
                ri = i;
                break;
            }
        }
        if(ri == -1)
        {
            throw new Exception();
        }
        
        var node = new TreeNode(preorder[pi]);
        int leftEnd = ri - 1;
        int leftLen = leftEnd - ni + 1;
        Console.WriteLine("ri = " + ri);
        if(ri == ni)
        {
            node.left = null;
            leftLen = 0;
        }
        else
        {
            node.left = BuildTree(preorder, inorder, pi + 1, pi + leftLen, ni, leftEnd);    
        }
        if(ri == nj)
        {
            node.right = null;
        }
        else
        {
            int rightBeg = ri + 1;
            node.right = BuildTree(preorder, inorder, pi + leftLen + 1,pj,rightBeg,nj);
        }
        return node;
    }
}