public class Solution {
    public int KEmptySlots(int[] flowers, int k) 
    {
        if(flowers.Length <= 1)
            return -1;
        
        int N = 1;
        for(int i = 0; i < flowers.Length; i++)
            if(N < flowers[i])
                N = flowers[i];
        
        var bloom = new bool[N];
        bloom[flowers[0]-1] = true;
        for(int i = 1; i < flowers.Length; i++)
        {
            bloom[flowers[i]-1] = true;
            int ls = flowers[i]-1;
            bool kf = true;
            if(ls - (k+1) >= 0) //left
            {
                for(int j = ls-1; j >= ls - k; j--)
                {
                    if(bloom[j])
                    {
                        kf = false;
                        break;
                    }
                }
                if(kf && bloom[ls - (k+1)])
                    return i+1;
            }
            kf = true;
            if(ls + (k+1) < bloom.Length)
            {
                for(int j = ls + 1; j <= ls + k; j++)
                {
                    if(bloom[j])
                    {
                        kf = false;
                        break;
                    }
                }
                if(kf && bloom[ls + k + 1])
                    return i+1;
            }
            
        }
        
        return -1;
    }
}