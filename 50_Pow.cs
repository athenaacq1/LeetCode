public class Solution {
    public double MyPow(double x, int n) 
    {
        if(n == 0)
            return 1;
        if(n == 1 || x == 1)
            return x;
        if(n == -1)
            return 1 * 1d / x;
        if(x == -1 && n%2 == 0)
            return 1;
        if(x == -1 && n%2 == 1)
            return -1;
        if(n == int.MinValue && x > 1)
            return 0;
        if(n == int.MinValue && x < 1)
            return Double.PositiveInfinity;
        
        var p = n;
        if(n < 0)
            p = -n; 
        
        var dict = new Dictionary<int, double>();
        var ptr = 2;
        double res = x * x;
        dict.Add(1, x);
        dict.Add(2, res);
        
        while(ptr + ptr <= p && !dict.ContainsKey(ptr + ptr))
        {
            res = res * res;
            if(res == 0.0)
                return 0;
            ptr = ptr + ptr;
            dict.Add(ptr, res);
        }
        if(ptr < p)
        {
            var rdict = dict.Reverse();
            foreach(var pair in rdict)
            {
                while(ptr + pair.Key <= p)
                {
                    ptr = ptr + pair.Key;
                    res = res * pair.Value;
                }
            }
        }
        
        var final = res;
        if(n < 0)
            final = 1 * 1d / res;
        
        return final;
    }
}