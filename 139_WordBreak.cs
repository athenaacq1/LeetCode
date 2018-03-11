public class Solution {
    public bool WordBreak(string s, IList<string> wordDict) 
    {
        var wordSet = new HashSet<string>(wordDict);
        
        if(wordSet.Count() == 0)
        {
            return false;
        }
        
        var lastSpace = -1;
        bool[] dp = new bool[s.Length];
        for(int i = 1; i <=s.Length; i++)
        {
            for(int j = 0; j < i; j++)
            {
                var cand = s.Substring(j, i - j);
                //Console.WriteLine("cand = " + cand);
                if(wordSet.Contains(cand))
                {
                    if(j == 0 || dp[j-1])
                    {
                        dp[i-1] = true;
                        break;    
                    }
                }
            }
        }
        
        //Console.WriteLine(String.Join(",", dp));
        
        return dp[s.Length - 1];
    }
}
