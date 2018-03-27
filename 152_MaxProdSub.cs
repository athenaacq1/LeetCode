public class Solution {
    public int MaxProduct(int[] nums) 
    {
        int max = nums[0];
        var zeroi = new List<int>();
        for(int i = 0; i < nums.Length; i++)
        {
            if(nums[i] == 0)
                zeroi.Add(i);
        }
        zeroi.Add(nums.Length);
        var start = 0;
        for(int j=0; j < zeroi.Count(); j++)
        {
            if(start >= nums.Length)
                break;
            var end = zeroi[j];
            if(start != end)
                {
            
            var total = nums[start];
                
            for(int i = start + 1; i < end; i++)
            {
                total = total * nums[i];
            }
            if(total > max)
                max = total;
                if(start + 1 != end)
                {
                    
                
            int left = nums[start];
            int right = total / left;
            if(left > max)
                max = left;
            if(right > max)
                max = right; 
            for(int i = start+1; i < end; i++)
            {
                if(nums[i] < 0)
                {
                    if(left > max)
                        max = left;
                    right = total / nums[i] / left;
                    if(right > max)
                        max = right;
                }
                left = left * nums[i];
            }
                }
            }
            if(end == nums.Length)
                break;
            else
            {
                start = zeroi[j] + 1;
            }
        }
        
        if(zeroi.Count() > 1 && max < 0)
            return 0;
        
        return max;
    }
}