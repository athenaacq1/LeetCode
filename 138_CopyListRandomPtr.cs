/**
 * Definition for singly-linked list with a random pointer.
 * public class RandomListNode {
 *     public int label;
 *     public RandomListNode next, random;
 *     public RandomListNode(int x) { this.label = x; }
 * };
 */
public class Solution {
    public RandomListNode CopyRandomList(RandomListNode head) {
        RandomListNode result = null;
        RandomListNode newh = null;
        Dictionary<RandomListNode, RandomListNode> node2node = new Dictionary<RandomListNode, RandomListNode>();
        
        while(head != null)
        {
            var node = new RandomListNode(head.label);
            node.next = head.next;
            node.random = head.random;
            node2node.Add(head, node);
            head = head.next;
            if(result == null)
            {
                result = node;
                newh = result;
            }
            else
            {
                result.next = node;
                result = result.next;
            }
        } 
        
        result = newh;
        while(newh != null)
        {
            if(newh.random != null) 
                newh.random = node2node[newh.random];    
            newh = newh.next;
        }
        
        return result; 
    }
}