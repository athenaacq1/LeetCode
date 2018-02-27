public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) 
    {
        var dict = new Dictionary<string, List<string>>();
        
        foreach(var str in strs)
        {
            var arr = str.ToCharArray();
            Array.Sort(arr);
            Console.WriteLine(String.Join(",", arr));
            var k = String.Join("", arr);
            var ana = new List<string>();
            if(dict.ContainsKey(k))
            {
                ana = dict[k];
            }
            else
            {
                dict.Add(k, ana);
            }
            ana.Add(str);
        }
        
        return (dict.Select(x => (IList<string>)x.Value)).ToList();
    }
}