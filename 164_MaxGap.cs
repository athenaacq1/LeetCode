public class Solution {
    public int MaximumGap(int[] nums) 
    {
        if(nums.Length < 2)
            return 0;
        
        int min = int.MaxValue;
        int max = int.MinValue;
        for(int i = 0; i< nums.Length; i++)
        {
            if(min > nums[i])
                min = nums[i];
            if(max < nums[i])
                max = nums[i];
        }
        
        int N = nums.Length > 10 ? 10 : nums.Length;
        
        if(min == max)
            return 0;
        
        int range = (max - min) + 1;
        int bsize = (int) (Math.Ceiling((double)range / (double)N));
        //Console.WriteLine("b = " + bsize);
                           
        var rangeEnds = new int[N,2];
        rangeEnds[0,0] = min;
        rangeEnds[0,1] = min + bsize - 1;
        var lastEnd = rangeEnds[0,1];
        var rangeCont = new List<List<int>>();
        rangeCont.Add(new List<int>());
        for(int i = 1; i< N; i++)
        {
            rangeEnds[i,0] = lastEnd + 1;
            rangeEnds[i,1] = lastEnd + 1 + (bsize - 1);
            lastEnd = rangeEnds[i,1];
            rangeCont.Add(new List<int>());
        }
        rangeEnds[N-1,1] = max;
        
        for(int i = 0; i<nums.Length; i++)
        {
            var index = GetRangeId(nums[i], rangeEnds);
            rangeCont[index].Add(nums[i]);
        }
        
        var rangeExt = new int[N,2];
        for(int i = 0; i< N; i++)
        {
            var res = GetMinMax(rangeCont[i]);
            rangeExt[i,0] = res[0]; 
            rangeExt[i,1] = res[1]; 
        }
        
        /*for(int i = 0; i< N; i++)
        {
            Console.WriteLine("rs = " + rangeEnds[i,0] + " re = " + rangeEnds[i,1]);
            Console.WriteLine("i = " + String.Join(",",rangeCont[i]));
            Console.WriteLine("es = " + rangeExt[i,0] + " ee = " + rangeExt[i,1]);
        }*/
        
        
        var maxgap = int.MinValue;
        bool first = true;
        
        for(int i = 0; i< N; i++)
        {
            if(rangeExt[i,0] == -1)
                continue;
            else if(first)
            {
                first = false;
                lastEnd = rangeExt[i,1];
            }
            else 
            {
                var diff1 = rangeExt[i,0] - lastEnd;
                lastEnd = rangeExt[i,1];
                if(maxgap < diff1)
                    maxgap = diff1;    
            }
        }
        
        if(maxgap < bsize)
        {
            for(int i = 0; i< N; i++)
            {
                var mg = GetGapInRange(rangeCont[i]);
                //Console.WriteLine("mg = " + mg);
                if(mg > maxgap)
                    maxgap = mg;
            }
        }
        
        
        return maxgap;
    }
    
    public int GetRangeId(int num, int[,] rangeEnds)
    {
        for(int i = 0; i<rangeEnds.Length; i++)
        {
            if(rangeEnds[i,0] <= num && rangeEnds[i,1] >= num)
                return i;
        }
        throw new Exception("Invalid state");
    }
    
    public int[] GetMinMax(List<int> range)
    {
        if(range.Count() == 0)
            return new int[] {-1,-1};
        int min = int.MaxValue;
        int max = int.MinValue;
        foreach(var num in range)
        {
            if(min > num)
                min = num;
            if(max < num)
                max = num;
        }
        return new int[] {min, max};
    }
    
    public int GetGapInRange(List<int> range)
    {
        var arr = range.ToArray();
        Array.Sort(arr);
        int max = int.MinValue;
        for(int i = 1; i < arr.Length; i++)
        {
            var m = arr[i] - arr[i-1];
            if(max < m)
                max = m;
        }
        return max;
    }
    
}