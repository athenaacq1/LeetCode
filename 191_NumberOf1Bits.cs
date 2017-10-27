public class Solution {
    public int HammingWeight(uint n) 
    {
        int result = 0;
        while(n > 0)
        {
            result++;
            n = n & n - 1; 
        }
        return result;
    }
}
