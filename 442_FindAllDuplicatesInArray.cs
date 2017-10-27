public class Solution {
    public IList<int> FindDuplicates(int[] nums) 
    {
        var result = new List<int>();
        for(int i=0; i< nums.Length; i++)
        {
            int abs = Math.Abs(nums[i]);
            
            if(nums[abs-1] > 0) // first
            {
                nums[abs-1] = -nums[abs-1];
            }
            else
                result.Add(abs);
        }
        return result;
    }

}