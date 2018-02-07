public class Solution {
    public string LongestCommonPrefix(string[] strs) 
    {
        if(strs == null || strs.Length == 0)
        {
            return "";
        }
        var sb = new StringBuilder();
        int minlen = int.MaxValue;
        for(int i = 0; i< strs.Length; i++)
        {
            if(string.IsNullOrEmpty(strs[i]))
            {
                minlen = 0;
                break;
            }
            if(strs[i].Length < minlen)
            {
                minlen = strs[i].Length;
            }
        }
        for(int i = 0; i< minlen; i++)
        {
            var c = strs[0][i];
            bool f = true;
            for(int j = 1; j< strs.Length; j++)
            {
                if(c != strs[j][i])
                {
                    f = false;
                    break;
                }
            }
            if(f)
            {
                sb.Append(c);
            }
            else
            {
                break;
            }
        }
        
        return sb.ToString();
    }
}