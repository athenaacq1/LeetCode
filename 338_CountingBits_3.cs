public class Solution {
    public int[] CountBits(int num) 
    {
        if(num == 0)
            return new int[] {0};
        if(num == 1)
            return new int[] {0, 1};
        var result = new int[num+1];
        result[0] = 0;
        result[1] = 1;
        
        for(int i=2;i<=num;i++)
        {
            result[i] = 1 + result[i & i-1];
        }
        return result;
    }
} 
