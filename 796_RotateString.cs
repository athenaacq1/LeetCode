public class Solution {
    public bool RotateString(string A, string B) 
    {
        if(A == null && B == null)
        {
            return true;
        }
        else if(A == null)
            return false;
        else if(B == null)
            return false;
        else if(A.Length != B.Length)
            return false;
        
        int len = A.Length;
        int candStart = 0;
        int candRot = len - candStart;
        
        while(candStart != len)
        {
            int j = 0;
            int i = candStart;
            int k = 0;
            int l = len - candStart;
            //Console.WriteLine("s = " + candStart);
            for(; i < len; i++)
            {
                if(A[i] == B[j])
                {
                    if(l < len)
                    {
                        if(A[k] == B[l])
                        {
                            k++;
                            l++;    
                        }
                        else
                        {
                            break;
                        }
                    }
                    j++;
                }
                else
                    break;
            }
            if(i == len)
            {
                return true;
            }
            candStart++;
        }
        return false;
    }
}