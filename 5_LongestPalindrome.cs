public class Solution {
    public string LongestPalindrome(string s) 
    {
        if(string.IsNullOrWhiteSpace(s))
        {
            return "";
        }
        if(s.Length == 1)
        {
            return s;
        }
        if(s.Length == 2 && s[0] == s[1])
        {
            return s;
        }
        
        int maxlen = 1;
        string maxstr = s[0].ToString();
        for(int i = 0; i<s.Length;i++)
        {
            //with curr char as center
            int j,k;
            j = i - 1;
            k = i + 1;
            while(j >= 0 && k <s.Length)
            {
                if(s[j] != s[k])
                {
                    break;
                }
                j--;
                k++;
            }
            
            int len = k - j - 1;
            if(len > maxlen)
            {
                maxlen = len;
                if(j < 0)
                {
                    maxstr = s.Substring(0,len);
                }
                else
                {
                    maxstr = s.Substring(j+1,len);
                }
                //Console.WriteLine("1: j = " + j +" k = " + k + "str = " + maxstr);
            }
            
            //with curr and curr+1
            if(i+1 < s.Length && s[i] == s[i+1])
            {
                if(maxlen < 2)
                {
                    maxlen = 2;
                    maxstr = s.Substring(i,2);
                }
                j = i - 1;
                k = i + 2;
                while(j >= 0 && k <s.Length)
                {
                    if(s[j] != s[k])
                    {
                        break;
                    }
                    j--;
                    k++;
                }
                len = k - j - 1;
                if(len > maxlen)
                {
                    maxlen = len;
                    if(j < 0)
                    {
                        maxstr = s.Substring(0,len);
                    }
                    else
                    {
                        maxstr = s.Substring(j+1,len);
                    }
                    //Console.WriteLine("2: j = " + j +" k = " + k + "str = " + maxstr);
                }
            }
        }
        return maxstr;
    }
}