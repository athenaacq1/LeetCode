/**
 * Definition for an interval.
 * public class Interval {
 *     public int start;
 *     public int end;
 *     public Interval() { start = 0; end = 0; }
 *     public Interval(int s, int e) { start = s; end = e; }
 * }
 */
public class Solution {
    public IList<Interval> Merge(IList<Interval> intervals) 
    {
        SortedDictionary<int,Interval> sorted = new SortedDictionary<int,Interval>();
        foreach(var inv in intervals)
        {
            if(sorted.ContainsKey(inv.start))
            {
                var e = sorted[inv.start].end;
                var en = e > inv.end ? e : inv.end;
                sorted[inv.start] = new Interval(inv.start,en);
            }
            else
            {
                sorted.Add(inv.start, inv);    
            }
        }
        
        if(sorted.Count == 0)
        {
            return new List<Interval>();
        }
        if(sorted.Count == 1)
        {
            return new List<Interval> { new Interval(sorted.First().Value.start, sorted.First().Value.end) };
        }
        
        int ns = sorted.First().Value.start;
        int ne = sorted.First().Value.end;
        var list = new List<Interval>();
        foreach(var pair in sorted)
        {
            if(pair.Key <= ne) //overlap
            {
                if(ne < pair.Value.end)
                {
                    ne = pair.Value.end;    
                }
            }
            else
            {
                list.Add(new Interval(ns,ne));
                ns = pair.Key;
                ne = pair.Value.end;
            }
        }
        list.Add(new Interval(ns,ne));
        return list;
    }
}