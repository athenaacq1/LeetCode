public class Solution {
    public int NumIslands(char[,] grid) 
    {
        if(grid == null || grid.Length == 0)
            return 0;
        
        var cnt = 0;
        bool[,] visited = new bool[grid.GetLength(0), grid.GetLength(1)];
        var st = new Stack<Tuple<int,int>>();
        for(int i = 0; i < grid.GetLength(0); i++)
        {
            for(int j = 0; j < grid.GetLength(1); j++)
            {
                if(visited[i,j]) continue;
                if(Char.GetNumericValue(grid[i,j]) == 1)
                {
                    st.Clear();
                    //Console.WriteLine("i = " + i + "j = " + j);
                    cnt++; //new
                    st.Push(new Tuple<int,int>(i,j));
                    while(st.Count() > 0)
                    {
                        var t = st.Pop();
                        if(!visited[t.Item1, t.Item2] && Char.GetNumericValue(grid[t.Item1,t.Item2]) == 1)
                        {
                            visited[t.Item1, t.Item2] = true;
                            if(t.Item1 != 0 && !visited[t.Item1-1,t.Item2] && Char.GetNumericValue(grid[t.Item1-1,t.Item2]) == 1)
                            {
                                st.Push(new Tuple<int,int>(t.Item1-1,t.Item2));
                            }
                            if( t.Item1 != grid.GetLength(0) - 1 && !visited[t.Item1+1,t.Item2] && Char.GetNumericValue(grid[t.Item1+1,t.Item2]) == 1)
                            {
                                st.Push(new Tuple<int,int>(t.Item1+1,t.Item2));
                            }
                            if(t.Item2 != 0 && !visited[t.Item1,t.Item2-1] && Char.GetNumericValue(grid[t.Item1,t.Item2-1]) == 1)
                            {
                                st.Push(new Tuple<int,int>(t.Item1,t.Item2-1));
                            } 
                            if(t.Item2 != grid.GetLength(1) - 1 && !visited[t.Item1,t.Item2+1] && Char.GetNumericValue(grid[t.Item1,t.Item2+1]) == 1)
                            {
                                st.Push(new Tuple<int,int>(t.Item1,t.Item2+1));
                            }
                        }
                    }
                }
            }
        }
        return cnt;
    }
}