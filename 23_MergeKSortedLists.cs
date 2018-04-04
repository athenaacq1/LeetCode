/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode MergeKLists(ListNode[] lists) 
    {
        var result = new ListNode(0);
        var head = result; 
        var heap = new SortedDictionary<int,List<int>>();
        var ptrs = new List<ListNode>();
        int k = lists.Length;
        int l = 0;
        for(int i = 0; i < k; i++)
        {
            if(lists[i] != null)
            {
                ptrs.Add(lists[i]);
                if(!heap.ContainsKey(ptrs[l].val))
                {
                    heap.Add(ptrs[l].val, new List<int>());    
                }
                heap[ptrs[l].val].Add(l);
                l++;
            }
        }
        
        while(heap.Count() > 0)
        {
            var min = heap.First();
            int listindex = min.Value[0];
            if(min.Value.Count() > 1)
            {
                min.Value.RemoveAt(0);
            }
            else
            {
                heap.Remove(min.Key);
            }
            
            ptrs[listindex] = ptrs[listindex].next;
            if(ptrs[listindex] != null)
            {
                int val = ptrs[listindex].val;
                if(!heap.ContainsKey(val))
                {
                    heap.Add(val, new List<int>());
                }
                heap[val].Add(listindex);
            }
            
            var node = new ListNode(min.Key);
            result.next = node;
            result = result.next;
        }
        
        return head.next;
    }
}