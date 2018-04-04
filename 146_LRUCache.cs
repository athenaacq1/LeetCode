public class LRUCache {

    Dictionary<int,Tuple<int,LinkedListNode<int>>> cache;
    LinkedList<int> recentUsed;
    LinkedListNode<int> first;
    int maxcap = 0;
    
    public LRUCache(int capacity) 
    {
        cache = new Dictionary<int, Tuple<int,LinkedListNode<int>>>();
        recentUsed = new LinkedList<int>();
        recentUsed.AddFirst(-1); //head
        first = recentUsed.First;
        maxcap = capacity;
    }
    
    public int Get(int key) 
    {
        Tuple<int,LinkedListNode<int>> value = new Tuple<int,LinkedListNode<int>>(-1, new LinkedListNode<int>(-1));
        if(cache.TryGetValue(key, out value))
        {
            var node = value.Item2;
            var result = value.Item1;
            recentUsed.Remove(node);
            recentUsed.AddAfter(first, new LinkedListNode<int>(key));
            cache[key] = new Tuple<int,LinkedListNode<int>>(value.Item1, first.Next);
            return result;
        }
        return -1;
    }
    
    public void Put(int key, int value) 
    {
        if(cache.ContainsKey(key))
        {
            recentUsed.Remove(cache[key].Item2);
            recentUsed.AddAfter(first, new LinkedListNode<int>(key));
            cache[key] = new Tuple<int,LinkedListNode<int>>(value,first.Next);
        }
        else if(cache.Count() < maxcap)
        {
            recentUsed.AddAfter(first, new LinkedListNode<int>(key));
            cache.Add(key, new Tuple<int,LinkedListNode<int>>(value, first.Next));
        }
        else
        {
            cache.Remove(recentUsed.Last.Value);
            recentUsed.Remove(recentUsed.Last);
            recentUsed.AddAfter(first, new LinkedListNode<int>(key));
            cache.Add(key, new Tuple<int,LinkedListNode<int>>(value, first.Next));
        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */