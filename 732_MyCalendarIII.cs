public class MyCalendarThree 
{
    
    SortedDictionary<Interval,int> intervals = new SortedDictionary<Interval,int>(new IntervalComparer());
    
    public class Interval
    {
        public int start = -1;
        public int end = -1;
        public Interval(int s, int e)
        {
            start = s;
            end = e;
        }
    }
    
    public class IntervalComparer : IComparer<Interval>
    {
        public int Compare(Interval x, Interval y)
        {
            if(x.start != y.start)
            {
                return x.start.CompareTo(y.start);
            }
            return x.end.CompareTo(y.end);
        }
    }
    
    public MyCalendarThree() 
    {
        
    }
    
    public int Book(int start, int end) 
    {
        var newinvs = new Dictionary<Interval,int>();
        //Console.WriteLine("start = " + start + " end = " + end);
        var remove = new List<Interval>();
        int max = 0;
        bool overlap = false;
        bool cnt = false;
        int startagain = -1;
        foreach(var inv in intervals)
        {
            if(cnt)
            {
                if(inv.Key.start > end) // no more overlap
                {
                    if(startagain != end)
                    {
                        var nv = new Interval(startagain, end);
                        newinvs.Add(nv, 1);
                        //Console.WriteLine("c1: Created [" + startagain + "," + end + ") " + inv.Value);
                    }
                    cnt = false;
                    break;
                }
                else if(inv.Key.start == end) // no more overlap
                {
                    cnt = false;
                    break;
                }
                else
                {
                    if(startagain != inv.Key.start)
                    {
                        var nv = new Interval(startagain, inv.Key.start);
                        newinvs.Add(nv, 1);
                        //Console.WriteLine("c2: Created [" + startagain + "," + inv.Key.start + ") " + inv.Value);
                    }
                    start = inv.Key.start;
                }
                cnt = false;
            }
            else
            {
                if(inv.Key.end <= start)
                {
                    continue;
                }
            
                if(inv.Key.start >= end)
                {
                    continue;
                }
            }
            
            overlap = true;
            int os = -1;
            remove.Add(inv.Key);
            //Console.WriteLine("Removing [" + inv.Key.start + "," + inv.Key.end + ")");
            if(inv.Key.start - start > 0)
            {
                //new
                var nv = new Interval(start, inv.Key.start);
                newinvs.Add(nv, 1);
                //Console.WriteLine("0. Created [" + start + "," + inv.Key.start + ") = " + 1);
                os = inv.Key.start;
            }
            else if (start - inv.Key.start > 0)
            {
                var nv = new Interval(inv.Key.start, start);
                newinvs.Add(nv, inv.Value);
                //Console.WriteLine("0.5. Created [" + inv.Key.start + "," + start + ") = " + inv.Value);
                os = start;
            }
            else
            {
                os = start;
            }
            
            int oe = inv.Key.end < end ? inv.Key.end : end;
            //new 
            if(os < oe)
            {
                var nv1 = new Interval(os, oe);
                newinvs.Add(nv1, inv.Value + 1);
                //Console.WriteLine("1. Created [" + os + "," + oe + ") = " + (inv.Value + 1));    
            }
            
            if(oe < inv.Key.end)
            {
                var nv2 = new Interval(oe, inv.Key.end);
                newinvs.Add(nv2, inv.Value);
                //Console.WriteLine("2. Created [" + oe + "," + inv.Key.end + ")= " + inv.Value);
                //cnt = false;
            }
            else
            {
                cnt = true;
                startagain = inv.Key.end;
                //Console.WriteLine("startagain = " + startagain);
            }
        }
        if(cnt)
        {
            var nv2 = new Interval(startagain, end);
            newinvs.Add(nv2, 1);
            //Console.WriteLine("4. Created [" + startagain + "," + end + ")= " + 1);
        }
        
        foreach(var n in remove)
        {
            intervals.Remove(n);
        }
        foreach(var n in newinvs)
        {
            //Console.WriteLine("Trying Adding [" + n.Key.start + "," + n.Key.end + ")" + n.Value);
            intervals.Add(n.Key, n.Value);
            if(max < n.Value)
                max = n.Value;
        }
        
        if(!overlap)
        {
            intervals.Add(new Interval(start, end), 1);
            //Console.WriteLine("Adding [" + start + "," + end + ") = " + 1);
            if(max < 1)
                max = 1;
        }
        foreach(var n in intervals)
        {
            if(n.Value > max)
            {
                //Console.WriteLine("Updating max = " + n.Value + " [" + n.Key.start + "," + n.Key.end + ")");
                max = n.Value;
            }
        }
        
        return max;
    }
}

/**
 * Your MyCalendarThree object will be instantiated and called as such:
 * MyCalendarThree obj = new MyCalendarThree();
 * int param_1 = obj.Book(start,end);
 */