public class Solution 
{
    public int Trap(int[] height) 
    {
        int water = 0;
        if(height == null || height.Length == 0)
            return 0;
        
        var marked = new bool[height.Length];
        int maxh = -1;
        var sortedH = new SortedDictionary<int,List<int>>();
        for(int i = 0; i <height.Length; i++)
        {
            if(height[i] > maxh)
                maxh = height[i];
            if(sortedH.ContainsKey(height[i]))
            {
                var l = sortedH[height[i]];
                l.Add(i);
                sortedH[height[i]] = l;
            }
            else
            {
                var l = new List<int>();
                l.Add(i);
                sortedH.Add(height[i], l);
            }
        }
        var sortedL = sortedH.Reverse().ToList();
        /*foreach(var p in sortedH)
        {
            Console.WriteLine(" " + p.Key + " " + p.Value);
        }
        Console.WriteLine("cnt = "+sortedL.Count());*/
        var pairs = new List<KeyValuePair<int,int>>();
        foreach(var t in sortedL)
        {
            var key = t.Key;
            foreach(var v in t.Value)
            {
                pairs.Add(new KeyValuePair<int,int>(key, v));
                //Console.WriteLine(" " + key + " " + v);
            }
        }
        //Console.WriteLine("cnt = "+pairs.Count());
        
        var tuple = pairs[0];
        marked[tuple.Value] = true;
        //Console.WriteLine("first = "+tuple.Key + " " + tuple.Value);
        
        for(int i = 1; i<height.Length;i++)
        {
            var h = pairs[i].Key;
            var loc = pairs[i].Value;
            //Console.WriteLine(" h = " + h +" loc = "+ loc);
            if(marked[loc])
            {
                continue;
            }
                
            var leftend = -1;
            var rightend = -1;
            
            //find left end
            for(int j = loc; j>=0;j--)
            {
                if(marked[j])
                {
                    leftend = j;
                    break;
                }
            }
            Console.WriteLine("left = "+ leftend);
            
            //find right end
            for(int j = loc; j< height.Length;j++)
            {
                if(marked[j])
                {
                    rightend = j;
                    break;
                }
            }
            Console.WriteLine("right = "+ rightend);
            
            if(leftend!=-1)
            {
                var max = height[leftend] > h ? h : height[leftend];
                for(int j = loc - 1; j> leftend;j--)
                {
                    int diff = max - height[j];
                    if(diff > 0)
                    {
                        water += diff;
                    }
                    
                    marked[j] = true;
                }
            }
            
            if(rightend!=-1)
            {
                var max = height[rightend] > h ? h : height[rightend];
                for(int j = loc + 1; j< rightend;j++)
                {
                    int diff = max - height[j];
                    if(diff > 0)
                    {
                        water += diff;
                    }
                    marked[j] = true;
                }
            }
            Console.WriteLine("water " + water);
            marked[loc] = true;
        }
        return water;
    }
}