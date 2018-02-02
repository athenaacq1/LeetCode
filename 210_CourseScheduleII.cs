public class Solution {
    public int[] FindOrder(int numCourses, int[,] prerequisites) 
    {
        var dict = new Dictionary<int,Node>();
        for(int i = 0; i<numCourses;i++)
        {
            var n = new Node(i);
            dict.Add(i,n);            
        }
        for(int i = 0; i<prerequisites.GetLength(0);i++)
        {
            var n = dict[prerequisites[i,0]];
            n.dependencies.Add(prerequisites[i,1]);
        }
        
        var stk = new Stack<int>();
        var order = new List<int>();
        for(int i = 0;i<numCourses;i++)
        {
            if(dict[i].visited)
                continue;
            else
            {
                stk.Push(i);
                //Console.WriteLine("Push " + i);
                while(stk.Any())
                {
                    var top = stk.Pop();
                    //Console.WriteLine("Pop " + i);
                    var node = dict[top];
                    //node.processing = true;
                    if(node.visited)
                    {
                        continue;
                    }
                    else if(node.dependencies.Count() == 0) //no dep
                    {
                        order.Add(node.num);
                        node.visited = true;
                        continue;
                    }
                    else //add deps
                    {
                        bool fnp = false;
                        foreach(int d in node.dependencies)
                        {
                            if(!dict[d].visited)
                            {
                                fnp = true;
                            }
                        }
                        if(fnp)
                        {
                            // deps remaining
                            stk.Push(top);
                            foreach(int d in node.dependencies)
                            {
                                if(!dict[d].visited)
                                {
                                    stk.Push(d);   
                                }
                            }
                        }
                        else
                        {
                            // all deps visited
                            order.Add(top);
                            node.visited = true;
                        }
                    }
                    if(stk.Count() > numCourses)
                    {
                        //cycle 
                        return new int[0];
                    }
                }
            }
        }
        
        return order.ToArray();
    }
    
    public class Node
    {
        public List<int> dependencies = new List<int>();
        public bool processing = false;
        public bool visited = false;
        public int num = -1;
        public Node(int n)
        {
            num = n;
        }
    }
}