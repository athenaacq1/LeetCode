public class Solution {
    public IList<int> EventualSafeNodes(int[][] graph) 
    {
        var cycleVisit = new bool[graph.Length];
        var inedges = new Dictionary<int, List<int>>();
        visited = new bool[graph.Length];
        for(int i = 0; i < graph.Length; i++)
        {
            result.Add(i);
            foreach(var node in graph[i])
            {
                if(!inedges.ContainsKey(node))
                {
                    inedges.Add(node, new List<int>());
                }
                inedges[node].Add(i);
            }
        }
        
        for(int i = 0; i < graph.Length; i++)
        {
            if(graph[i] == null || graph[i].Length == 0)
            {
                continue;
            }
            if(cycle.Contains(i))            
            {
                continue;
            }
            var s = new HashSet<int>();
            Traverse(i, s, graph.Length, graph, inedges);
        }
        
        result.ExceptWith(cycle);
        return result.ToList();
    }
    
    HashSet<int> result = new HashSet<int>();
    HashSet<int> cycle = new HashSet<int>();
    bool[] visited = new bool[0];
    
    public void GetAllReachable(int i, int[][] graph, Dictionary<int, List<int>> inedges)
    {
        if(cycle.Contains(i))
            return; // already done 
        
        // if all my outlinks are in cycle 
        var stack = new Stack<int>();
        var nodes = new HashSet<int>();
        stack.Push(i);
        nodes.Add(i);
        visited[i] = true;
        while(stack.Count() > 0)
        {
            var bn = stack.Pop();
            bool all = true;
                cycle.Add(bn);
                if(inedges.ContainsKey(bn))
                {
                    foreach(var e in inedges[bn])
                    {
                        if(!nodes.Contains(e))
                        {
                            stack.Push(e);
                            nodes.Add(e);
                            visited[i] = true;
                        }
                    }
                }
            
        }
    }
    
    public bool Traverse(int i, HashSet<int> path, int N, int[][] graph, Dictionary<int, List<int>> inedges)
    {
        //Console.WriteLine(String.Join(",", path));
        if(path.Contains(i))
        {
            // cycle 
            foreach(var node in path)
            {
                //Console.WriteLine("c = " + node);
                GetAllReachable(node, graph, inedges);
            }
            cycle.UnionWith(path);
            
            return true;
        }
        //Console.WriteLine(i);
        if(graph[i] == null || graph[i].Length == 0) //terminal node
            return false;
        
        var nl = new HashSet<int>(path);
        nl.Add(i);
        
        foreach(var node in graph[i])
        {
            if(!visited[node])
            {
                var s = Traverse(node, nl, N, graph, inedges);
                if(!s) // no cycle
                    visited[node] = true;
            }
        }
        visited[i] = true;
        return false;
    }
}