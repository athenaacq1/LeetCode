public class Solution 
{
    public int Reverse(int x) 
    {
        char[] ch = x.ToString().ToCharArray();
        bool neg = false;
        if(ch[0] == '-')
        {
            neg = true;
        }
        var sb = new StringBuilder();
        for(int i=ch.Length-1;i>=0;i--)
        {
            if(i == 0 && neg)
                continue;
            sb.Append(ch[i]);
        }
        if(neg)
        {
            sb.Insert(0, "-");
        }
        //Console.WriteLine(sb);
        int n = 0;
        try
        {
            n = Int32.Parse(sb.ToString()); 
        }
        catch(System.OverflowException e)
        {
            ;
        }
        catch(Exception e)
        {
            ;
        }
        //Console.WriteLine(n);
        return n;
    }
}