public class Solution {
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph) 
    {
        List<List<int>> inverse = new List<List<int>>();
        int N = graph.Length;
        for(int i = 0; i <N; i++)
        {
            inverse.Add(new List<int>());
        }
        for(int i = 0; i <N; i++)
        {
            var edges = graph[i];
            foreach(var v in edges)
            {
                inverse[v].Add(i);
            }
        }
        //Console.WriteLine(String.Join(",", inverse[N-1]));
        
        int len = 1;
        var paths = new List<IList<int>>();
        var updated = new List<IList<int>>();
        updated.Add(new List<int> {N-1});
        while(len < graph.Length && updated.Count() > 0)
        {
            paths = updated;
            updated = new List<IList<int>>();
            foreach(var path in paths)
            {
                var s = path[0];
                if(s == 0)
                {
                    updated.Add(path);
                    continue;
                }
                Console.WriteLine(s + " = " + String.Join(",", inverse[s]));
                foreach(var v in inverse[s])
                {
                    var np = new List<int> {v};
                    np.AddRange(path);
                    updated.Add(np);
                }
            }
            len++;
        }
        paths = new List<IList<int>>();
        foreach(var path in updated)
        {
            if(path[0] == 0)
            {
                paths.Add(path);
            }
        }
        
        return paths;
    }
}