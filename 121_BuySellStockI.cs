public class Solution {
    public int MaxProfit(int[] prices) 
    {
        int maxprofit = 0;
        if(prices.Length <= 1)
            return maxprofit;
        
        int minprice = prices[0];
        int mini = 0;
        int maxprice = int.MinValue;
        int maxi = 0;
        
        for(int i = 1; i<prices.Length;i++)
        {
            var p = prices[i] - prices[mini];
            if(p > maxprofit)
            {
                maxprofit = p;
            }
            if(prices[i] <= minprice)
            {
                minprice = prices[i];
                mini = i;
            }
        }
        
        return maxprofit > 0 ? maxprofit : 0;
    }
}
