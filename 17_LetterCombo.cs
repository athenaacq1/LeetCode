public class Solution {
    public IList<string> LetterCombinations(string digits) 
    {
        if(digits.Length == 0 || digits.Contains("1") || digits.Contains("0"))
            return new List<string>();
        
        var dict = new Dictionary<int, List<char>>();
        dict.Add(2, new List<char>() {'a', 'b', 'c'});
        dict.Add(3, new List<char>() {'d', 'e', 'f'});
        dict.Add(4, new List<char>() {'g', 'h', 'i'});
        dict.Add(5, new List<char>() {'j', 'k', 'l'});
        dict.Add(6, new List<char>() {'m', 'n', 'o'});
        dict.Add(7, new List<char>() {'p', 'q', 'r', 's'});
        dict.Add(8, new List<char>() {'t', 'u', 'v'});
        dict.Add(9, new List<char>() {'w', 'x', 'y', 'z'});
        
        var result = new List<string>();
        result.Add("");
        foreach(var c in digits)
        {
            var candidates = new List<string>();
            var set = dict[(int)Char.GetNumericValue(c)];
            foreach(var s in result)
            {
                foreach(var d in set)
                {
                    candidates.Add(s + d);
                }
            }
            result = candidates;
        }
        return result;
    }
}