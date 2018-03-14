public class Solution {
    public void Rotate(int[] nums, int k) 
    {
        if(nums.Length == 0 || k == 0)
            return;
        k = k % nums.Length;
        int cp = nums.Length-k;
        var queue = new Queue<int>();
        for(; cp < nums.Length; cp++)
        {
            queue.Enqueue(nums[cp]);
        }
        
        for(int i = 0; i < nums.Length-k; i++)
        {
            queue.Enqueue(nums[i]);
        }
        
        for(int i = 0; i < nums.Length; i++)
        {
            nums[i] = queue.Dequeue();
        }
    }
}