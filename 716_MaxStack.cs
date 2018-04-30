public class MaxStack {

    /** initialize your data structure here. */
    
    LinkedList<int> st = new LinkedList<int>();
    SortedDictionary<int, List<LinkedListNode<int>>> heap = new SortedDictionary<int, List<LinkedListNode<int>>>();
    
    public MaxStack() 
    {
        }
    
    public void Push(int x) {
        st.AddFirst(new LinkedListNode<int>(x));
        if(!heap.ContainsKey(x))
        {
            heap.Add(x, new List<LinkedListNode<int>>());
        }
        heap[x].Insert(0,st.First);
    }
    
    public int Pop() {
        var node = st.First;
        st.RemoveFirst();
        heap[node.Value].Remove(node);
        if(heap[node.Value].Count() == 0)
        {
            heap.Remove(node.Value);
        }
        return node.Value;
    }
    
    public int Top() {
        return st.First.Value;
    }
    
    public int PeekMax() {
        return heap.Last().Key;
    }
    
    public int PopMax() {
        var val = PeekMax();
        var node = heap[val][0];
        heap[val].RemoveAt(0);
        if(heap[val].Count() == 0)
        {
            heap.Remove(val);
        }
        st.Remove(node);
        return val;
    }
}

/**
 * Your MaxStack object will be instantiated and called as such:
 * MaxStack obj = new MaxStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.PeekMax();
 * int param_5 = obj.PopMax();
 */