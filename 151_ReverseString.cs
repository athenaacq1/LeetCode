public class Solution {
    public string ReverseWords(string s) 
    {
        if(String.IsNullOrWhiteSpace(s))
            return string.Empty;
        
        var res = new List<string>();
        var sb = new StringBuilder();
        for(int i = 0; i < s.Length; i++)
        {
            if(s[i] == ' ')
            {
                var token = sb.ToString();
                sb.Clear();
                if(!String.IsNullOrWhiteSpace(token))
                {
                    res.Insert(0,token);
                }
            }
            else
                sb.Append(s[i]);
        }
        var last = sb.ToString();
        if(!String.IsNullOrWhiteSpace(last))
        {
            res.Insert(0,last);
        }
        
        return String.Join(" ", res);
    }
}