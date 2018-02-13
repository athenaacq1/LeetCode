public class Solution {
    public int MaxCoins(int[] nums) 
    {
        var list = new List<int>();
        for(int i = 0;i<nums.Length;i++)
        {
            if(nums[i] > 0)
                list.Add(nums[i]);
        }
        
        if(list.Count() == 0)
            return 0;
        if(list.Count() == 1)
            return list[0];
        
        int l = list.Count() + 2;
        int[] newarr = new int[l];
        newarr[0] = 1;
        newarr[l-1] = 1;
        int c = 0;
        for(int i = 1; i<l-1;i++)
        {
            newarr[i] = list[c++];
        }
        //Console.WriteLine(String.Join(" ", newarr));
        int[,] dpm = new int[l,l];
        return GetSum(newarr, dpm, 0, l-1);
    }
    
    public int GetSum(int[] nums, int[,]dpm, int left, int right)
    {
        if(dpm[left,right] > 0)
            return dpm[left,right];
        
        if(left + 1 == right)
            return 0;
        
        int max = 0; 
        for(int i = left + 1; i < right; i++)
        {
            var ls = GetSum(nums, dpm, left, i) + nums[left] * nums[i] * nums[right] + GetSum(nums, dpm, i, right);
            if(max < ls)
            {
                max = ls;
            }
        }
        dpm[left,right] = max;
        return max;
    }
    
}