public class Solution {
    public int KthGrammar(int N, int K) 
    {
        if(N == 1)
        {
            return 0;
        }
        if(N == 2)
        {
            return K == 1 ? 0 : 1;
        }
        var p = "01";
        K = K - 1;
        while(N > 2)
        {
            var t = (int)Math.Pow(2,N-1);
            if(K < t/2)
            {
                ;
            }
            else
            {
                K = K - t/4;
                if(K >= t/2)
                {
                    K = K - t/2;
                }
            }
            N--;
            //Console.WriteLine("N = " + N + " t = " + t + " K = " + K);
        }
        
        if(K == 0)
            return 0;
        else 
            return 1;
        
    }
}