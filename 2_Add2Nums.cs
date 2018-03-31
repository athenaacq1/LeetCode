/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) 
    {
        ListNode result = new ListNode(-1);
        var ptr1 = l1;
        var ptr2 = l2;
        var curr = result;
        int carry = 0;
        while(ptr1 != null && ptr2 != null)
        {
            var sum = ptr1.val + ptr2.val + carry;
            carry = sum /10;
            sum = sum % 10;
            var r = new ListNode(sum);
            curr.next = r;
            curr = curr.next;
            ptr1 = ptr1.next;
            ptr2 = ptr2.next;
        }
        
        while(ptr1 != null)
        {
            var sum = ptr1.val + carry;
            carry = sum /10;
            sum = sum % 10;
            var r = new ListNode(sum);
            curr.next = r;
            curr = curr.next;
            ptr1 = ptr1.next;
        } 
        
        while(ptr2 != null)
        {
            var sum = ptr2.val + carry;
            carry = sum /10;
            sum = sum % 10;
            var r = new ListNode(sum);
            curr.next = r;
            curr = curr.next;
            ptr2 = ptr2.next;
        }
        
        if(carry != 0)
        {
            var r = new ListNode(carry);
            curr.next = r;
        }
        
        return result.next;
    }
}