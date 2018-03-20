public class Solution {
    public int CoinChange(int[] coins, int amount) 
    {
        var dpmat = new int[amount+1];
        for(int i = 1; i < dpmat.Length; i++)
        {
            dpmat[i] = -1;
        }
        dpmat[0] = 0;
        int res = CountCoins(coins, amount, dpmat);
        if(res == int.MaxValue)
            return -1;
        return res;
    }
    
    public int CountCoins(int[] coins, int amount, int[] dpmat)
    {
        if(dpmat[amount] >= 0)
            return dpmat[amount];
        int min = int.MaxValue;
        for(int i = 0; i< coins.Length; i++)
        {
            if(coins[i] == 0)
                continue;
            if(coins[i] <= amount)
            {
                var res = CountCoins(coins, amount - coins[i], dpmat);
                if(res == int.MaxValue)
                    continue;
                int currRes = 1 + res;
                if(min > currRes)
                {
                    min = currRes;
                }
            }
        }
        dpmat[amount] = min;
        return min;
    }
}