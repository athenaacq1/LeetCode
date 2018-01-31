public class Solution {
    public string RemoveKdigits(string num, int k) 
    {
        if(string.IsNullOrEmpty(num))
        {
            return "0";
        }
        if(num.Length == k)
        {
            return "0";
        }
        
        var sb = new StringBuilder();
        int top = -1;
        for(int i=0;i<num.Length;i++)
        {
                if(k > 0 && sb.Length > 0 && sb[top] > num[i])
                {
                    // remove top
                    //Console.WriteLine("remvoe "+sb[top]);
                    sb.Remove(top,1);
                    k--;
                    i--;
                    //sb.Append(num[i]);
                    //Console.WriteLine("Append "+sb[top]);
                    top--;
                }
                else
                {
                    if(num[i] == '0' && sb.Length == 0)
                        continue;
                    sb.Append(num[i]);
                    top++;
                    //Console.WriteLine("Append "+sb[top]);
                }
            //Console.WriteLine(sb.ToString());
        }
        while(k > 0 && sb.Length > 0)
        {
            sb.Remove(top,1);
            top--;
            k--;
        }
        
        var str = sb.ToString();
        if(string.IsNullOrEmpty(str))
        {
            return "0";
        }
        int z = 0;
        if(str.StartsWith("0"))
        {
            for(int i=1;i<str.Length;i++)
            {   
                z = i;
                if(str[i] != '0')
                {
                    break;
                }
            }
        }
        //Console.WriteLine(z);
        str = str.Substring(z);
        return str;
    }
}