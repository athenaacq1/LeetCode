public class Solution {
    public int LongestConsecutive(int[] nums) 
    {
        if(nums.Length == 0)
            return 0; 
        if(nums.Length == 1)
            return 1; 
        
        var buckets = new List<Bucket>();
        var b1 = new Bucket(nums[0], nums.Length);
        Console.WriteLine("New [" + b1.min + "," + b1.max+ "]");
        buckets.Add(b1);
        int n = nums.Length;
        for(int i = 1; i < nums.Length; i++)
        {
            bool added = false;
            foreach(var b in buckets)
            {
                int mintouse = 0;
                if(int.MinValue + n >= b.min)
                {
                    mintouse = int.MinValue;
                }
                else
                {
                    mintouse = b.min - n;
                }
                
                int maxtouse = 0;
                if(int.MaxValue - n <= b.max)
                {
                    maxtouse = int.MaxValue;
                }
                else
                {
                    maxtouse = b.max + n;
                }
                if(nums[i] >= mintouse && nums[i] <= maxtouse)
                {
                    Console.WriteLine("Adding " + nums[i] + " to [" + b.min + "," + b.max+ "]");
                    b.Add(nums[i], nums.Length);
                    added = true;
                    break;
                }
            }
            if(!added)
            {
                //new bucket
                var b2 = new Bucket(nums[i], nums.Length);
                buckets.Add(b2);
                Console.WriteLine("New [" + b2.min + "," + b2.max+ "]");    
            }
        }
        
        int maxlen = 0;
        foreach(var b in buckets)
        {
        
            b.p = new bool [b.max - b.min + 1];
            for(int i = 0; i<b.vals.Count(); i++)
            {
                b.p[b.vals[i] - b.min] = true;
            }
        
            int len = 0;
            int start = -1;
            bool seq = false;
            for(int i = 0; i<b.p.Length;i++)
            {
                if(!seq)
                {
                    seq = true;
                    start = i;
                    len++;
                }
                else
                {
                    if(b.p[i-1] && b.p[i])
                    {
                        len++;
                    }
                    else
                    {
                        if(len > maxlen)
                        {
                            maxlen = len;
                        }
                        start = i; //newseq
                        len = 1;
                        seq = true;
                    }
                }
            }
            if(len > maxlen)
            {
                maxlen = len;
            }
        }
        
        
        return maxlen;
        
    }
    
    public class Bucket
    {
        public int min;
        public int max;
        public List<int> vals = new List<int>();
        public bool[] p;
        
        public Bucket(int val, int n)
        {
            if(int.MinValue + n > val)
            {
                min = int.MinValue;
            }
            else
            {
                min = val - n;    
            }
            if(int.MaxValue - n < val)
            {
                max = int.MaxValue;
            }
            else
            {
                max = val + n;    
            }
            vals.Add(val);
        }
        
        public void Add(int val, int n)
        {
            vals.Add(val);
            if(int.MinValue + n >= val)
            {
                min = int.MinValue;
            }
            else if(val - n < min)
            {
                min = val - n;
            }
            if(int.MaxValue - n <= val)
            {
                max = int.MaxValue;
            }
            else if(val + n > max)
            {
                max = val + n;
            }
        }
    }
}