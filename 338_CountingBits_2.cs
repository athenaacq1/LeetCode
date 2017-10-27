public class Solution {
    public int[] CountBits(int num) 
    {
        var result = new int[num+1];
        for(int i=0;i<=num;i++)
        {
            var currentNum = i;
            var r = 0;
            while(currentNum > 0)
            {
                r++;
                currentNum = currentNum & currentNum - 1;
            }
            result[i] = r;
        }
        return result;
    }
}
