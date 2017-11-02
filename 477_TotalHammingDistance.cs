public class Solution {
    public int TotalHammingDistance(int[] nums) 
    {
        int total = 0;
        for(int j = 0; j < 31; j++)
        {
            int ones = 0, zeros = 0;
            var pov = (int)Math.Pow(2,j);
            for(int i = 0; i< nums.Length; i++)
            {
                if((nums[i] & pov) == 0)
                {
                    zeros++;
                }
                else
                    ones++;
            }
            total += ones*zeros;
        }
        return total;
    }
}