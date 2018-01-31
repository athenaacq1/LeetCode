/**
 * Definition for an interval.
 * public class Interval {
 *     public int start;
 *     public int end;
 *     public Interval() { start = 0; end = 0; }
 *     public Interval(int s, int e) { start = s; end = e; }
 * }
 */
public class Solution 
{
    public int EraseOverlapIntervals(Interval[] intervals) 
    {
        if(intervals.Length == 0 || intervals.Length == 1)
            return 0;
        
        var sints = new SortedSet<Interval>(new IntervalComparer());
        bool[] take = new bool[intervals.Length];
        foreach(var inv in intervals)
        {
            sints.Add(inv);
         //   Console.WriteLine(inv.start + " -> " + inv.end);
        }
        
        foreach(var inv in sints)
        {
           //Console.WriteLine(inv.start + " -> " + inv.end);
        }
        
        int endloc = sints.First().end;
        take[0] = true;
        int top = -1;
        foreach(var inv in sints)
        {
            top++;
            if(take[top] == true)
                continue;
            
            if(inv.start < endloc) //overlap
                take[top] = false;
            else
            {
                take[top] = true;
                endloc = inv.end;
            }
        }
        
        int cnt = 0;
        for(int i = 0; i<take.Length; i++)
        {
            if(!take[i])
                cnt++;
        }
        
        return cnt;
    }
    
    /*public bool IsOverlap(Interval a, Interval b)
    {
        if(a.start > b.start)
        {
            var temp = a;
            a = b;
            b = temp;
        }
        //a.start < b.start && 
        if(a.end > b.start)
        {
            return true;
        }
        return false;
    }*/
    
    public class IntervalComparer : IComparer<Interval>
    {
        public int Compare(Interval x, Interval y)
        {
            int r = x.end.CompareTo(y.end);
            if(r != 0)
            {
                return r;
            }
            else
            {
                r = x.start.CompareTo(y.start);
                if(r!=0)
                {
                    return r;
                }
            }
            return 1;
        }
    }
}