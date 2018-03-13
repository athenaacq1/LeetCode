public class Solution {
    public IList<string> WordBreak(string s, IList<string> wordDict) 
    {
        if(String.IsNullOrWhiteSpace(s) || wordDict.Count() == 0)
            return new List<string>();
        
        var dict = new Dictionary<string, int>();
        for(int i = 0; i < wordDict.Count(); i++)
        {
            dict.Add(wordDict[i], i);
        }
        
        var dp = new List<List<int>>();
        var candidates = new List<List<int>>();
        
        for(int i = 0; i < s.Length; i++)
        {
            var cand = s.Substring(i, s.Length - i);
            int ind = -1;
            if(dict.TryGetValue(cand, out ind))
            {
                candidates.Add(new List<int> {i});
                //Console.WriteLine("i = " + i);
            }
        }
        
        int nop = 0;
        while(candidates.Count() > 0)
        {
            int allfound = 0;
            foreach(var c in candidates)
            {
                int end = c[0];
                //Console.WriteLine("end = " + end);
                if(end == 0)
                {
                    allfound++;
                    var nl = new List<int>();
                    nl.AddRange(c);
                    dp.Add(nl);
                }
                else
                {
                    for(int i = 0; i < end; i++)
                    {
                        var cand = s.Substring(i, end - i);
                        int ind = -1;
                        if(dict.TryGetValue(cand, out ind))
                        {
                            var nl = new List<int>();
                            nl.AddRange(c);
                            nl.Insert(0,i);
                            //Console.WriteLine("i = " + i);
                            dp.Add(nl);
                            //Console.WriteLine(String.Join(",",nl));
                        }
                    }
                }
            }
            //Console.WriteLine("dp = " + dp.Count());
            if(allfound == candidates.Count())
            {
                candidates = dp;
                break;
            }
            candidates = dp;
            dp = new List<List<int>>();
            nop++;
            Console.WriteLine(nop);
            if(candidates.Count() >= 1000)
                return new List<string>();
        }
        
        var result = new List<string>();
        foreach(var c in candidates)
        {
            var sb = new StringBuilder(s);
            int space = 0;
            foreach(var ind in c)
            {
                sb.Insert(ind + space, " ");
                space++;
            }
            result.Add(sb.ToString().Trim());
        }
        
        return result;
    }
}