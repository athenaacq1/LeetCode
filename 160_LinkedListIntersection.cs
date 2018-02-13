/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) 
    {
        if(headA  == null || headB == null)
            return null;
        
        var ptr = headA;
        int lena = 0;
        while(ptr!= null)
        {
            ptr = ptr.next;
            lena++;
        }
        
        ptr = headB;
        int lenb = 0;
        while(ptr!= null)
        {
            ptr = ptr.next;
            lenb++;
        }
        
        ListNode aptr;
        ListNode bptr;
        if(lena > lenb)
        {
            int t = lena - lenb;
            ptr = headA;
            for(int i = 0; i < t; i++)
            {
                ptr = ptr.next;
            }
            aptr = ptr;
            bptr = headB;
        }
        else
        {
            int t = lenb - lena;
            ptr = headB;
            for(int i = 0; i < t; i++)
            {
                ptr = ptr.next;
            }
            aptr = headA;
            bptr = ptr;
        }
        
        while(aptr!= null & bptr!=null)
        {
            if(aptr == bptr)
            {
                return aptr;
            }
            aptr = aptr.next;
            bptr = bptr.next;
        }
        
        return null;
    }
}