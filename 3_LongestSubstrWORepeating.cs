public class Solution {
    public int LengthOfLongestSubstring(string s) 
    {
        if(string.IsNullOrWhiteSpace(s))
        {
            return 0;
        }
        if(s.Length == 1)
        {
            return 1;
        }
        
        var set = new HashSet<char>();
        foreach(char c in s)
        {
            set.Add(c);
        }
        
        int un = set.Count();
        int maxlen = 1;
        int[,] ext = new int[s.Length,2];
        
        var hs = new HashSet<char>();
        ext[0,0] = 0;
        ext[0,1] = 0;
        for(int i = 1; i<s.Length;i++)
        {
            int newsub = i;
            hs.Clear();
            for(int j = i; j>= 0; j--)
            {
                if(!hs.Contains(s[j]))
                {
                    hs.Add(s[j]);
                    newsub = j;
                }
                else
                {
                    break;
                }
            }
            int len = i - newsub + 1;
            if(maxlen < len)
            {
                maxlen = len;
                ext[i,0] = newsub;
                ext[i,1] = i;
            }
            else
            {
                ext[i,0] = ext[i-1,0];
                ext[i,1] = ext[i-1,1];
            }
        }
        
        return maxlen;
    }
}