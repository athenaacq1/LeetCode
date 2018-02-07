public class Solution {
    public int MinDistance(string word1, string word2) 
    {
        
        if(string.IsNullOrEmpty(word1) && string.IsNullOrEmpty(word2))
        {
            return 0;
        }
        if(string.IsNullOrEmpty(word1))
        {
            if(string.IsNullOrEmpty(word2))
            {
                return 0;
            }
            return word2.Length; 
        }
        
        if(string.IsNullOrEmpty(word2))
        {
            if(string.IsNullOrEmpty(word1))
            {
                return 0;
            }
           return word1.Length; 
        }
        
        int[,] dpmatrix = new int[word1.Length + 1, word2.Length + 1];
        for(int i = 0; i<=word1.Length; i++)
        {
            dpmatrix[i,word2.Length] = word1.Length - i; 
        }
        
        for(int j = 0; j<=word2.Length; j++)
        {
            dpmatrix[word1.Length,j] = word2.Length - j; 
        }
        for(int i = 0; i<=word1.Length; i++)
        {
            for(int j = 0; j<=word2.Length; j++)
            {
                Console.Write(dpmatrix[i,j] + " ");    
            }
            Console.WriteLine();
        }
        for(int i = word1.Length-1; i >=0; i--)
        {
            for(int j = word2.Length-1; j >= 0; j--)
            {
                var v1 = int.MaxValue;
                var v2 = int.MaxValue;
                var v3 = int.MaxValue;
                if(i < word1.Length)
                {
                    v1 = dpmatrix[i+1,j] + 1;
                }
                if(j < word2.Length)
                {
                    v2 = dpmatrix[i, j+1] + 1;
                }
                if(i < word1.Length && j < word2.Length)
                {
                    if(word1[i] == word2[j])
                    {
                        v3 = dpmatrix[i+1,j+1];
                    }
                    else
                    {
                        v3 = dpmatrix[i+1, j+1] + 2;
                    }
                }
                
                dpmatrix[i,j] = Math.Min(Math.Min(v1, v2), v3);
            }
        }
        
        Console.WriteLine("---------------");
        for(int i = 0; i<=word1.Length; i++)
        {
            for(int j = 0; j<=word2.Length; j++)
            {
                Console.Write(dpmatrix[i,j] + " ");    
            }
            Console.WriteLine();
        }
        
        bool[] del1 = new bool[word1.Length];
        int k = 0;
        int l = 0;
        while(k < word1.Length && l <word2.Length)
        {
            var v1 = dpmatrix[k+1,l];
            var v2 = dpmatrix[k,l+1];
            var v3 = dpmatrix[k+1,l+1];
            
            if(v1 <= v2 && v1 <= v3)
            {
                del1[k] = true;
                k++;
            }
            else if(v2 <= v1 && v2 <= v3)
            {
                del1[k] = false;
                l++;
            }
            else if(v3 <= v1 && v3 <= v2)
            {
                if(word1[k] != word2[l])
                {
                    del1[k] = true;
                }
                k++;
                l++;
            }
        }
        for(int i = k; i<word1.Length; i++)
        {
            del1[i] = true;
        }
        var sb = new StringBuilder();
        for(int i = 0; i<word1.Length; i++)
        {
            if(!del1[i])
                sb.Append(word1[i]);
        }
        Console.WriteLine("Common SubSequence = " + sb.ToString());
        return dpmatrix[0,0];
    }
}