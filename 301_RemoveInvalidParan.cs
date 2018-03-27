public class Solution {
    public IList<string> RemoveInvalidParentheses(string s) 
    {
        var result = new Dictionary<string, Tuple<int,int,int>>();
        int startindex = 0;
        var sb = new StringBuilder();
        foreach(var c in s)
        {
            if(c != '(')
            {
                startindex++;    
            }
            else
            {
                break;
            }
            if(c != '(' && c != ')')
            {
                sb.Append(c);
            }
        }
        if(startindex == s.Length)
        {
            var l = new List<string>();
            l.Add(sb.ToString());
            return l;
        }
            
        
        result.Add("(", new Tuple<int,int,int>(1,0,startindex));
        result.Add("", new Tuple<int,int,int>(0,0,startindex + 1));
        
        /*Console.WriteLine("next");
            foreach(var pair in result)
            {
                Console.WriteLine(pair.Key + " - " + pair.Value.Item1 + " - " + pair.Value.Item2 + " - " + pair.Value.Item3);
            }*/
        
        for(int i = startindex + 1; i < s.Length; i++)
        {
            var update = new Dictionary<string, Tuple<int,int,int>>();
            var c = s[i];
            //Console.WriteLine("i = " + i + "c = " + c);
            bool passthru = (c == '(' || c == ')') ? false: true;
            
            foreach(var pair in result)
            {
                if(passthru)
                {
                    Add(pair.Key + c, new Tuple<int, int, int> (pair.Value.Item1, pair.Value.Item2, pair.Value.Item3), update);
                    //Console.WriteLine("1. Added = " + (pair.Key + c));
                    continue;
                }
                
                // don;t include 
                Add(pair.Key, new Tuple<int, int, int> (pair.Value.Item1, pair.Value.Item2, pair.Value.Item3 + 1), update);
                //Console.WriteLine("2. Added = " + (pair.Key));
                
                // include, c is open bracket, always add
                if(c == '(')
                {
                    var nk = pair.Key + c;
                    Add(nk, new Tuple<int, int, int> (pair.Value.Item1 + 1, pair.Value.Item2, pair.Value.Item3), update);
                    //Console.WriteLine("3. Added = " + (pair.Key + c));
                }
                else
                {
                    // include, c is closed bracket
                    if(pair.Value.Item1 > pair.Value.Item2)
                    {
                        var nk = pair.Key + c;
                        Add(nk, new Tuple<int, int, int> (pair.Value.Item1, pair.Value.Item2 + 1, pair.Value.Item3), update);
                        //Console.WriteLine("4. Added = " + (pair.Key + c));
                    }    
                }
            }
            
            result = update;
            /*Console.WriteLine("next");
            foreach(var pair in result)
            {
                Console.WriteLine(pair.Key + " - " + pair.Value.Item1 + " - " + pair.Value.Item2 + " - " + pair.Value.Item3);
            }*/
        }
        
        int minrem = int.MaxValue;
        foreach(var pair in result)
        {
            if(pair.Value.Item1 == pair.Value.Item2) // valid
            {
                if(minrem > pair.Value.Item3)
                {
                    minrem = pair.Value.Item3;
                }
            }
        }
        
        var final = new List<string>();
        foreach(var pair in result)
        {
            if(pair.Value.Item3 == minrem && pair.Value.Item1 == pair.Value.Item2)
            {
                final.Add(sb.ToString() + pair.Key);
            }
        }
        
        return final;
    }
    
    public void Add(string s, Tuple<int, int, int> tuple, Dictionary<string, Tuple<int, int, int>> dict)
    {
        if(dict.ContainsKey(s))
        {
            if(dict[s].Item3 > tuple.Item3)
            {
                dict[s] = tuple;
            }
        }
        else
            dict.Add(s, tuple);
    }
    
    
}