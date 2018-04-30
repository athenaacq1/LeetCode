public class Solution {
    public int MinimumLengthEncoding(string[] words) 
    {
        var set = new HashSet<string>(words);
        var segments = new HashSet<string>();
        var length = 0;
        var seen = new HashSet<string>();
        foreach(var word in words)
        {
            if(!segments.Contains(word))
            {
                var post = new StringBuilder();
                for(int i = 0; i < word.Length; i++)
                {
                    post.Insert(0,word[word.Length - 1 - i]);
                    var po = post.ToString();
                    if(seen.Contains(po))
                    {
                        length = length - (po.Length + 1);
                        seen.Remove(po);
                    }
                    segments.Add(po);
                }
                length = length + word.Length + 1;
                seen.Add(word);
            }
        }
        
        return length;
    }
}