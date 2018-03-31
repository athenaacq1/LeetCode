public class Solution {
    public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t) 
    {
        if(k == 0)
            return false;
        if(t == 0)
        {
            var set = new HashSet<int>();
            for(int i = 0; i < nums.Length; i++)
            {
                if(set.Contains(nums[i]))
                    return true;
                set.Add(nums[i]);
            }
        }
        for(int i = 0; i < nums.Length; i++)
        {
            for(int j = i+1; (j <= i + k) && ( j < nums.Length); j++)
            {
                if(Math.Abs((double)nums[i] - (double)nums[j]) <= t)
                    return true;
            }
        }
        return false;
    }
}