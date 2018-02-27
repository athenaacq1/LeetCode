public class Solution {
    public string Multiply(string num1, string num2) 
    {
        if(string.IsNullOrWhiteSpace(num1) || string.IsNullOrWhiteSpace(num2)) 
            return "0";
        
        if(num1.Equals("0") || num2.Equals("0")) 
            return "0";
        
        var first = num1;
        var second = num2;
        if(num1.Length < num2.Length)
        {
            first = num2;
            second = num1;
        }
        
        var acc = new List<List<int>>();
        var z = new List<int>();
        for(int i = 0; i<second.Length;i++)
        {
            var n = (int)Char.GetNumericValue(second[second.Length - 1 - i]);
            var res = MultiplyOne(first, n);
            for(int j = 0; j< z.Count(); j++)
            {
                res.Insert(0, z[j]);
            }
            acc.Add(res);
            //Console.WriteLine(first + " * " + n + " = " + String.Join("", res));
            z.Add(0);
        }
        
        int p = acc[acc.Count()-1].Count();
        var final = new StringBuilder();
        int carry = 0;
        for(int i = 0; i<p;i++)
        {
            int f = 0;
            for(int j = 0; j<acc.Count();j++)
            {
                if(i < acc[j].Count())
                {
                    f += acc[j][i];
                }
            }
            f += carry;
            var rr = f.ToString();
            //Console.WriteLine("R = " + rr);
            if(rr.Length > 1)
            {
                carry = int.Parse(rr.Substring(0, rr.Length - 1));
                final.Append(rr[rr.Length - 1]);
            }
            else
            {
                carry = 0;
                final.Append(rr[0]);
            }
        }
        if(carry > 0)
            final.Append(carry.ToString());
        
        var ans = String.Join("",final.ToString().Reverse());
        return ans;
    }
    
    public List<int> MultiplyOne(string first, int m)
    {
        int carry = 0;
        var res  = new List<int>();
        for(int i = 0; i< first.Length;i++)
        {
            var n = (int)Char.GetNumericValue(first[first.Length - 1 - i]);
            var r =  n * m;
            var rr = (r + carry).ToString();
            //Console.WriteLine("n = " + n + " m = " + m + " r = " + r + "carry was = " + carry + " rr = " + rr);
            if(rr.Length > 1)
            {
                carry = (int)Char.GetNumericValue(rr[0]);
                res.Add((int)Char.GetNumericValue(rr[1]));
              //  Console.WriteLine("Adding " + rr[1]);
            }
            else
            {
                carry = 0;
                res.Add((int)Char.GetNumericValue(rr[0]));
                //Console.WriteLine("Adding " + rr[0]);
            }
        }
        if(carry > 0)
        {
            res.Add(carry);
        }
        return res;
    }
}