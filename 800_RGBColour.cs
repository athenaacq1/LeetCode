public class Solution {
    public string SimilarRGB(string color) 
    {
        var first = color.Substring(1,2);
        var second = color.Substring(3,2);
        var third = color.Substring(5,2);
        
        var sb = new StringBuilder();
        sb.Append("#");
        sb.Append(Find(first));
        sb.Append(Find(second));
        sb.Append(Find(third));
        return sb.ToString();
    }
    
    public string Find(string str)
    {
        if(str[0] == str[1])
            return str;
        
        var str1 = GetPrevious(str);
        var str2 = GetNext(str);
        
        var diff1 = GetDiff(str, str1);
        var diff2 = GetDiff(str, str2);
        Console.WriteLine("str1 = " + str1 + " str2 = " + str2 + " diff1 = " + diff1 + " diff2 = " + diff2);
        if(Math.Abs(diff1) < Math.Abs(diff2))
        {
            return str1;            
        }
        else
        {
            return str2;
        }
    }
    
    public int GetDiff(string str1, string str2)
    {
        /*if(!IsGreather(str1, str2))
        {
            string tmp = str1;
            str1 = str2;
            str2 = tmp;
        }*/
        int v1 = 16 * GetNum(str1[0]) + GetNum(str1[1]);
        int v2 = 16 * GetNum(str2[0]) + GetNum(str2[1]);
        
        return v1 - v2;
    }
    
    public int GetNum(char c)
    {
        int n = (int)c;
        if( n >= 48 && n <= 57)
        {
            return n - 48;
        }
        else
        {
            return (n - 97) + 10;
        }
    }
    
    public string GetPrevious(string str)
    {
        if(str[0] < str[1])
        {
            return str[0].ToString() + str[0].ToString();
        }
        else
        {
            int n = (int)str[0] - 1;
            if(str[0] == 97)
            {
                n = 57;
            }
            char c0 = (char)n;
            return c0.ToString() + c0.ToString();
        }
    }
    
    public string GetNext(string str)
    {
        if(str[0] < str[1])
        {
            int n = (int)str[0] + 1;
            if(str[0] == 57)
            {
                n = 97;
            }
            char c0 = (char)n;
            return c0.ToString() + c0.ToString();
        }
        else
        {
            return str[0].ToString() + str[0].ToString();
        }
    }
    
}