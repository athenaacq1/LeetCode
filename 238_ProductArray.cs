public class Solution {
    public int[] ProductExceptSelf(int[] nums) 
    {
        int N = nums.Length;
        var left = new int[nums.Length];
        var right = new int[nums.Length];
        left[0] = 1;
        for(int i = 1; i < nums.Length; i++)
        {
            left[i] = left[i-1] * nums[i-1];
        }
        right[N-1] = 1;
        for(int i = N-2; i >= 0; i--)
        {
            right[i] = right[i+1] * nums[i+1];
        }
        
        var result = new int[N];
        for(int i = 0; i < N; i++)
        {
            result[i] = right[i] * left[i];
        }
        
        return result;
    }
}