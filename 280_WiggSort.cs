public class Solution {
    public void WiggleSort(int[] nums) 
    {
        if(nums == null || nums.Length <= 1)
            return;
        
        var copy = new int[nums.Length];
        Array.Copy(nums, copy, nums.Length);
        Array.Sort(copy);
        int small = 0; 
        int large = nums.Length-1;
        int ptr = 0;
        while(small <= large)
        {
            if(small == large)
            {
                nums[ptr] = copy[small];
                break;
            }
            
            nums[ptr] = copy[small];
            ptr++;
            nums[ptr] = copy[large];
            ptr++;
            small++;
            large--;
        }
    }
}