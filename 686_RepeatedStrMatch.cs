public class Solution {
    public int RepeatedStringMatch(string A, string B) 
    {
        if(String.IsNullOrWhiteSpace(A) && String.IsNullOrWhiteSpace(B))
            return 1;
        
        if(String.IsNullOrWhiteSpace(A) || String.IsNullOrWhiteSpace(B))
            return -1;
        
        if(A.Equals(B))
            return 1;
        
        var sb = new StringBuilder(A);
        int cnt = 1;
        while(sb.Length < B.Length)
        {
            sb.Append(A);
            cnt++;
        }
        if(sb.ToString().Contains(B))
            return cnt;
        
        sb.Append(A); //3rd
        if(sb.ToString().Contains(B))
            return cnt + 1;
        
        return -1;
        
    }
}