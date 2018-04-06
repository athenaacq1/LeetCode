public class Solution {
    public bool IsMatch(string s, string p) 
    {
        if(p.Length > 1 && s.Length > 1 && p[p.Length - 1] != '.' && p[p.Length - 1] != '*' )
        {
            if(p[p.Length - 1] != s[s.Length - 1])
                return false;
        }
        return Match(s, p, 0, 0, '\0');
    }
    
    public bool Match(string s, string p, int i, int j, char starchar)
    {
        if(i == s.Length && j == p.Length)
        {
            return true;
        }
        
        if(j == p.Length)
            return false; 
        
        var v1 = false;
        var v2 = false;
        var v3 = false;
        var v4 = false;
        if(j != p.Length - 1 && p[j+1] == '*')
        {
            starchar = p[j];
            v1 = Match(s, p, i, j+1, starchar);
            if(v1) return true;
        }
        
        if(p[j] == '.')
        {
            if(i == s.Length)
                return false;
            v2 = Match(s, p, i+1, j+1, '\0');
            if(v2) return true;
        }
        else if(p[j] == '*')
        {
            v3 = Match(s, p, i, j+1, '\0'); // 0 match
            if(v3) return true;
            if(i == s.Length)
                return false;
            if(starchar == '.')
            {
                v3 = Match(s, p, i + 1, j, starchar); //keep matching
                if(v3) return true;
                v3 = Match(s, p, i+1, j+1, '\0'); //move on 
                if(v3) return true;
            }
            if(s[i] == starchar)
            {
                v3 = Match(s, p, i + 1, j, starchar); //keep matching
                if(v3) return true;
                v3 = Match(s, p, i+1, j+1, '\0'); //move on 
                if(v3) return true;
            }
        }
        else
        {
            if(i == s.Length)
                    return false;
            if(s[i] == p[j])
            {
                v4 = Match(s, p, i+1, j+1, '\0');
                if(v4) return true;
            }
        }
        
        return false;
    }
}