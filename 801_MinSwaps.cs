public class Solution {
    public int MinSwap(int[] A, int[] B) 
    {
        if(A.Length == 1)
            return 0;
        
        int[,] dpmat = new int[A.Length,2];
        dpmat[0,0] = 0;
        dpmat[0,1] = 1;
        var x = A;
        var y = B;
        for(int i = 1; i< A.Length; i++)
        {
            //no flip i
            var nf1 = int.MaxValue;
            var nf2 = int.MaxValue;
             // no flip i - 1
            if(x[i-1] < x[i] && y[i-1] < y[i])
            {
                nf1 = dpmat[i-1,0];
            }
            
             // flip i - 1
            if(y[i-1] < x[i] && x[i-1] < y[i])
            {
                nf2 = dpmat[i-1,1];
            }
            dpmat[i,0] = Math.Min(nf1, nf2);
            
            // flip i 
            var f1 = int.MaxValue;
            var f2 = int.MaxValue;
             // no flip i-1
            if(x[i-1] < y[i] && y[i-1] < x[i])
            {
                f1 = 1 + dpmat[i-1,0];
            }
             // flip i - 1
            if(x[i-1] < x[i] && y[i-1] < y[i])
            {
                f2 = 1 + dpmat[i-1,1];
            }
            dpmat[i,1] = Math.Min(f1,f2);    
        }
        
        return Math.Min(dpmat[A.Length-1,0],dpmat[A.Length-1,1]);        
    }
}