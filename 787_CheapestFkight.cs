public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K) 
    {
        if(n == 1)
            return 0;
        if(flights.Length == 0)
            return -1;
        var prices = new int[n,n];
        foreach(var f in flights)
        {
            prices[f[0],f[1]] = f[2];
        }
        
        var min = int.MaxValue;
        
        var dpmat = new int[n,K+1];
        return GetOption(src, dst, K, dpmat, prices);
    }
    
    public int GetOption(int src, int dst, int K, int[,] dpmat, int[,] prices)
    {
        if(src == dst)
            return 0;
        
        if(K == -1)
            return -1;
        
        if(dpmat[src,K] != 0)
            return dpmat[src,K];
        
        int min = int.MaxValue;
        for(int i = 0; i < dpmat.GetLength(0); i++)
        {
            if(i == dst)
            {
                var t = prices[src,dst];
                if(t != 0 && min > t)
                {
                    min = t;
                }
            }
            else if(prices[src,i] > 0)
            {
                var t = GetOption(i, dst, K-1, dpmat, prices);
                if(t != -1)
                {
                    t = prices[src,i] + t;
                    if(min > t)
                        min = t;
                }
            }
        }
        
        if(min == int.MaxValue)
            min = -1;
        
        dpmat[src,K] = min;
        return min;
    }
}