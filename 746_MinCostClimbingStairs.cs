public class Solution {
    public int MinCostClimbingStairs(int[] cost) 
    {
        if(cost.Length == 0)
            return 0;
        if(cost.Length == 1)
            return cost[0];
        int n = cost.Length;
        int[] minCost = new int[n+1];
        minCost[n] = 0;
        
        for(int i = n-1; i >=0; i--)
        {
            int c1 = cost[i] + minCost[i+1];
            int c2 = int.MaxValue;
            if(i+2 <= n)
                c2 = cost[i] + minCost[i+2];
            minCost[i] = Math.Min(c1,c2);
        }
        
        return Math.Min(minCost[0], minCost[1]);
    }
}