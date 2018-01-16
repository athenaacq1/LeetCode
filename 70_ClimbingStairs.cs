public class Solution 
{
    public int ClimbStairs(int n) 
    {
        if(n == 0)
            return 1; 
        if(n == 1)
            return 1;
        int[] steps = new int[n+1];
        steps[n] = 1;
        for(int i=n-1;i >= 0; i--)
        {
            int thisstep = 0;
            thisstep = steps[i+1]; //take 1 step
            if(i+2 <= n)
            {
                thisstep += steps[i+2]; //take 2 steps
            }
            steps[i] = thisstep;
        }
        return steps[0];
    }
}