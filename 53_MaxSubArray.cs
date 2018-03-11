public class Solution {
    public int MaxSubArray(int[] nums) 
    {
        if(nums == null || nums.Length == 0)
            return -2147483648;
        var nl = new List<int>(nums);
        var max = int.MaxValue;
        for(int i = 0; i < nums.Length;i++)
        {
            if(max > nums[i])
                max = nums[i]; //set max to min element of array
        }
        //Console.WriteLine("m = " + max);
        while(nl.Count() > 0)
        {
            if(nl[0] > max)
            {
                max = nl[0];
            }
            var c = nl.Count();
            if(c > 1 && nl[1] > max)
            {
                max = nl[1];
            }
            if(c > 1 && nl[c-1] > max)
            {
                max = nl[c-1];
            }
            if(c > 1 && nl[c-2] > max)
            {
                max = nl[c-2];
            }
            
            if(nl[0] <= 0)
            {
                nl.RemoveAt(0);
                Console.WriteLine("0.m = " + max);
            }
            else if(nl[c-1] <= 0)
            {
                    nl.RemoveAt(c - 1);
                    Console.WriteLine("1.m = " + max);
            }
            else
            {
                
                var l = nl.Count();
                if(l > 1)
                {
                    var first = nl[0];
                    var second = nl[1];
                    nl.RemoveAt(0);
                    nl.RemoveAt(0);
                    var nn = first + second;
                    if(nn > 0)
                    {
                        nl.Insert(0,nn);
                        if(max < nn)
                            max = nn;
                    }
                }
                l = nl.Count();
                if(l > 1)
                {
                    var last = nl[l-1];
                    var slast = nl[l-2];
                    nl.RemoveAt(l-1);
                    nl.RemoveAt(l-2);
                    var ls = last + slast;
                    if(ls > 0)
                    {
                        nl.Add(ls);
                        if(max < ls)
                            max = ls;
                    }
                }
            }
            if(nl.Count() == 1)
            {
                return (nl[0] > max ? nl[0] : max);
            }
            if(nl.Count() == 0)
                return max;
        }
        return max;
    }
}