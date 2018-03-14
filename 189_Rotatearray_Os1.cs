public class Solution {
    public void Rotate(int[] nums, int k) 
    {
        k = k % nums.Length;
        int count = 0;
        for (int start = 0; count < nums.Length; start++) 
        {
            int current = start;
            Console.WriteLine("s = " + start);
            int prev = nums[start];
            do {
                int next = (current + k) % nums.Length;
                Console.WriteLine("n = " + next);
                int temp = nums[next];
                nums[next] = prev;
                prev = temp;
                current = next;
                count++;
            } while (start != current);
        }
    }
}