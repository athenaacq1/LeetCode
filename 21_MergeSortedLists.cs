/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode MergeTwoLists(ListNode l1, ListNode l2) 
    {
        if(l1 == null)
            return l2;
        if(l2 == null)
            return l1;
        
        ListNode n1 = l1, n2 = l2;
        ListNode result = null;
        if(n1.val < n2.val)
        {
            result = n1;
            n1 = n1.next;
        }
        else
        {
            result = n2;
            n2 = n2.next;
        }
        ListNode final = result;
        while(n1 != null && n2 != null)
        {
            if(n1.val < n2.val)
            {
                result.next = n1;
                n1 = n1.next;
            }
            else
            {
                result.next = n2;
                n2 = n2.next;
            }
            result = result.next;
        }
        if(n1 != null)
        {
            result.next = n1;
            n1 = n1.next;
            result = result.next;
        }
        if(n2 != null)
        {
            result.next = n2;
            n2 = n2.next;
            result = result.next;
        }
        return final;
    }
}