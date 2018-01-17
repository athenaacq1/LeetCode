public class Solution {
    public int MyAtoi(string str) 
    {
        str = str.Trim();
        bool neg = false;
        if(str.StartsWith("-"))
        {
            neg = true;
            str = str.Substring(1);
        }
        else if(str.StartsWith("+"))
        {
            str = str.Substring(1);
        }
        var ch = str.ToCharArray();
        var sb = new StringBuilder();
        for(int i=0; i<ch.Length; i++)
        {
            if(Char.IsDigit(ch[i]))
            {
                sb.Append(ch[i]);
            }
            else
                break;
        }
        var data = sb.ToString().Trim();
        Console.WriteLine(data);
        if(data == "")
        {
            return 0;
        }
        int n = 0;
        if(neg)
            data = "-" + data;
        try
        {
            n = int.Parse(data);
        }
        catch(System.OverflowException e)
        {
            if(neg)
                return int.MinValue;
            else
                return int.MaxValue;
        }
        catch(Exception e)
        {
            ;
        }
        return n;
    }
}