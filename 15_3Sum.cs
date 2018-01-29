public class Solution 
{
    public IList<IList<int>> ThreeSum(int[] nums) 
    {
        var triples = new List<IList<int>>();
        var set = new HashSet<string>();
        if(nums.Length <= 2)
        {
            return triples;
        }
        //sort
        Array.Sort(nums);
        
        //Detect zero pairs
        int c = 0;
        for(int i=0;i<nums.Length;i++)
        {
            if(nums[i] == 0)
            {
                c++;
            }
        }
        if(c >=3)
        {
            triples.Add(new List<int>{0,0,0});
            set.Add("000");
        }
        
        // work on negative part
        // find 1st zero or +ve num
        int posStart = -1;
        for(int i=0;i<nums.Length;i++)
        {
            if(nums[i] >= 0)
            {
                posStart = i;
                break;
            }
        }
        //Console.WriteLine(posStart);
        if(posStart == -1) //all nos are -ve, return
        {
            return triples;    
        }
        if(posStart == 0)
        {
            posStart++;
        }
        
        for(int i=0;i<posStart;i++) //find triples with one -ve no
        {
            int p1 = posStart;
            int p2 = nums.Length-1;
            int target = -(nums[i]);
            //Console.WriteLine(target);
            //Console.WriteLine("p1 = "+p1 +" p2 = "+p2);
            while(p1!=p2)
            {
                //Console.WriteLine("p1 = "+p1 +" p2 = "+p2);
                var t = target - nums[p2] - nums[p1];
                if(t == 0)
                {
                    var arr = new int[] {nums[i], nums[p1], nums[p2]};
                    Array.Sort(arr);
                    var s = String.Join("",arr);
                    if(!set.Contains(s))
                    {
                        triples.Add(arr.ToList());
                        //Console.WriteLine(s);
                        set.Add(s);
                    }
                }
                if(t < 0)
                {
                    p2--;
                }
                else
                {
                    p1++;
                }
            }
        }
        
        //reverse
        Array.Reverse(nums);
        //Console.WriteLine(String.Join("-", nums));
        
        //work on +Ve part
        int negStart = -1;
        for(int i=0;i<nums.Length;i++)
        {
            if(nums[i] <= 0)
            {
                negStart = i;
                break;
            }
        }
        //Console.WriteLine(negStart);
        if(negStart == -1) //all nos are +ve, return
        {
            return triples;    
        }
        if(negStart == 0)
        {
            negStart++;
        }
        for(int i=0;i<negStart;i++) //find triples with one -ve no
        {
            int p1 = negStart;
            int p2 = nums.Length-1;
            int target = nums[i];
            //Console.WriteLine(target);
            //Console.WriteLine("p1 = "+p1 +" p2 = "+p2);
            while(p1!=p2)
            {
                //Console.WriteLine("p1 = "+p1 +" p2 = "+p2);
                var t = target + nums[p2] + nums[p1];
                if(t == 0)
                {
                    var arr = new int[] {nums[i], nums[p1], nums[p2]};
                    Array.Sort(arr);
                    var s = String.Join("",arr);
                    if(!set.Contains(s))
                    {
                        triples.Add(arr.ToList());
                        //Console.WriteLine(s);  
                        set.Add(s);
                    }
                }
                if(t < 0)
                {
                    p2--;
                }
                else
                {
                    p1++;
                }
            }
        }
        var cmp = new TripleC();
        triples.Sort(cmp);
        return triples;
    }
    
    
    public class TripleC: IComparer<IList<int>>
    {
        public int Compare(IList<int> x, IList<int> y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                if (y == null)
                {
                    return 1;
                }
                else
                {
                    var f = x[0].CompareTo(y[0]);
                    if(f!=0)
                    {
                        return f;
                    }
                    var s = x[1].CompareTo(y[1]);
                    if(s!=0)
                    {
                        return s;
                    }
                    var t = x[2].CompareTo(y[2]);
                    if(t!=0)
                    {
                        return t;
                    }
                }
            }
            return 0;
        }
    }
}